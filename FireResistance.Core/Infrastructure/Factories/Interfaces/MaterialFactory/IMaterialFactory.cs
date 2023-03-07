using FireResistance.Core.Entities.Materials.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory
{
    internal interface IMaterialFactory <T>
    {
        public Material Create(ServiceProvider provider, T sourceData);
    }
}
