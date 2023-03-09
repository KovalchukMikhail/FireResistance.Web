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
        public virtual int distanceToArmature { get; set; }
        public virtual string fixationElement { get; set; }
        public virtual int workLenth { get; set; }

        public override string ToString()
        {
            return "Я колонна";
        }
    }
}
