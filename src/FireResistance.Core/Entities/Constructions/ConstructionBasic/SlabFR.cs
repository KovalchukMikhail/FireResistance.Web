using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials;

namespace FireResistance.Core.Entities.Constructions.ConstructionBasic
{
    /// <summary>Класс содержит описание плиты для расчета огнестойкости</summary>
    internal class SlabFR : Slab
    {
        public string FireResistanceVolume { get; set; }
        public virtual ArmatureForFR ArmatureFRFromAbove { get; set; }
        public virtual ArmatureForFR ArmatureFRFromBelow { get; set; }
        public virtual ConcreteForFR ConcreteOnTopFR { get; set; }
        public virtual ConcreteForFR ConcreteFromBelowFR { get; set; }
        public virtual double DeepConcreteWarming { get; set; }
        public virtual double HeightProfileWithWarming { get; set; }
        public virtual double WorkHeightProfileWithWarmingForAboveArmature { get; set; }
    }
}
