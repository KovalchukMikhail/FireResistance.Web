using FireResistance.Core;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FireResistance.Web.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}