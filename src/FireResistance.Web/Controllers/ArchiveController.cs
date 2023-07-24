using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FireResistance.Web.Data;
using FireResistance.Logger;

namespace FireResistance.Web.Controllers
{
    [Authorize]
    public class ArchiveController : Controller
    {
        private ApplicationDbContext db;
        private FileLogger logger;
        public ArchiveController(ApplicationDbContext db, FileLogger logger)
        {
            this.db = db;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            AddLog();
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
            AddLog();
            ArchiveVM archiveVM = new ArchiveVM();
            string userId = User.FindFirstValue(ClaimTypes.Name);
            archiveVM.DataForColumn = db.ColumnFireIsWithFourSidesData.Where(c => c.UserId == userId).ToList();
            archiveVM.DataForSlab = db.SlabWithRigidConnectionData.Where(s => s.UserId == userId).ToList();
            return archiveVM;
        }
        private void AddLog()
        {
            string log = $"User:{User.Identity.Name}; DateTime:{DateTime.Now}; Obj:{this}";
            logger.AddLog(log);
        }
    }
}
