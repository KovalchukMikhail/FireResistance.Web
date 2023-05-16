
namespace FireResistance.Core.Data.Implementations.WithOutSql.Database
{
    internal static class ArmatureAreaData
    {
        public static Dictionary<int, double> TableArmatureDiameter
        {
            get
            {
                Dictionary<int, double> dict = new Dictionary<int, double>();
                return dict = tableArmatureDiameter.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        private static Dictionary<int, double> tableArmatureDiameter = new Dictionary<int, double>()
        {
            {6, 28.3},
            {8, 50.3},
            {10, 78.5},
            {12, 113.1},
            {14, 153.9},
            {16, 201.1},
            {18, 254.5},
            {20, 314.2},
            {22, 380.1},
            {25, 490.9},
            {28, 615.8},
            {32, 804.3},
            {36, 1017.9},
            {40, 1256.6}
        };
    }
}
