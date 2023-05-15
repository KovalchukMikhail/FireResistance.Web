using FireResistance.Core;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FireResistance.Logger;
using NuGet.Common;

namespace FireResistance.Web.Controllers
{
    public class MainController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            //CreateLog();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private void CreateLog()
        //{
        //    string log = $"User: {User.Identity.Name}: DateTime: {DateTime.Now.ToString()}";
        //    using (ILoggerFactory loggerFactory = new LoggerFactory())
        //    {
        //        loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
        //        var logger = loggerFactory.CreateLogger("FileLogger");
        //        logger.LogInformation(log);
        //    }
        //}
    }
}