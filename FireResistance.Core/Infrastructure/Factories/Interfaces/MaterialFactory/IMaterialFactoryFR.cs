using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory
{
    internal interface IMaterialFactoryFR <T>
    {
        public Material Create(T sourceData, double temperuture);
    }
}
