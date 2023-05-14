using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core;
using FireResistance.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System.Security.Claims;
using FireResistance.Web.Data;

namespace FireResistance.Web.Controllers
{
    [Authorize]
    public class ArchiveController : Controller
    {
        private ApplicationDbContext db;
        public ArchiveController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(GetArchiveVM());
        }

        public IActionResult DeleteDataOfColumn(int id)
        {
            ColumnFireIsWithFourSidesData data = db.ColumnFireIsWithFourSidesData.Find(id);
            db.ColumnFireIsWithFourSidesData.Remove(data);
            db.SaveChanges();
            return View("Index", GetArchiveVM());
        }

        public IActionResult DeleteDataOfSlab(int id)
        {
            SlabWithRigidConnectionData data = db.SlabWithRigidConnectionData.Find(id);
            db.SlabWithRigidConnectionData.Remove(data);
            db.SaveChanges();
            return View("Index", GetArchiveVM());
        }

        private ArchiveVM GetArchiveVM()
        {
            ArchiveVM archiveVM = new ArchiveVM();
            string userId = User.FindFirstValue(ClaimTypes.Name);
            archiveVM.DataForColumn = db.ColumnFireIsWithFourSidesData.Where(c => c.UserId == userId).ToList();
            archiveVM.DataForSlab = db.SlabWithRigidConnectionData.Where(s => s.UserId == userId).ToList();
            return archiveVM;
        }
    }
}
