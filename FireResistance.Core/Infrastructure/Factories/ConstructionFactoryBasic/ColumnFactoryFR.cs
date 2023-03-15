using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
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

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactory
{
    internal class ColumnFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {
        public virtual Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData)
        {
            RequestDb db = provider.GetService<RequestDb>();
            ColumnFR column = provider.GetRequiredService<ColumnFR>();
            IInterpolator interpolator = provider.GetService<IInterpolator>();
            IEquationsFromSp468 equations = provider.GetRequiredService<IEquationsFromSp468>();
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
            column.WorkHeight = GetWorkHeight(column.Height, column.DistanceToArmature);
            column.HeightProfileWithWarming = equations.GetHtFireFourSides(column.Height, column.DeepConcreteWarming);
            column.WorkWidthWithWarming = equations.GetHtFireFourSides(column.Width, column.DeepConcreteWarming);
            column.AreaChangedProfile = equations.GetAredColumnFourSides(column.Height, column.Width, column.DeepConcreteWarming);
            column.WorkHeightProfileWithWarming = equations.GetH0tFireFourSides(column.WorkHeight, column.DeepConcreteWarming);
            column.DistanceFromBringToPointAverageTemperature = equations.GetDistanceFromBringToPointAverageTemperatureForColumn(column.WorkHeightProfileWithWarming);
            ColumnTemperature columnTemperature = provider.GetRequiredService<ColumnTemperature>();
            double temperatureArmature = columnTemperature.GetArmatureTemperature(column);
            double criticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(sourceData.ConcreteType);
            double TemperatureConcrete = columnTemperature.GetConcreteTemperature(column, criticalTemperature);
            ArmatureForFRFactory armatureFactory = provider.GetRequiredService<ArmatureForFRFactory>();
            ConcreteForFRFactory concreteFactory = provider.GetRequiredService<ConcreteForFRFactory>();
            column.ArmatureFR = armatureFactory.Create(provider, sourceData, temperatureArmature) as ArmatureForFR;
            column.ConcreteFR = concreteFactory.Create(provider, sourceData, TemperatureConcrete) as ConcreteForFR;
            column.WorkLenth = GetWorkLenth(column.Length, column.FixationElement, db); 
            return column;
        }
        private double GetWorkHeight(double h, double a)
        {
            return h - a;
        }

        private double GetWorkLenth(double l, string fixationElement, RequestDb db)
        {
            return l * db.DataSP468Db.GetСoefficientFixationElement(fixationElement);
        }
    }

}
