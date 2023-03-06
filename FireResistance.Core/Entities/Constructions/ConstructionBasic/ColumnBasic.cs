﻿using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.ConstructionBasic
{
    internal class ColumnBasic : Column
    {
        public ColumnBasic(Armature armature, Concrete concrete) : base(armature, concrete) { }
    }
}
