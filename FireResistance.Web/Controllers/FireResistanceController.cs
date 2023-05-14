using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FireResistance.Web.Models.ViewModels;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Web.Data;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return View(GetDataOfColumn(sourceData));
        }

        [HttpPost]
        public IActionResult AddDataForCalculationOfColumn(ColumnFireIsWithFourSidesData sourceData)
        {
            sourceData.UserId = User.FindFirstValue(ClaimTypes.Name);
            sourceData.SaveDate = DateTime.Now.ToString();
            db.ColumnFireIsWithFourSidesData.Add(sourceData);
            db.SaveChanges();
            return View("ColumnFireFourSide", GetDataOfColumn(sourceData));
        }

        public IActionResult LoadColumnFireFourSide(int id)
        {
            ColumnFireIsWithFourSidesData sourceData = db.ColumnFireIsWithFourSidesData.Where(x => x.Id == id).FirstOrDefault();
            return View("ColumnFireFourSide", GetDataOfColumn(sourceData));
        }

        private DataOfColumnFireFourSideVM GetDataOfColumn(ColumnFireIsWithFourSidesData sourceData)
        {
            DataOfColumnFireFourSideVM data = new DataOfColumnFireFourSideVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
            }
            return data;
        }

        [HttpGet]
        public IActionResult SlabWithRigidConnectionToColumns()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SlabWithRigidConnectionToColumns(SlabWithRigidConnectionData sourceData)
        {
            if (sourceData.IsOnCollums == 1) return View(GetDataOfSlab(sourceData));
            else return View("SlabWithRigidConnectionToTwoWalls", GetDataOfSlab(sourceData));
        }

        [HttpGet]
        public IActionResult SlabWithRigidConnectionToTwoWalls()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDataForCalculationOfSlab(SlabWithRigidConnectionData sourceData)
        {
            sourceData.UserId = User.FindFirstValue(ClaimTypes.Name);
            sourceData.SaveDate = DateTime.Now.ToString();
            db.SlabWithRigidConnectionData.Add(sourceData);
            db.SaveChanges();
            if (sourceData.IsOnCollums == 1) return View("SlabWithRigidConnectionToColumns", GetDataOfSlab(sourceData));
            else return View("SlabWithRigidConnectionToTwoWalls", GetDataOfSlab(sourceData));
        }

        public IActionResult LoadSlab(int id)
        {
            SlabWithRigidConnectionData sourceData = db.SlabWithRigidConnectionData.Find(id);
            if (sourceData.IsOnCollums == 1) return View("SlabWithRigidConnectionToColumns", GetDataOfSlab(sourceData));
            else return View("SlabWithRigidConnectionToTwoWalls", GetDataOfSlab(sourceData));
        }

        private DataOfSlabWithRigidConnectionVM GetDataOfSlab(SlabWithRigidConnectionData sourceData)
        {
            DataOfSlabWithRigidConnectionVM data = new DataOfSlabWithRigidConnectionVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
            }
            return data;
        }


    }
}
