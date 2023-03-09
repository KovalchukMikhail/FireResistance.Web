using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
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
            Column column = provider.GetRequiredService<Column>();
            return null;
        }
    }
}
