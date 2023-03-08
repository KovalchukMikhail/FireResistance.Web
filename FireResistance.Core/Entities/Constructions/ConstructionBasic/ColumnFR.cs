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
        public int distanceFromBringToPointAverageTemperature { get; set; }
        public string fireResistanceVolume { get; set; }
        public double DeepConcreteWarming { get; set; }
        public double HeightProfileWithWarming { get; set; }
        public double WorkWidthWithWarming { get; set; }
        public double SquareChangedProfile { get; set; }
        public double WorkHeightProfileWithWarming { get; set; }
        


    }
}
