using FireResistance.Core.Entities.SourceDataForCalculation.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses
{
    public abstract class SourceData<T>
    {
        public bool Check { get; set; } = false;

        public abstract T GetData();
        
    }
}


