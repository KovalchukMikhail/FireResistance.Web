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
    public class FireResistanceBasic : IFireResistance<ResultAsDictionary, SourceData<Dictionary<string, string>>>
    {
        private IMainController<SourceData<Dictionary<string, string>>,
                                CalculatorAbstract<IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>> controller;

        CalculatorAbstract<IResultBuilder<ResultAsDictionary,
                            Dictionary<string, double>,
                            Dictionary<string, string>>> calculator;

        public bool TryPerformCalculation(SourceData<Dictionary<string, string>> data)
        {
            using ServiceProvider provider = DependencyCreator.GetServiceProvider();
            controller = provider.GetService<IMainController<SourceData<Dictionary<string, string>>,
                                                        CalculatorAbstract<IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>>>();
            calculator = provider.GetService<CalculatorAbstract<IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>>();
            return controller.Run(data, calculator, provider);
        }

        public ResultAsDictionary GetResult()
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