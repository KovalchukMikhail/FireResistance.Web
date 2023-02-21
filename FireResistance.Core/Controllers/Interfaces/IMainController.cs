using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Controllers.Interfaces
{
    internal interface IMainController <T, K>
    {
        public bool Run(T data, K resultBilder);
    }
}
