using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic
{
    internal class ArmatureForFRFactory : IMaterialFactoryFR <SourceData>
    {
        private NameColumns nameColumns;
        private RequestDb db;
        private ArmatureForFR armature;
        private IInterpolator interpolator;
        private IEquationsFromSp468 equations;

        public ArmatureForFRFactory(NameColumns nameColumns, RequestDb db, ArmatureForFR armature, IInterpolator interpolator, IEquationsFromSp468 equations)
        {
            this.nameColumns = nameColumns;
            this.db = db;
            this.armature = armature;
            this.interpolator = interpolator;
            this.equations = equations;
        }

        public Material Create(SourceData sourceData, double temperature)
        {
            armature.ClassName = sourceData.ArmatureClass;
            armature.Diameter = sourceData.ArmatureDiameter;
            armature.Count = sourceData.ArmatureCount;
            armature.Area = db.ArmatureAreaDb.GetArmatureArea(armature.Diameter) * armature.Count;
            armature.ResistNormativeForStretch = db.DataSP63Db.GetArmatureResistNormative(armature.ClassName);
            armature.ElasticityModulus = db.DataSP63Db.GetArmatureElasticityModulus(armature.ClassName);
            armature.ResistСalculationForSqueeze = db.DataSP63Db.GetArmatureResistSqueezeСalculation(armature.ClassName);
            armature.ResistСalculationForStretch = db.DataSP63Db.GetArmatureResistStretchСalculation(armature.ClassName);
            armature.Temperature = temperature;
            try
            {
                armature.BetaS = interpolator.GetValueFromTable(nameColumns.ArmatureClass, nameColumns.TemperatureForTable, armature.ClassName, armature.Temperature, db.DataSP468Db.GetBetaSTable());
                armature.GammaST = interpolator.GetValueFromTable(nameColumns.ArmatureClass, nameColumns.TemperatureForTable, armature.ClassName, armature.Temperature, db.DataSP468Db.GetGammaStTable());
            }catch(Exception)
            {
                throw new Exception("Ошибка произошла при опредилении коэфициентов BetaS и GammaST");
            }
            armature.ResistSqueezeWithTemperatureСalculation = equations.GetRsWithGammaSt(armature.ResistСalculationForSqueeze, armature.GammaST);
            armature.ResistStretchWithTemperatureСalculation = equations.GetRsWithGammaSt(armature.ResistСalculationForStretch, armature.GammaST);
            armature.ResistWithTemperatureNormative = equations.GetRsWithGammaSt(armature.ResistNormativeForStretch, armature.GammaST);
            armature.ElasticityModulusWithWarming = equations.GetEst(armature.ElasticityModulus, armature.BetaS);
            return armature;
        }
    }
}
