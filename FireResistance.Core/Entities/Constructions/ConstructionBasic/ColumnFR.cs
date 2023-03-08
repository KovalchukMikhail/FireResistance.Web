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
        public virtual double DeepConcreteWarming { get; set; }
        public virtual double HeightProfileWithWarming { get; set; }
        public virtual double WorkWidthWithWarming { get; set; }
        public virtual double SquareChangedProfile { get; set; }
        public virtual double WorkHeightProfileWithWarming { get; set; }
        


    }
}
