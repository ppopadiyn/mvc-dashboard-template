using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Core.Controllers
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