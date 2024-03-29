﻿using System.ComponentModel.DataAnnotations;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic
{
    /// <summary>Класс описывает объекта содержащий исходные данные для расчета колонны на огнестойкость</summary>
    public class ColumnFireIsWithFourSidesData : SourceData
    {
        private double moment;
        private double strength;
        [Key]
        public int Id { get; set; } = 0;
        [Range(1, int.MaxValue, ErrorMessage = "Не корректно указанна длина элемента")]
        public virtual int LengthColumn { get; set; }
        [Range(200, int.MaxValue, ErrorMessage = "Минимальная допустимая высота сечения 200 мм")]
        public virtual int HeighColumn { get; set; }
        [Range(200, int.MaxValue, ErrorMessage = "Минимальная допустимая ширина сечения 200 мм")]
        public virtual int WidthColumn { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Не корректные данные")]
        public virtual int ArmatureInstallationDepth { get; set; }
        [Required(ErrorMessage = "Не указано зачение")]
        public virtual string FixationElement { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше 0")]
        public virtual double Moment
        {
            get => moment;
            set => moment = value / 0.00000010197162123;
        }
        [Range(0.0001, double.MaxValue, ErrorMessage = "Значение должно быть больше 0.0001")]
        public virtual double Strength 
        { 
            get => strength;
            set => strength = value / 0.00010197162123;
        }

        public override string ToString()
        {
            return base.ToString() + $"LengthColumn:{LengthColumn}, " +
                                        $"HeighColumn:{HeighColumn}, " +
                                        $"WidthColumn:{WidthColumn}, " +
                                        $"ArmatureInstallationDepth:{ArmatureInstallationDepth}, " +
                                        $"FixationElement:{FixationElement}, " +
                                        $"Moment:{Moment}, " +
                                        $"Strength:{Strength}]";
        }
    }
}
