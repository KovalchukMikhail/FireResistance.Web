using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces
{
    internal interface ISlabWithRigidConnectionEquationsManager
    {
        public bool RunEquations(TempValuesForSlab values, SlabFR slab);
    }
}
