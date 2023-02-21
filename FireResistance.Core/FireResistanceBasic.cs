using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FireResistance.Core
{
    public class FireResistanceBasic : IFireResistance<ResultAsDictionary, SourceData<Dictionary<string, string>>>
    {
        private IMainController<SourceData<Dictionary<string, string>>, IResultBuilder<ResultAsDictionary>> controller;
        private IResultBuilder<ResultAsDictionary> resultBuilder;

        public FireResistanceBasic()
        {
            using ServiceProvider provider = DependencyCreator.GetServiceProvider();
            controller = provider.GetService<IMainController<SourceData<Dictionary<string, string>>, IResultBuilder<ResultAsDictionary>>>();
        }
        public bool TryPerformCalculation(SourceData<Dictionary<string, string>> data)
        {
            return controller.Run(data, resultBuilder);
        }

        public ResultAsDictionary GetResult()
        {
            return resultBuilder.GetCalculationResult();
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