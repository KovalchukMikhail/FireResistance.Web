using System.ComponentModel.DataAnnotations;

namespace FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses
{
    /// <summary>Класс в общее описывает объект содержащий исходные данные для расчетов</summary>
    public abstract class SourceData
    {
        public string UserId { get; set; } = string.Empty;
        public string SaveDate { get; set; } = string.Empty;
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual string FireResistanceValue { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual string ArmatureClass { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual string ConcreteType { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual string ConcreteClass { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual int ArmatureDiameter { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Не корректные данные")]
        public virtual int ArmatureCount { get; set; }

        public override string ToString()
        {
            return $"[FireResistanceValue:{FireResistanceValue}, " +
                     $"ArmatureClass:{ArmatureClass}, " +
                     $"ConcreteType:{ConcreteType}, " +
                     $"ConcreteClass:{ConcreteClass}, " +
                     $"ArmatureDiameter:{ArmatureDiameter}, " +
                     $"ArmatureCount:{ArmatureCount}, ";
        }
    }
}
