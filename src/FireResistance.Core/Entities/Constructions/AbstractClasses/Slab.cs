
namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    /// <summary>Класс содержит общее описание плиты перекрытия</summary>
    internal abstract class Slab : Construction
    {
        public virtual int ArmatureInstallationDepthFromBelow { get; set; }
        public virtual int ArmatureInstallationDepthFromAbove { get; set; }
        public virtual double DistributedLoad { get; set; }
        public virtual double DistanceFromEdgeOfColumnToHinge { get; set; }
        public virtual double WorkingHeightForAboveArmature { get; set; }
        public virtual double WorkingHeightForBelowArmature { get; set; }
        public virtual bool IsOnColumns { get; set; }

        public override string ToString()
        {
            return "Я плита";
        }
    }
}
