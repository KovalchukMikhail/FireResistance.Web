using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
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
    internal class ArmatureForFRFactory : IMaterialFactoryFR <ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {

        public Material Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData, double temperature)
        {
            RequestDb db = provider.GetRequiredService<RequestDb>();
            ArmatureForFR armature = provider.GetRequiredService<ArmatureForFR>();
            armature.ClassName = sourceData.ArmatureClass;
            armature.Diameter = sourceData.ArmatureDiameter;
            armature.Count = sourceData.ArmatureCount;
            armature.Area = db.ArmatureAreaDb.GetArmatureArea(armature.Diameter);
            armature.ResistNormativeForStretch = db.DataSP63Db.GetArmatureResistNormative(armature.ClassName);
            armature.ElasticityModulus = db.DataSP63Db.GetArmatureElasticityModulus(armature.ClassName);
            armature.ResistСalculationForSqueeze = db.DataSP63Db.GetArmatureResistSqueezeСalculation(armature.ClassName);
            armature.ResistСalculationForStretch = db.DataSP63Db.GetArmatureResistStretchСalculation(armature.ClassName);
            return armature;
        }
    }
}
