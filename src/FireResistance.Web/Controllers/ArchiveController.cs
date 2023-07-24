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
        /// <summary>Метод для обработки get запроса</summary>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление Index в котором содержатся данные о сохранненых расчетах (объект класса ArchiveVM)</returns>
        [HttpGet]
        public IActionResult Index()
        {
            AddLog();
            return View(GetArchiveVM());
        }
        /// <summary>Метод удаляет из базы данных данные о расчете колонны на огнечтойкость в соответсвии с переданным id</summary>
        /// <param name="id">Уникальный id строки в таблице ColumnFireIsWithFourSidesData (содержит расчетные данные для расчета колонн на огнестойкость)</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление Index в котором содержатся данные о сохранненых расчетах (объект класса ArchiveVM)</returns>
        public IActionResult DeleteDataOfColumn(int id)
        {
            ColumnFireIsWithFourSidesData data = db.ColumnFireIsWithFourSidesData.Find(id);
            db.ColumnFireIsWithFourSidesData.Remove(data);
            db.SaveChanges();
            return View("Index", GetArchiveVM());
        }
        /// <summary>Метод удаляет из базы данных данные о расчете плиты перекрытия на огнечтойкость в соответсвии с переданным id</summary>
        /// <param name="id">Уникальный id строки в таблице SlabWithRigidConnectionData (содержит расчетные данные для расчета плиты перекрытия на огнестойкость)</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление Index в котором содержатся данные о сохранненых расчетах (объект класса ArchiveVM)</returns>
        public IActionResult DeleteDataOfSlab(int id)
        {
            SlabWithRigidConnectionData data = db.SlabWithRigidConnectionData.Find(id);
            db.SlabWithRigidConnectionData.Remove(data);
            db.SaveChanges();
            return View("Index", GetArchiveVM());
        }
        /// <summary>Возвращает объект класса ArchiveVM в котором содержаться все расчетные данные сохраненные конкретным пользователем</summary>
        /// <returns>Возвращаемый тип ArchiveVM.</returns>
        private ArchiveVM GetArchiveVM()
        {
            AddLog();
            ArchiveVM archiveVM = new ArchiveVM();
            string userId = User.FindFirstValue(ClaimTypes.Name);
            archiveVM.DataForColumn = db.ColumnFireIsWithFourSidesData.Where(c => c.UserId == userId).ToList();
            archiveVM.DataForSlab = db.SlabWithRigidConnectionData.Where(s => s.UserId == userId).ToList();
            return archiveVM;
        }
        /// <summary>Добавляет новую запись в logger</summary>
        private void AddLog()
        {
            string log = $"User:{User.Identity.Name}; DateTime:{DateTime.Now}; Obj:{this}";
            logger.AddLog(log);
        }
    }
}
