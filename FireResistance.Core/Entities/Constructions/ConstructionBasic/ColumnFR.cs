using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.ConstructionBasic
{
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
