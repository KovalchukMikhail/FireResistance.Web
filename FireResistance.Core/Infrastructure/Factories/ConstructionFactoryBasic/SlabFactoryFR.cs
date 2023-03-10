using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    internal class SlabFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData<Dictionary<string, string>>>
    {
        public virtual Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
