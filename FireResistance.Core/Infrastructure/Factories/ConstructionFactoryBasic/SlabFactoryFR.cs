using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    internal class SlabFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData>
    {
        public virtual Construction Create(ServiceProvider provider, ColumnFireIsWithFourSidesData sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
