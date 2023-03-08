using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials.BaseClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory
{
    internal interface IConstructionFactory <T>
    {
        public Construction Create(ServiceProvider provider, T sourceData);
    }
}
