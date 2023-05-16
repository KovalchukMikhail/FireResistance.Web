using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface ISlabTemperature <T, K>
        where T : SlabFR
        where K : SourceData
    {
        public double GetTemperature(T slab, double distanceToPoint, K sourceData);
        public double GetDeepConcreteWarming(T slab, K sourceData, double criticalTemperature);
    }
}
