using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FireResistance.Core
{
    /// <summary>Класс описывает точку входа для запуска расчета на огнестойкость</summary>
    public class FireResistanceBasic : IFireResistance<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, SourceData>
    {
        private IMainController<SourceData,
                                CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                    Dictionary<string, double>,
                                                    Dictionary<string, string>>>> controller;

        private CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                            Dictionary<string, double>,
                            Dictionary<string, string>>> calculator;
        /// <summary>Метод запускает процесс расчета конструкций на огнестойкость</summary>
        public void PerformCalculation(SourceData data)
        {
            using ServiceProvider provider = DependencyCreator.GetServiceProvider();
            controller = provider.GetService<IMainController<SourceData,
                                                    CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                        Dictionary<string, double>,
                                                                        Dictionary<string, string>>>>>();
            calculator = provider.GetService<CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                Dictionary<string, double>,
                                                                 Dictionary<string, string>>>>();
            controller.Run(data, calculator, provider);
        }
        /// <summary>Метод возвращает ссылку на объект хранящий результаты расчета на огнестойкость</summary>
        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetResult()
        {
            return calculator.ResultBuilder.GetCalculationResult();
        }

    }
}