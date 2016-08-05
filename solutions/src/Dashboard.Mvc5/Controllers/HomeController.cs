using System.Web.Mvc;

namespace Demo.Mvc5.Controllers
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