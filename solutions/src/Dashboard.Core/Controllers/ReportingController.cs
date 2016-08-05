using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Controllers
{
    [Authorize]
    public class ReportingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}