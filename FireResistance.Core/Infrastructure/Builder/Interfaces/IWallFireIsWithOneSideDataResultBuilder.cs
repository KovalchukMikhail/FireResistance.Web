using FireResistance.Core.Entities.Calculations.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    internal interface IWallFireIsWithOneSideDataResultBuilder<P, N, T, K> : IResultBuilder<P, N, T, K>
        where N : CalculationResult<T, K>
    {
    }
}
