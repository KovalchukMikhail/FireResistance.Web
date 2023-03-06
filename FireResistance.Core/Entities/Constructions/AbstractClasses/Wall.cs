using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    internal abstract class Wall : Construction
    {
        public Wall(Armature armature, Concrete concrete) : base(armature, concrete) { }

        public override string ToString()
        {
            return "Я стена";
        }
    }
}
