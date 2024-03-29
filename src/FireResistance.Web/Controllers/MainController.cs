﻿using FireResistance.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FireResistance.Logger;


namespace FireResistance.Web.Controllers
{
    public class MainController : Controller
    {
        FileLogger logger;

        public MainController(FileLogger logger)
        {
            this.logger = logger;
        }
        /// <summary>Метод для обработки get запроса</summary>
        /// <returns>Возвращаемый тип IActionResult. Возвращает представление Index</returns>
        [HttpGet]
        public IActionResult Index()
        {
            AddLog();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>Добавляет новую запись в logger</summary>
        private void AddLog()
        {
            string log = $"User:{User.Identity.Name}; DateTime:{DateTime.Now}; Obj: {this}";
            logger.AddLog(log);
        }
    }
}