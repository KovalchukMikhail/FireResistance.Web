using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<Dictionary<string, string>, ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>
    {
        private ResultAsDictionary result;
        private ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData;
        ArmatureForFR armature;
        ConcreteForFR concrete;
        Column column;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }

        public void SetSourceData(SourceData<Dictionary<string, string>> sourceData)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData<Dictionary<string, string>>;
        }

        public bool BuildConstructions(ServiceProvider provider)
        {
            IMaterialFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>> factory
                            = provider.GetRequiredService<IArmatureFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>>();
            armature = factory.Create(provider, this.sourceData) as ArmatureForFR;

            factory = provider.GetRequiredService<IConcreteFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>>();
            concrete = factory.Create(provider, this.sourceData) as ConcreteForFR;

            column = provider.GetRequiredService<Column>();
            result.AddItemDescription("ответ",column.ToString());

            return true;
            
        }

        public bool BuildSourceValues()
        {
            return true;
        }

        public bool BuildCalculation()
        {
            return true;
        }

        public ResultAsDictionary GetCalculationResult()
        {
            return result;
        }

    }
}
