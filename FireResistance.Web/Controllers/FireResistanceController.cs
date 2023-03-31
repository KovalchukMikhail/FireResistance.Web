using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;

namespace FireResistance.Web.Controllers
{
    public class FireResistanceController : Controller
    {
        [HttpGet]
        public IActionResult ColumnFireFourSide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ColumnFireFourSide(ColumnFireIsWithFourSidesData data)
        {
            data.Check = true; //!!!!!!!!!!!!!!!!!!!!!!!
            FireResistanceBasic fireResistance = new FireResistanceBasic();
            fireResistance.TryPerformCalculation(data);

            ResultAsDictionary result = fireResistance.GetResult() as ResultAsDictionary;
            string[] str = result.ToString().Split("\n");
            return View(str);
        }

        [HttpGet]
        public IActionResult PlateWithRigidConnectionToColumns()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult PlateWithRigidConnectionToColumns()
        //{

        //}

        [HttpGet]
        public IActionResult PlateWithRigidConnectionToTwoWalls()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult PlateWithRigidConnectionToTwoWalls()
        //{

        //}



    }
}
