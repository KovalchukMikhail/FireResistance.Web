using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
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
    internal class ColumnFactoryFR : IColumnFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {
        public Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData)
        {
            ColumnFR column = provider.GetRequiredService<ColumnFR>();
            column.Width = 200;
            column.Height = 1200;
            column.distanceToArmature = 55;
            column.fireResistanceVolume = "R120";
            ArmatureForFR armature = provider.GetRequiredService<ArmatureForFR>();
            ColumnTemperature columnTemperature = provider.GetRequiredService<ColumnTemperature>();
            armature.Temperature = columnTemperature.GetArmatureTemperature(column);
            column.Armature = armature;
            return column;
        }
    }
}
