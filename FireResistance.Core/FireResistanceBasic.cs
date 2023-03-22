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
    public class FireResistanceBasic : IFireResistance<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, SourceData<Dictionary<string, string>>>
    {
        private IMainController<SourceData<Dictionary<string, string>>,
                                CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                                                    CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                    Dictionary<string, double>,
                                                    Dictionary<string, string>>>> controller;

        private CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                            CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                            Dictionary<string, double>,
                            Dictionary<string, string>>> calculator;

        public bool TryPerformCalculation(SourceData<Dictionary<string, string>> data)
        {
            using ServiceProvider provider = DependencyCreator.GetServiceProvider();
            controller = provider.GetService<IMainController<SourceData<Dictionary<string, string>>,
                                                    CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                                                                        CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                        Dictionary<string, double>,
                                                                        Dictionary<string, string>>>>>();
            calculator = provider.GetService<CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                                                                CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                Dictionary<string, double>,
                                                                 Dictionary<string, string>>>>();
            return controller.Run(data, calculator, provider);
        }

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetResult()
        {
            return calculator.ResultBuilder.GetCalculationResult();
        }

        //public string GetResultString()
        //{
        //    using ServiceProvider Provider = DependencyCreator.GetServiceProvider();
        //    IDataTemperatureСolumn dataTemperature = Provider.GetService<IDataTemperatureСolumn>();
        //    IDataSP63 dataSP63 = Provider.GetService<IDataSP63>();
        //    double num1 = dataSP63.GetArmatureResistSqueezeСalculation("A240");
        //    double num = dataTemperature.GetTemperatureOfСolumn("R90", 200, 40);
        //    return num.ToString() + "  " + "A240" + num1.ToString();
        //}
    }
}