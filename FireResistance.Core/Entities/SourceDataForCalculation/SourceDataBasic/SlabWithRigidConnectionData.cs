using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic
{
    public class SlabWithRigidConnectionData : SourceData
    {
        private double distributedLoad;
        [Key]
        public int Id { get; set; } = 0;
        public string UserId { get; set; } = string.Empty;
        [Range(0, 1, ErrorMessage = "Необходимо указать значение. 0 - плита оперта на стены, 1 - плита оперта на колонны")]
        public int IsOnCollums { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Расстояние указано не корректно")]
        public virtual int LengthAlong { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Расстояние указано не корректно")]
        public virtual int LengthAcross { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Расстояние указано не корректно")]
        public virtual int DistanceFromEdgeOfColumnToHinge { get; set; }
        [Range(40, int.MaxValue, ErrorMessage = "Значение должно быть больше или равно 40")]
        public virtual int Heigh { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Не корректные данные")]
        public virtual int ArmatureInstallationDepthFromBelow { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Не корректные данные")]
        public virtual int ArmatureInstallationDepthFromAbove { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Не корректные данные")]
        public virtual int ArmatureCountFromAbove { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual int ArmatureDiameterFromAbove { get; set; }
        [Range(0.00001, double.MaxValue, ErrorMessage = "Значение должно быть больше 0.00001")]
        public virtual double DistributedLoad
        {
            get { return distributedLoad; }
            set { distributedLoad = value * 0.0098066501; }
        }

    }
}
