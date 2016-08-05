using System.Web.Mvc;

namespace Demo.Mvc5.Controllers
{
    [Authorize]
    public class ReportingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}