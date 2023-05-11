using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FireResistance.Web.Models.ViewModels;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Web.Data;

namespace FireResistance.Web.Controllers
{
    public class FireResistanceController : Controller
    {
        private ApplicationDbContext db;
        public FireResistanceController(ApplicationDbContext db)
        {
            this.db = db;
        }
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
                db.ColumnFireIsWithFourSidesData.Add(sourceData);
                db.SaveChanges();
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult SlabWithRigidConnectionToColumns()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SlabWithRigidConnectionToColumns(SlabWithRigidConnectionData sourceData)
        {
            DataOfSlabWithRigidConnectionVM data = new DataOfSlabWithRigidConnectionVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult SlabWithRigidConnectionToTwoWalls()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SlabWithRigidConnectionToTwoWalls(SlabWithRigidConnectionData sourceData)
        {
            DataOfSlabWithRigidConnectionVM data = new DataOfSlabWithRigidConnectionVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
            }
            return View(data);
        }

    }
}
