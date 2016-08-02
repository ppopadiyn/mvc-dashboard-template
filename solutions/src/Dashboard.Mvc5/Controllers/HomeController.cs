using System.Web.Mvc;

namespace Dashboard.Mvc5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}