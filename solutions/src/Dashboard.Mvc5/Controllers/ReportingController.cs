using System.Web.Mvc;

namespace Dashboard.Mvc5.Controllers
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