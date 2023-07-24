using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials;

namespace FireResistance.Core.Entities.Constructions.ConstructionBasic
{
    /// <summary>Класс содержит описание колонны для расчета огнестойкости</summary>
    internal class ColumnFR : Column
    {
        public virtual ArmatureForFR ArmatureFR { get; set; }
        public virtual ConcreteForFR ConcreteFR { get; set; }
        public virtual double DistanceFromBringToPointAverageTemperature { get; set; }
        public virtual string FireResistanceVolume { get; set; }
        public virtual double DeepConcreteWarming { get; set; }
        public virtual double HeightProfileWithWarming { get; set; }
        public virtual double WidthProfileWithWarming { get; set; }
        public virtual double WorkWidthWithWarming { get; set; }
        public virtual double AreaChangedProfile { get; set; }
        public virtual double WorkHeightProfileWithWarming { get; set; }
    }
}
