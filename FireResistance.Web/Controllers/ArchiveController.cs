using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FireResistance.Web.Controllers
{
    [Authorize]
    public class ArchiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
