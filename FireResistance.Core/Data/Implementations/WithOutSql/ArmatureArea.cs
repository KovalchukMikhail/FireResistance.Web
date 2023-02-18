using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class ArmatureArea : IArmatureArea
    {
        public double GetArmatureArea(int armatureDiameter)
        {
            bool check = ArmatureAreaData.TableArmatureDiameter.TryGetValue(armatureDiameter, out double result);
            if (check) return result;
            return -1;
        }
    }
}
