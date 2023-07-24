using FireResistance.Core.Entities.Calculations;
using FireResistance.Core;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using Microsoft.AspNetCore.Mvc;
using FireResistance.Web.Models.ViewModels;
using FireResistance.Web.Data;
using System.Security.Claims;
using FireResistance.Logger;

namespace FireResistance.Web.Controllers
{
    public class FireResistanceController : Controller
    {
        private ApplicationDbContext db;
        private FileLogger logger;
        public FireResistanceController(ApplicationDbContext db, FileLogger logger)
        {
            this.db = db;
            this.logger = logger;
        }
        /// <summary>Метод для обработки get запроса</summary>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление ColumnFireFourSide</returns>
        [HttpGet]
        public IActionResult ColumnFireFourSide()
        {
            AddLog();
            return View();
        }
        /// <summary>Метод для обработки post запроса. Передает данные для расчета колонны на огнестойкость.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса ColumnFireIsWithFourSidesData</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление ColumnFireFourSide в котором содержатся данные о расчете и результатах расчтета колонны на огнестойксть (объект класса DataOfColumnFireFourSideVM)</returns>
        [HttpPost]
        public IActionResult ColumnFireFourSide(ColumnFireIsWithFourSidesData sourceData)
        {
            return View(GetDataOfColumn(sourceData));
        }
        /// <summary>Метод для обработки post запроса. Сохраняет исходные данные для расчета колонны на огнестойкость в базу данных.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса ColumnFireIsWithFourSidesData</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление ColumnFireFourSide в котором содержатся данные о расчете и результатах расчтета колонны на огнестойксть (объект класса DataOfColumnFireFourSideVM)</returns>
        [HttpPost]
        public IActionResult AddDataForCalculationOfColumn(ColumnFireIsWithFourSidesData sourceData)
        {
            sourceData.UserId = User.FindFirstValue(ClaimTypes.Name);
            sourceData.SaveDate = DateTime.Now.ToString();
            db.ColumnFireIsWithFourSidesData.Add(sourceData);
            db.SaveChanges();
            return View("ColumnFireFourSide", GetDataOfColumn(sourceData));
        }
        /// <summary>Метод загружает из базы данных исходные данные для выполнения расчета на огнстойкость.</summary>
        /// <param name="id">Уникальный id строки в таблице ColumnFireIsWithFourSidesData (содержит расчетные данные для расчета колонн на огнестойкость)</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление ColumnFireFourSide в котором содержатся данные о расчете и результатах расчтета колонны на огнестойксть (объект класса DataOfColumnFireFourSideVM)</returns>
        public IActionResult LoadColumnFireFourSide(int id)
        {
            ColumnFireIsWithFourSidesData sourceData = db.ColumnFireIsWithFourSidesData.Where(x => x.Id == id).FirstOrDefault();
            return View("ColumnFireFourSide", GetDataOfColumn(sourceData));
        }
        /// <summary>Метод после проверки на валидность переданных параметров запускает выполнение расчета колонны на огнестойкость.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса ColumnFireIsWithFourSidesData</param>
        /// <returns>Возвращаемый тип DataOfColumnFireFourSideVM. Объект класса DataOfColumnFireFourSideVM содержит исходные данные и результаты расчета колонны на огнестойкость</returns>
        private DataOfColumnFireFourSideVM GetDataOfColumn(ColumnFireIsWithFourSidesData sourceData)
        {
            AddLog();
            DataOfColumnFireFourSideVM data = new DataOfColumnFireFourSideVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
                AddLog(data.SourceData.ToString());
            }
            return data;
        }
        /// <summary>Метод для обработки get запроса</summary>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление SlabWithRigidConnectionToColumns</returns>
        [HttpGet]
        public IActionResult SlabWithRigidConnectionToColumns()
        {
            AddLog();
            return View();
        }
        /// <summary>Метод для обработки post запроса. Передает данные для расчета плиты перекрытия на огнестойкость.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса SlabWithRigidConnectionData</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление SlabWithRigidConnectionToColumns в котором содержатся данные о расчете и результатах расчтета плиты перекрытия на огнестойксть (объект класса DataOfSlabWithRigidConnectionVM)</returns>
        [HttpPost]
        public IActionResult SlabWithRigidConnectionToColumns(SlabWithRigidConnectionData sourceData)
        {
            if (sourceData.IsOnCollums == 1) return View(GetDataOfSlab(sourceData));
            else return View("SlabWithRigidConnectionToTwoWalls", GetDataOfSlab(sourceData));
        }
        /// <summary>Метод для обработки get запроса</summary>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление SlabWithRigidConnectionToTwoWalls</returns>
        [HttpGet]
        public IActionResult SlabWithRigidConnectionToTwoWalls()
        {
            AddLog();
            return View();
        }
        /// <summary>Метод для обработки post запроса. Сохраняет исходные данные для расчета плиты перекрытия на огнестойкость в базу данных.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса SlabWithRigidConnectionData</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление SlabWithRigidConnectionToTwoWalls в котором содержатся данные о расчете и результатах расчтета колонны на огнестойксть (объект класса DataOfSlabWithRigidConnectionVM)</returns>
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
        /// <summary>Метод загружает из базы данных исходные данные для выполнения расчета на огнстойкость.</summary>
        /// <param name="id">Уникальный id строки в таблице SlabWithRigidConnectionData (содержит расчетные данные для расчета плиты перекрытия на огнестойкость)</param>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление SlabWithRigidConnectionToTwoWalls в котором содержатся данные о расчете и результатах расчтета колонны на огнестойксть (объект класса DataOfSlabWithRigidConnectionVM)</returns>
        public IActionResult LoadSlab(int id)
        {
            SlabWithRigidConnectionData sourceData = db.SlabWithRigidConnectionData.Find(id);
            if (sourceData.IsOnCollums == 1) return View("SlabWithRigidConnectionToColumns", GetDataOfSlab(sourceData));
            else return View("SlabWithRigidConnectionToTwoWalls", GetDataOfSlab(sourceData));
        }
        /// <summary>Метод после проверки на валидность переданных параметров запускает выполнение расчета плиты перекрытия на огнестойкость.</summary>
        /// <param name="sourceData">Исходные данные для выполнения расчетов. Объект класса SlabWithRigidConnectionData</param>
        /// <returns>Возвращаемый тип DataOfSlabWithRigidConnectionVM. Объект класса DataOfSlabWithRigidConnectionVM содержит исходные данные и результаты расчета плиты перекрытия на огнестойкость</returns>
        private DataOfSlabWithRigidConnectionVM GetDataOfSlab(SlabWithRigidConnectionData sourceData)
        {
            DataOfSlabWithRigidConnectionVM data = new DataOfSlabWithRigidConnectionVM(sourceData);
            if (ModelState.IsValid)
            {
                FireResistanceBasic fireResistance = new FireResistanceBasic();
                fireResistance.PerformCalculation(sourceData);
                data.Result = fireResistance.GetResult() as ResultAsDictionary;
                AddLog(data.SourceData.ToString());
            }
            return data;
        }
        /// <summary>Добавляет новую запись в logger</summary>
        private void AddLog(string text = "")
        {
            string log = $"User:{User.Identity.Name}; DateTime:{DateTime.Now}; Obj:{this}; info:{text}";
            logger.AddLog(log);
        }
    }
}
