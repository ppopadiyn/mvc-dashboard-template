using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Core.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel {Username = "demo", Password = "demo-123"});
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Verify username credentials.

            ClaimsIdentity claimsIdentity = new ClaimsIdentity( "Cookies", ClaimTypes.Name, ClaimTypes.Role);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, model.Username));
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return RedirectToLocal(returnUrl);
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction(ActionNames.LogIn, ControllerNames.Account);
        }

        public IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl)
                ? (IActionResult)Redirect(returnUrl)
                : RedirectToAction(ActionNames.Index, ControllerNames.Home);
        }
    }
}
