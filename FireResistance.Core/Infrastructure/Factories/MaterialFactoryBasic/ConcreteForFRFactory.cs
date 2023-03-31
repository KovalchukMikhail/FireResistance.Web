using FireResistance.Core.Data;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic
{
    internal class ConcreteForFRFactory : IMaterialFactoryFR <ColumnFireIsWithFourSidesData>
    {
        private NameColumns nameColumns;

        public ConcreteForFRFactory(NameColumns nameColumns)
        {
            this.nameColumns = nameColumns;
        }
        public Material Create(ServiceProvider provider, ColumnFireIsWithFourSidesData sourceData, double temperature)
        {
            RequestDb db = provider.GetService<RequestDb>();
            ConcreteForFR concrete = provider.GetService<ConcreteForFR>();
            IInterpolator interpolator = provider.GetRequiredService<IInterpolator>();
            IEquationsFromSp468 equations = provider.GetRequiredService<IEquationsFromSp468>();
            concrete.ClassName = sourceData.ConcreteClass;
            concrete.TypeName = sourceData.ConcreteType;
            concrete.StartElasticityModulus = db.DataSP63Db.GetConcreteStartElasticityModulus(concrete.ClassName);
            concrete.ResistNormativeForStretch = db.DataSP63Db.GetConcreteResistNormativeStretch(concrete.ClassName);
            concrete.ResistNormativeForSqueeze = db.DataSP63Db.GetConcreteResistNormativeSqueeze(concrete.ClassName);
            concrete.Temperature = temperature;
            concrete.BetaB = interpolator.GetValueFromTable(nameColumns.ConcreteType, nameColumns.TemperatureForTable, concrete.TypeName, concrete.Temperature, db.DataSP468Db.GetBetaBTable());
            //concrete.GammaBT = interpolator.GetValueFromTable(NameColumns.ConcreteType, NameColumns.TemperatureForTable, concrete.TypeName, concrete.Temperature, db.DataSP468Db.GetGammaBtTable());
            concrete.GammaBT = 1; // See point 8.3
            concrete.ResistWithTemperatureNormativeForSqueeze = equations.GetRbWithGammaBt(concrete.ResistNormativeForSqueeze, concrete.GammaBT);
            concrete.CriticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(concrete.TypeName);
            concrete.ElasticityModulusWithWarming = equations.GetEbt(concrete.StartElasticityModulus, concrete.BetaB);
            return concrete;
        }
    }
}