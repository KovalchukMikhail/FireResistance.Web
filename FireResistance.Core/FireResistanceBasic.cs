using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FireResistance.Core
{
    public class FireResistanceBasic : IFireResistance<ResultAsDictionary>
    {
        public SourceData SourceData { get; }
        //public FireResistanceBasic(SourceData sourceData)
        //{
        //    SourceData = sourceData;
        //    ServiceProvider Provider = DependencyCreator.GetProvider();
        //}
        public void PerformCalculation()
        {
            throw new NotImplementedException();
        }
        public ResultAsDictionary GetResult()
        {
            throw new NotImplementedException();
        }

        public string GetResultString()
        {
            //using ServiceProvider ServiceProvider = DependencyCreator.GetProvider();
            using ServiceProvider Provider = DependencyCreator.GetServiceProvider();
            IDataTemperatureСolumn dataTemperature = Provider.GetService<IDataTemperatureСolumn>();
            IDataSP63 dataSP63 = Provider.GetService<IDataSP63>();
            double num1 = dataSP63.GetArmatureResistSqueezeСalculation("A240");
            double num = dataTemperature.GetTemperatureOfСolumn("R90", 200, 40);
            return num.ToString() + "  " + "A240" + num1.ToString();
        }
    }
}