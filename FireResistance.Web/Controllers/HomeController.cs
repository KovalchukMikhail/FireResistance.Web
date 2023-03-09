using FireResistance.Core;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic;
using FireResistance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FireResistance.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Dictionary<string, string> dictStr = new Dictionary<string, string>()
            {
                {"Предел_огнестойкости", "R120" },
                {"Закрепление_по_концам_элемента", "НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ"},
                {"Класс_арматуры_по_прочности", "A240" },
                {"Вид_бетона", "ТЯЖЕЛЫЙ_НА_СИЛИКАТНОМ_ЗАПОЛНИТЕЛЕ"},
                {"Класс_бетона_по_прочности", "B35"}
            };
            Dictionary<string, double> dictDbl = new Dictionary<string, double>()
            {
                {"Длина_элемента", 5400 },
                {"Высота_элемента", 1200 },
                {"Ширина_элемента", 400 },
                {"Расстояние_от_грани_элемента_до_центра_тяжести_арматуры", 50 },
                {"Диаметр_арматуры", 20 },
                {"Количество_арматуры", 4},
                {"Величина_изгибающего_момента", 10},
                {"Величина_нормальной_силы", 200}
            };


            ColumnFireIsWithFourSidesDataFactory dataFactory = new ColumnFireIsWithFourSidesDataFactory();
            bool check = dataFactory.TryCreate(dictStr, dictDbl, out ColumnFireIsWithFourSidesData<Dictionary<string, string>> data);
            data.Check = true;
            FireResistanceBasic fireResistance = new FireResistanceBasic();
            fireResistance.TryPerformCalculation(data);
            
            ResultAsDictionary result = fireResistance.GetResult();
            string answer = result.GetItemDescription("ответ");


            //string answer = $"Диаметр арматуры{data.ArmatureDiameter}:Количество арматуры{data.ArmatureCount}:Класс арматуры{data.ArmatureClass}:Расположение арматуры{data.ArmatureInstallationDepth}:Тип бетона{data.ConcreteType}:Класс бетона{data.ConcreteClass}:Предел огнестойкости{data.FireResistanceValue}:Момент{data.Moment}:Продольная сила{data.Strength}:Длина колонны{data.LengthColumn}:Высота колонны{data.HighColumn}:Ширина колонны{data.WidthColumn}:закрепление{data.FixationElement}";
            ViewData["Answer"] = answer;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}