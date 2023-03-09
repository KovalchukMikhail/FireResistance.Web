using FireResistance.Core.Entities.Constructions.AbstractClasses;
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
        public virtual int distanceFromBringToPointAverageTemperature { get; set; }
        public virtual string fireResistanceVolume { get; set; }
        public virtual int DeepConcreteWarming { get; set; }
        public virtual int HeightProfileWithWarming { get; set; }
        public virtual int WorkWidthWithWarming { get; set; }
        public virtual int AreaChangedProfile { get; set; }
        public virtual int WorkHeightProfileWithWarming { get; set; }
        


    }
}
