using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses
{
    public abstract class SourceData
    {
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
    }
}
