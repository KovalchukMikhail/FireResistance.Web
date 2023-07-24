using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces
{
    /// <summary>Интерфейс содержит общее описание методов запускающих в правельной последовательности формулы для расчета плиты перекрытия на огнестойкость</summary>
    internal interface ISlabWithRigidConnectionEquationsManager
    {
        public bool RunEquations(TempValuesForSlab values, SlabFR slab);
    }
}
