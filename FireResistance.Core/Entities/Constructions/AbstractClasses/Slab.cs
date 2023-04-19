using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    internal abstract class Slab : Construction
    {
        public virtual int ArmatureInstallationDepthFromBelow { get; set; }
        public virtual int ArmatureInstallationDepthFromAbove { get; set; }
        public virtual double DistributedLoad { get; set; }
        public virtual double DistanceFromEdgeOfColumnToHinge { get; set; }

    public override string ToString()
        {
            return "Я колонна";
        }
    }
}
