﻿using EquationsFromSp.Interfaces;
using FireResistance.Core.Data;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;

namespace FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic
{
    /// <summary>Класс описывает фабричные методы для создания объекта бетона класса Material</summary>
    internal class ConcreteForFRFactory : IMaterialFactoryFR <SourceData>
    {
        private NameColumns nameColumns;
        private RequestDb db;
        private IInterpolator interpolator;
        private IEquationsFromSp468 equations;


        public ConcreteForFRFactory(NameColumns nameColumns, RequestDb db, IInterpolator interpolator, IEquationsFromSp468 equations)
        {
            this.nameColumns = nameColumns;
            this.db = db;
            this.interpolator = interpolator;
            this.equations = equations;
        }
        /// <summary>Метод создает экземпляр бетона класса Material на основании переданных в качестве исходных данных параметров</summary>
        /// <returns>Возвращаемый тип Material.</returns>
        public Material Create(SourceData sourceData, double temperature)
        {
            ConcreteForFR concrete = new ConcreteForFR();
            concrete.ClassName = sourceData.ConcreteClass;
            concrete.TypeName = sourceData.ConcreteType;
            concrete.StartElasticityModulus = db.DataSP63Db.GetConcreteStartElasticityModulus(concrete.ClassName);
            concrete.ResistNormativeForStretch = db.DataSP63Db.GetConcreteResistNormativeStretch(concrete.ClassName);
            concrete.ResistNormativeForSqueeze = db.DataSP63Db.GetConcreteResistNormativeSqueeze(concrete.ClassName);
            concrete.Temperature = temperature;
            try
            {
                concrete.BetaB = interpolator.GetValueFromTable(nameColumns.ConcreteType, nameColumns.TemperatureForTable, concrete.TypeName, concrete.Temperature, db.DataSP468Db.GetBetaBTable());
            }
            catch (Exception)
            {
                throw new Exception("Ошибка произошла при опредилении коэфициентов BetaB.");
            }
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