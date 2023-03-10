using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Formulas.TemperutureFormSp468;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactory
{
    internal class ColumnFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {
        public virtual Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData)
        {
            RequestDb db = provider.GetService<RequestDb>();
            ColumnFR column = provider.GetRequiredService<ColumnFR>();
            column.Width = sourceData.WidthColumn;
            column.Height = sourceData.HeighColumn;
            column.distanceToArmature = sourceData.ArmatureInstallationDepth;
            column.fireResistanceVolume = sourceData.FireResistanceValue;
            column.fixationElement = sourceData.FixationElement;
            column.Moment = sourceData.Moment;
            column.Strength = sourceData.Strength;
            ColumnTemperature columnTemperature = provider.GetRequiredService<ColumnTemperature>();
            double temperatureArmature = columnTemperature.GetArmatureTemperature(column);
            double criticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(sourceData.ConcreteType);
            double TemperatureConcrete = columnTemperature.GetConcreteTemperature(column, criticalTemperature);
            column.Armature = armature;
            return column;
        }
    }
}
