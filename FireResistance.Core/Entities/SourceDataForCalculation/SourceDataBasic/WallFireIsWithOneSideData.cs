﻿using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic
{
    public class WallFireIsWithOneSideData : SourceData<Dictionary<string, string>>
    {
        public override Dictionary<string, string> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
