using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory
{
    internal interface IArmatureFactory<T> : IMaterialFactory<T>
    {
    }
}
