﻿using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces
{
    internal interface ISlabWithRigidConnectionEquationsManager
    {
        public bool RunEquations(TempValuesForSlab values, SlabFR slab);
    }
}