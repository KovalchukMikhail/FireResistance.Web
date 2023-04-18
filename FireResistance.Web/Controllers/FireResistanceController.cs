using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FireResistance.Web.Models.ViewModels;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

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

        [HttpPost]
        public IActionResult PlateWithRigidConnectionToColumns(PlateWithRigidConnectionToColumnsData sourceData)
        {
            DataOfPlateWithRigidConnectionToColumnsVM data = new DataOfPlateWithRigidConnectionToColumnsVM(sourceData);
            if (ModelState.IsValid)
            {
                //FireResistanceBasic fireResistance = new FireResistanceBasic();
                //fireResistance.PerformCalculation(sourceData);
                //data.Result = fireResistance.GetResult() as ResultAsDictionary;
                data.Result = new ResultAsDictionary();
                data.Result.ResultAsString = "Исходные данные приняты";
                return View(data);
            }
            return View(data);
        }

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
