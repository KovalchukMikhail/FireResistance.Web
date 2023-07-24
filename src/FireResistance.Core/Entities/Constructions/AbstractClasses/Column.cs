
namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    /// <summary>Класс содержит общее описание колонны</summary>
    internal class Column : Construction
    {
        public virtual int DistanceToArmature { get; set; }
        public virtual string FixationElement { get; set; }
        public virtual double СoefficientFixationElement { get; set; }
        public virtual double WorkLenth { get; set; }
        public double WorkHeight { get; set; }

        public override string ToString()
        {
            return "Я колонна";
        }
    }
}
