using FireResistance.Core.Controllers.ControllerBasic;
using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Data;
using FireResistance.Core.Data.Implementations.WithOutSql;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;
using FireResistance.Core.Infrastructure.Core;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Core.TemperutureFormSp468;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic;
using Microsoft.Extensions.DependencyInjection;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Logger;

namespace FireResistance.Core.Dependency
{
    internal class DependencyCreator
    {
        private static IServiceCollection services = new ServiceCollection()
            .AddTransient<IDataTemperatureOfСolumnRequestDb, TemperatureOfСolumnWithOutSql>()
            .AddTransient<IDataSP63RequestDb, DataFromSP63WithOutSql>()
            .AddTransient<IDataSP468RequestDb, DataFromSP468WithOutSql>()
            .AddTransient<IArmatureAreaRequestDb, ArmatureArea>()
            .AddTransient<IDataSP468RequestDb, DataFromSP468WithOutSql>()
            .AddTransient<IDataSP63RequestDb, DataFromSP63WithOutSql>()
            .AddTransient<IDataTemperatureOfСolumnRequestDb, TemperatureOfСolumnWithOutSql>()
            .AddTransient<IDataTemperatureOfSlabRequestDb, TemperatureOfSlabWithOutSql>()
            .AddTransient<NameColumns>()
            .AddTransient<RequestDb>()
            .AddTransient<ArmatureForFR>()
            .AddTransient<ConcreteForFR>()
            .AddTransient<ArmatureForFRFactory>()
            .AddTransient<ConcreteForFRFactory>()
            .AddTransient<CalculationResult < Dictionary<string, double>, Dictionary<string, string>>, ResultAsDictionary>()
            .AddTransient<IEquationsFromSp468, EquationsFromSp468>()
            .AddTransient<IEquationsFromSp63, EquationsFromSp63>()
            .AddTransient<IIndexDeterminant, IndexDeterminantBasic>()
            .AddTransient<IInterpolator, InterpolatorBasic>()
            .AddTransient<ColumnFactoryFR>()
            .AddTransient<SlabFactoryFR>()
            .AddTransient<IColumnTemperature<ColumnFR>, ColumnTemperatureBasic >()
            .AddTransient<ISlabTemperature<SlabFR, SlabWithRigidConnectionData>, SlabTemperatureBasic>()
            .AddTransient<IEquationsFromSp468, EquationsFromSp468>()
            .AddTransient<IEquationsFromSp63, EquationsFromSp63>()
            .AddTransient<ICommonEquations, CommonEquations>()
            .AddTransient<IColumnFireIsWithFourSidesEquationsManager, ColumnFireIsWithFourSidesEquationsManager>()
            .AddTransient<ISlabWithRigidConnectionEquationsManager, SlabWithRigidConnectionEquationsManager>()
            .AddTransient<IColumnFireIsWithFourSidesResultCreator, ColumnFireIsWithFourSidesResultCreator>()
            .AddTransient<ISlabWithRigidConnectionResultCreator, SlabWithRigidConnectionResultCreator>()
            .AddTransient<TempValuesForColumn>()
            .AddTransient<TempValuesForSlab>()
            .AddTransient<IMainController<SourceData,
                                          CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>,
                                              Dictionary<string, string>>>>, MainController>()
            .AddTransient<IColumnFireIsWithFourSidesResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                    Dictionary<string, double>,
                                                                    Dictionary<string, string>>,
                                                        ColumnFireIsWithFourSidesResultBuilder>()
            .AddTransient<ISlabWithRigidConnectionResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                    Dictionary<string, double>,
                                                                    Dictionary<string, string>>,
                                                        SlabWithRigidConnectionResultBuilder>()
            .AddTransient<CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>,
                                             Dictionary<string, string>>>, CalculatorBasic>()
            .AddTransient<SlabFR>()
            .AddTransient<ColumnFR>()
            .AddTransient<FileLogger>();

        public static ServiceProvider GetServiceProvider()
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }



    }
}
