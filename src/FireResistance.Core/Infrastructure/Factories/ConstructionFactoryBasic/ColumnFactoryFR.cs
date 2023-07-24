using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using EquationsFromSp.Interfaces;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    /// <summary>Класс описывает фабричные методы для создания объекта колонны класса ColumnFR</summary>
    internal class ColumnFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData>
    {
        private NameColumns nameColumns;
        private RequestDb db;
        private ColumnFR column;
        private IInterpolator interpolator;
        private IEquationsFromSp468 equationsSp468;
        private ICommonEquations commonEquation;
        private IColumnTemperature<ColumnFR> columnTemperature;
        ArmatureForFRFactory armatureFactory;
        ConcreteForFRFactory concreteFactory;

        public ColumnFactoryFR(NameColumns nameColumns,
                                RequestDb db,
                                ColumnFR column,
                                IInterpolator interpolator,
                                IEquationsFromSp468 equationsSp468,
                                ICommonEquations commonEquation,
                                IColumnTemperature<ColumnFR> columnTemperature,
                                ArmatureForFRFactory armatureFactory,
                                ConcreteForFRFactory concreteFactory)
        {                                                            
            this.nameColumns = nameColumns;
            this.db = db;
            this.column = column;
            this.interpolator = interpolator;
            this.equationsSp468 = equationsSp468;
            this.commonEquation = commonEquation;
            this.columnTemperature = columnTemperature;
            this.armatureFactory = armatureFactory;
            this.concreteFactory = concreteFactory;
        }
        /// <summary>Метод создает экземпляр колонны класса Construction на основании переданных в качестве исходных данных параметров</summary>
        /// <returns>Возвращаемый тип Construction.</returns>
        public virtual Construction Create(ColumnFireIsWithFourSidesData sourceData)
        {
            column.Width = sourceData.WidthColumn;
            column.Height = sourceData.HeighColumn;
            column.Length = sourceData.LengthColumn;
            column.DistanceToArmature = sourceData.ArmatureInstallationDepth;
            column.FireResistanceVolume = sourceData.FireResistanceValue;
            column.FixationElement = sourceData.FixationElement;
            column.Moment = sourceData.Moment;
            column.Strength = sourceData.Strength;
            double minSize = Math.Min(column.Width, column.Height);
            column.DeepConcreteWarming = interpolator.GetValueFromTable(nameColumns.FireResistanceForCriticalTemperature,
                                                                        nameColumns.SizeForCriticalTemperature,
                                                                        column.FireResistanceVolume,
                                                                        Math.Min(minSize, nameColumns.SizeForCriticalTemperature[nameColumns.SizeForCriticalTemperature.Count - 1]),
                                                                        db.TemperatureOfColumnDb.GetTableOfDeepWarmingToCriticalTemperatureForСolumn(sourceData.ConcreteType));
            column.WorkHeight = commonEquation.GetWorkHeight(column.Height, column.DistanceToArmature);
            column.СoefficientFixationElement = db.DataSP468Db.GetСoefficientFixationElement(column.FixationElement);
            column.WorkLenth = commonEquation.GetWorkLenth(column.Length, column.СoefficientFixationElement);
            column.HeightProfileWithWarming = equationsSp468.GetHtFireFourSides(column.Height, column.DeepConcreteWarming);
            column.WidthProfileWithWarming = equationsSp468.GetHtFireFourSides(column.Width, column.DeepConcreteWarming);
            column.WorkWidthWithWarming = equationsSp468.GetHtFireFourSides(column.Width, column.DeepConcreteWarming);
            column.AreaChangedProfile = equationsSp468.GetAredColumnFourSides(column.Height, column.Width, column.DeepConcreteWarming);
            column.WorkHeightProfileWithWarming = equationsSp468.GetH0tWithFire(column.WorkHeight, column.DeepConcreteWarming);
            column.DistanceFromBringToPointAverageTemperature = equationsSp468.GetDistanceFromBringToPointAverageTemperatureForColumn(column.WorkHeightProfileWithWarming, column.DeepConcreteWarming);
            SetMaterials(column, sourceData, db); 
            return column;
        }
        /// <summary>Метод переопределяет данные о материалах в экземпляре класса ColumnFR</summary>
        /// <returns>Возвращаемый тип ColumnFR.</returns>
        public virtual ColumnFR OverrideColumn(ColumnFireIsWithFourSidesData sourceData, ColumnFR column, double xt, double KsiR)
        {
            column.DistanceFromBringToPointAverageTemperature = equationsSp468.GetDistanceFromBringToPointAverageTemperatureForColumn(column.WorkHeightProfileWithWarming, column.DeepConcreteWarming, xt, KsiR);
            SetMaterials(column, sourceData, db);
            return column;
        }
        /// <summary>Метод устанавливает материалы в экземпляр класса ColumnFR на основании переданных исходных данных</summary>
        protected virtual void SetMaterials(ColumnFR column, ColumnFireIsWithFourSidesData sourceData, RequestDb db)
        {
            double temperatureArmature = columnTemperature.GetArmatureTemperature(column);
            double criticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(sourceData.ConcreteType);
            double temperatureConcrete = columnTemperature.GetConcreteTemperature(column, criticalTemperature);
            column.ArmatureFR = armatureFactory.Create(sourceData, temperatureArmature) as ArmatureForFR;
            column.ConcreteFR = concreteFactory.Create(sourceData, temperatureConcrete) as ConcreteForFR; 
        }
    }

}
