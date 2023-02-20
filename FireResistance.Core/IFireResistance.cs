using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core
{
    internal interface IFireResistance <N, K>
    {
        public bool TryPerformCalculation(K data);
        public N GetResult();
    }
}
