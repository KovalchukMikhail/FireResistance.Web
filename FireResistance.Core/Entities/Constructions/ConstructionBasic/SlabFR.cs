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
    internal class SlabFR : Slab
    {
        public string FireResistanceVolume { get; set; }
        public virtual ArmatureForFR ArmatureFRFromAbove { get; set; }
        public virtual ArmatureForFR ArmatureFRFromBelow { get; set; }
        public virtual ConcreteForFR ConcreteFR { get; set; }
        public virtual double DeepConcreteWarming { get; set; }
        public virtual double HeightProfileWithWarming { get; set; }
        public virtual double WorkHeightProfileWithWarmingForAboveArmature { get; set; }
    }
}
