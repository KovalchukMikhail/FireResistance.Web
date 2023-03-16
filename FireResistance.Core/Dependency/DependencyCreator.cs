using FireResistance.Core.Controllers.ControllerBasic;
using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Data;
using FireResistance.Core.Data.Implementations.WithOutSql;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;
using FireResistance.Core.Infrastructure.Core;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Core.TemperutureFormSp468;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic;
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
            .AddTransient<IDataTemperatureСolumnRequestDb, TemperatureСolumnWithOutSql>()
            .AddTransient<IDataSP63RequestDb, DataFromSP63WithOutSql>()
            .AddTransient<IDataSP468RequestDb, DataFromSP468WithOutSql>()
            .AddTransient<IArmatureAreaRequestDb, ArmatureArea>()
            .AddTransient<IDataSP468RequestDb, DataFromSP468WithOutSql>()
            .AddTransient<IDataSP63RequestDb, DataFromSP63WithOutSql>()
            .AddTransient<IDataTemperatureСolumnRequestDb, TemperatureСolumnWithOutSql>()
            .AddTransient<RequestDb>()
            .AddTransient<ArmatureForFR>()
            .AddTransient<ConcreteForFR>()
            .AddTransient<ArmatureForFRFactory>()
            .AddTransient<ConcreteForFRFactory>()
            .AddTransient<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, ResultAsDictionary>()
            .AddTransient<IEquationsFromSp468, EquationsFromSp468>()
            .AddTransient<IEquationsFromSp63, EquationsFromSp63>()
            .AddTransient<IMainController<SourceData<Dictionary<string, string>>,
                                                        CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                                                            ResultAsDictionary, Dictionary<string, double>,
                                                            Dictionary<string, string>>>>, MainController>()
            .AddTransient<IColumnFireIsWithFourSidesResultBuilder<Dictionary<string, string>,
                                                                    ResultAsDictionary,
                                                                    Dictionary<string, double>,
                                                                    Dictionary<string, string>>, ColumnFireIsWithFourSidesResultBuilder>()
            .AddTransient<CalculatorAbstract<IResultBuilder<Dictionary<string, string>,
                                             ResultAsDictionary, Dictionary<string, double>,
                                             Dictionary<string, string>>>, CalculatorBasic>()
            .AddTransient<SlabFR>()
            .AddTransient<ColumnFR>()
            .AddTransient<WallFR>()
            .AddTransient<IIndexDeterminant, IndexDeterminantBasic>()
            .AddTransient<IInterpolator, InterpolatorBasic>()
            .AddTransient<ColumnFactoryFR>()
            .AddTransient<ColumnTemperature>()
            .AddTransient<IEquationsFromSp468, EquationsFromSp468>()
            .AddTransient<IEquationsFromSp63, EquationsFromSp63>()
            .AddTransient<ICommonEquations, CommonEquations>();


        

        public static ServiceProvider GetServiceProvider()
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }



    }
}
