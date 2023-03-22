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
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string valueOfFireResistance, string fixationElement, string armatureClass, string concreteType, string concreteClass, double lenth, double heigh, double width, double armatureInstallationDepth, double armatureDiameter, double armatureCount, double moment, double strength)
        {
            Dictionary<string, string> dictStr = new Dictionary<string, string>()
            {
                {"Предел_огнестойкости", valueOfFireResistance },
                {"Закрепление_по_концам_элемента", fixationElement},
                {"Класс_арматуры_по_прочности", armatureClass },
                {"Вид_бетона", concreteType},
                {"Класс_бетона_по_прочности", concreteClass}
            };
            Dictionary<string, double> dictDbl = new Dictionary<string, double>()
            {
                {"Длина_элемента", lenth },
                {"Высота_элемента", heigh },
                {"Ширина_элемента", width },
                {"Расстояние_от_грани_элемента_до_центра_тяжести_арматуры", armatureInstallationDepth },
                {"Диаметр_арматуры", armatureDiameter },
                {"Количество_арматуры", armatureCount},
                {"Величина_изгибающего_момента", moment},
                {"Величина_нормальной_силы", strength}
            };


            ColumnFireIsWithFourSidesDataFactory dataFactory = new ColumnFireIsWithFourSidesDataFactory();
            bool check = dataFactory.TryCreate(dictStr, dictDbl, out ColumnFireIsWithFourSidesData<Dictionary<string, string>> data);
            data.Check = true; //!!!!!!!!!!!!!!!!!!!!!!!
            FireResistanceBasic fireResistance = new FireResistanceBasic();
            fireResistance.TryPerformCalculation(data);

            ResultAsDictionary result = fireResistance.GetResult() as ResultAsDictionary;
            string[] str = result.ToString().Split("\n");
            return View(str);
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