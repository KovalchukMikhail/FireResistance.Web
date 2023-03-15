using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
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
        private ColumnFR column;
        private ServiceProvider provider;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }

        public void SetSourceData(SourceData<Dictionary<string, string>> sourceData, ServiceProvider provider)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData<Dictionary<string, string>>;
            this.provider = provider;
        }

        public bool BuildConstructions()
        {
            ColumnFactoryFR columnFactory = provider.GetRequiredService<ColumnFactoryFR>();
            column = columnFactory.Create(provider, sourceData) as ColumnFR;
            return true;
            
        }

        public bool BuildCalculation()
        {
            IEquationsFromSp468 equationsSp468 = provider.GetRequiredService<IEquationsFromSp468>();
            IEquationsFromSp63 equationsSp63 = provider.GetRequiredService<IEquationsFromSp63>();
            double e0 = equationsSp63.Gete0(false, column.Moment, column.Strength, column.Length, column.Height);

        }

        protected void BuildResult()
        {
           
        }

        public ResultAsDictionary GetCalculationResult()
        {
            return result;
        }

    }
}
