using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory
{
    internal interface ISlabWithRigidConnectionToColumnsDataFactory<T> : ISourceDataFactory<T>
        where T : SourceData
    {
    }
}
