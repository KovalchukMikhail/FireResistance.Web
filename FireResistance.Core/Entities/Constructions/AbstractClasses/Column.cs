using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    internal class Column : Construction
    {
        public virtual int DistanceToArmature { get; set; }
        public virtual string FixationElement { get; set; }
        public virtual double WorkLenth { get; set; }

        public override string ToString()
        {
            return "Я колонна";
        }
    }
}
