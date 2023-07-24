using FireResistance.Core.Entities.Calculations.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    internal interface ISlabWithRigidConnectionResultBuilder<N, T, K> : IResultBuilder<N, T, K>
        where N : CalculationResult<T, K>
    {
    }
}
