﻿using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    internal abstract class Slab : Construction
    {
        public Slab(Armature armature, Concrete concrete) : base(armature, concrete) { }
    }
}
