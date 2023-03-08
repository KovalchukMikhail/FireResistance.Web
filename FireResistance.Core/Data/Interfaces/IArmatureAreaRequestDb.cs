using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Interfaces
{
    internal interface IArmatureAreaRequestDb
    {
        public double GetArmatureArea(int armatureDiameter);
    }
}
