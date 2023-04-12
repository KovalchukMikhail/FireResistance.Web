﻿using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    internal class WallFactoryFR : IConstructionFactory<ColumnFireIsWithFourSidesData>
    {
        public virtual Construction Create(ColumnFireIsWithFourSidesData sourceData)
        {
            throw new NotImplementedException();
        }
    }
}
