using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FireResistance.Core
{
    public class FireResistanceBasic : IFireResistance<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, SourceData>
    {
        private IMainController<SourceData,
                                CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                    Dictionary<string, double>,
                                                    Dictionary<string, string>>>> controller;

        private CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                            Dictionary<string, double>,
                            Dictionary<string, string>>> calculator;

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

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetResult()
        {
            return calculator.ResultBuilder.GetCalculationResult();
        }

    }
}