using FireResistance.Core.Controllers.ControllerBasic;
using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Data.Implementations.WithOutSql;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic;
using FireResistance.Core.Infrastructure.Formulas;
using FireResistance.Core.Infrastructure.Formulas.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FireResistance.Core.Dependency
{
    internal class DependencyCreator
    {
        private static IServiceCollection services = new ServiceCollection()
            .AddTransient<IDataTemperatureСolumn, TemperatureСolumnWithOutSql>()
            .AddTransient<IDataSP63, DataFromSP63WithOutSql>()
            .AddTransient<IDataSP468, DataFromSP468WithOutSql>()
            .AddTransient<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, ResultAsDictionary>()
            .AddTransient<Armature, ArmatureForFR>()
            .AddTransient<Concrete, ConcreteForFR>()
            .AddTransient<ISp468, Sp468>()
            .AddTransient<ISp63, Sp63>()
            .AddTransient<IMainController<SourceData<Dictionary<string, string>>, IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>, MainController>()
            .AddTransient<IColumnFireIsWithFourSidesResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>, ColumnFireIsWithFourSidesResultBuilder>()
            .AddTransient<CalculatorAbstract<IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>, CalculatorBasic>();

        


        public static ServiceProvider GetServiceProvider()
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }



    }
}
