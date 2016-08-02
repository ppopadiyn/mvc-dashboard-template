using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace Dashboard.Mvc5.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { Username = "demo", Password = "demo-123" });
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Verify username credentials.

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>(), "ApplicationCookie");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, model.Username));
            AuthenticationManager.SignIn(new AuthenticationProperties(), claimsIdentity);

            return RedirectToLocal(returnUrl);
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction(ActionNames.LogIn, ControllerNames.Account);
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl)
                ? (ActionResult)Redirect(returnUrl)
                : RedirectToAction(ActionNames.Index, ControllerNames.Home);
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}