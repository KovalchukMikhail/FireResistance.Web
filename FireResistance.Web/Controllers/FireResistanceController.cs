using Microsoft.AspNetCore.Mvc;

namespace FireResistance.Web.Controllers
{
    public class FireResistanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
