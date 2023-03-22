using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;
using FireResistance.Core.Infrastructure.Core.TemperutureFormSp468;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using System.Data.Common;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactory
{
    internal class ColumnFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData>
    {
        public virtual Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData sourceData)
        {
            RequestDb db = provider.GetService<RequestDb>();
            ColumnFR column = provider.GetRequiredService<ColumnFR>();
            IInterpolator interpolator = provider.GetService<IInterpolator>();
            IEquationsFromSp468 equationsSp468 = provider.GetRequiredService<IEquationsFromSp468>();
            ICommonEquations commonEquation = provider.GetRequiredService<ICommonEquations>();
            column.Width = sourceData.WidthColumn;
            column.Height = sourceData.HeighColumn;
            column.Length = sourceData.LengthColumn;
            column.DistanceToArmature = sourceData.ArmatureInstallationDepth;
            column.FireResistanceVolume = sourceData.FireResistanceValue;
            column.FixationElement = sourceData.FixationElement;
            column.Moment = sourceData.Moment;
            column.Strength = sourceData.Strength;
            double minSize = Math.Min(column.Width, column.Height);
            column.DeepConcreteWarming = interpolator.GetValueFromTable(NameColumns.FireResistanceForCriticalTemperature,
                                                                        NameColumns.SizeForCriticalTemperature,
                                                                        column.FireResistanceVolume,
                                                                        Math.Min(minSize, NameColumns.SizeForCriticalTemperature[NameColumns.SizeForCriticalTemperature.Count - 1]),
                                                                        db.TemperatureDb.GetTableOfDeepWarmingToCriticalTemperatureForСolumn(sourceData.ConcreteType));
            column.WorkHeight = commonEquation.GetWorkHeight(column.Height, column.DistanceToArmature);
            column.СoefficientFixationElement = db.DataSP468Db.GetСoefficientFixationElement(column.FixationElement);
            column.WorkLenth = commonEquation.GetWorkLenth(column.Length, column.СoefficientFixationElement);
            column.HeightProfileWithWarming = equationsSp468.GetHtFireFourSides(column.Height, column.DeepConcreteWarming);
            column.WidthProfileWithWarming = equationsSp468.GetHtFireFourSides(column.Width, column.DeepConcreteWarming);
            column.WorkWidthWithWarming = equationsSp468.GetHtFireFourSides(column.Width, column.DeepConcreteWarming);
            column.AreaChangedProfile = equationsSp468.GetAredColumnFourSides(column.Height, column.Width, column.DeepConcreteWarming);
            column.WorkHeightProfileWithWarming = equationsSp468.GetH0tFireFourSides(column.WorkHeight, column.DeepConcreteWarming);
            column.DistanceFromBringToPointAverageTemperature = equationsSp468.GetDistanceFromBringToPointAverageTemperatureForColumn(column.WorkHeightProfileWithWarming);
            SetMaterials(column, provider, sourceData, db); 
            return column;
        }

        public virtual ColumnFR OverrideColumn(ServiceProvider provider, ColumnFireIsWithFourSidesData sourceData, ColumnFR column, double xt, double KsiR)
        {
            RequestDb db = provider.GetService<RequestDb>();
            IEquationsFromSp468 equations = provider.GetRequiredService<IEquationsFromSp468>();
            column.DistanceFromBringToPointAverageTemperature = equations.GetDistanceFromBringToPointAverageTemperatureForColumn(column.WorkHeightProfileWithWarming, xt, KsiR);
            SetMaterials(column, provider, sourceData, db);
            return column;
        }

        protected virtual void SetMaterials(ColumnFR column, ServiceProvider provider, ColumnFireIsWithFourSidesData sourceData, RequestDb db)
        {
            ColumnTemperature columnTemperature = provider.GetRequiredService<ColumnTemperature>();
            double temperatureArmature = columnTemperature.GetArmatureTemperature(column);
            double criticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(sourceData.ConcreteType);
            double TemperatureConcrete = columnTemperature.GetConcreteTemperature(column, criticalTemperature);
            ArmatureForFRFactory armatureFactory = provider.GetRequiredService<ArmatureForFRFactory>();
            ConcreteForFRFactory concreteFactory = provider.GetRequiredService<ConcreteForFRFactory>();
            column.ArmatureFR = armatureFactory.Create(provider, sourceData, temperatureArmature) as ArmatureForFR;
            column.ConcreteFR = concreteFactory.Create(provider, sourceData, TemperatureConcrete) as ConcreteForFR; 
        }
    }

}
