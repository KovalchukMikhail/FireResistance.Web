using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FireResistance.Web.Models.ViewModels;

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
        public IActionResult ColumnFireFourSide(ColumnFireIsWithFourSidesData sourceData)
        {
            DataOfColumnFireFourSideVM data = new DataOfColumnFireFourSideVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
            }
            return View(data);

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
