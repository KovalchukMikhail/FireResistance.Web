using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses
{
    public abstract class ColumnFireIsWithFourSidesData <T> : SourceData<T>
    {
        public virtual string FireResistanceValue { get; set; }
        public virtual int LengthColumn { get; set; }
        public virtual int HeighColumn { get; set; }
        public virtual int WidthColumn { get; set; }
        public virtual int ArmatureInstallationDepth { get; set; }
        public virtual string FixationElement { get; set; }
        public virtual string ArmatureClass { get; set; }
        public virtual string ConcreteType { get; set; }
        public virtual string ConcreteClass { get; set; }
        public virtual int ArmatureDiameter { get; set; }
        public virtual int ArmatureCount { get; set; }
        public virtual double Moment { get; set; }
        public virtual double Strength { get; set; }


        public abstract override T GetData();
    }
}
