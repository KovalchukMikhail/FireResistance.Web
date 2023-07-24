using FireResistance.Core.Entities.Materials.BaseClasses;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    /// <summary>Класс содержит общее описание конструкции</summary>
    internal abstract class Construction
    {
        public virtual Armature Armature { get; set; }
        public virtual Concrete Concrete { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set;}
        public virtual int Length { get; set; }
        public virtual double Moment { get; set; }
        public virtual double Strength { get; set; }


    }
}
