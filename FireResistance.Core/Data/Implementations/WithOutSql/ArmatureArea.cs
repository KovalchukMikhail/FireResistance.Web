using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class ArmatureArea : IArmatureAreaRequestDb
    {
        public double GetArmatureArea(int armatureDiameter)
        {
            bool check = ArmatureAreaData.TableArmatureDiameter.TryGetValue(armatureDiameter, out double result);
            if (check) return result;
            return -1;
        }
    }
}
