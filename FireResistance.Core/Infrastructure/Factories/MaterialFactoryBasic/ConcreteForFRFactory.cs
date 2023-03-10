using FireResistance.Core.Data;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic
{
    internal class ConcreteForFRFactory : IMaterialFactoryFR <ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {
        public Material Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData, double temperature)
        {
            RequestDb db = provider.GetService<RequestDb>();
            ConcreteForFR concrete = provider.GetService<ConcreteForFR>();
            concrete.ClassName = sourceData.ConcreteClass;
            concrete.TypeName = sourceData.ConcreteType;
            concrete.StartElasticityModulus = db.DataSP63Db.GetConcreteStartElasticityModulus(concrete.ClassName);
            concrete.ResistNormativeForStretch = db.DataSP63Db.GetConcreteResistNormativeStretch(concrete.ClassName);
            concrete.ResistNormativeForSqueeze = db.DataSP63Db.GetConcreteResistNormativeSqueeze(concrete.ClassName);
            return concrete;
        }
    }
}
