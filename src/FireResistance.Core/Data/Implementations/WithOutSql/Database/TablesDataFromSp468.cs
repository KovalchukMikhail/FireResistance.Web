
namespace FireResistance.Core.Data.Implementations.WithOutSql.Database
{
    internal static class DataFromSp468
    {
        public static List<string> ConcreteTypeForTables => new List<string>(concreteTypeForTables);
        public static List<string> ArmatureClassForTables => new List<string>(armatureClassForTables);
        public static List<int> TemperatureForTables => new List<int>(temperatureForTables);

        public static double[,] TableGammaBT => Utilities.GetCopyArray(tableGammaBT);
        public static double[,] TableBetaB => Utilities.GetCopyArray(tableBetaB);
        public static double[,] TableGammaSt => Utilities.GetCopyArray(tableGammaSt);
        public static double[,] TableBetaS => Utilities.GetCopyArray(tableBetaS);
        public static double[,] TableFiNumberEightDotOne => Utilities.GetCopyArray(tableFiNumberEightDotOne);
        public static Dictionary<string, double> FixationElementTable
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = fixationElementTable.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }

        private static List<string> concreteTypeForTables = new List<string>()
        {
            "ТЯЖЕЛЫЙ_НА_СИЛИКАТНОМ_ЗАПОЛНИТЕЛЕ",
            "ТЯЖЕЛЫЙ_НА КАРБОНАТНОМ_ЗАПОЛНИТЕЛЕ",
            "КОНСТРУКЦИОННЫЙ_КЕРАМЗИТОБЕТОН"
        };
        private static List<string> armatureClassForTables = new List<string>()
        {
            "A240",
            "А400",
            "А500",
            "А600",
            "А800",
            "А1000",
            "В500",
            "А500С_МАРКА_25Г2С_ПО_ГОСТ_Р_52544_2006",
            "А600С_МАРКИ_18Г2СФ_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ",
            "А500С_МАРКИ_Ст3Гпс_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ_ПО_ГОСТ_34028_2016"
        };


private static List<int> temperatureForTables = new List<int>()
        {
            20,
            200,
            300,
            400,
            500,
            600,
            700,
            800
        };

        private static double[,] tableGammaBT =
        {
            {1.0, 0.98, 0.95, 0.85, 0.80, 0.60, 0.20, 0.10},
            {1.0, 1.0, 0.95, 0.9, 0.85, 0.65, 0.3, 0.15},
            {1.0, 1.0, 1.0, 0.95, 0.85, 0.70, 0.50, 0.25}
        };

        private static double[,] tableBetaB =
        {
            {1.0, 0.7, 0.5, 0.4, 0.3, 0.2, 0.1, 0.05},
            {1.0, 0.75, 0.55, 0.45, 0.35, 0.25, 0.15, 0.1},
            {1.0, 0.85, 0.8, 0.7, 0.6, 0.45, 0.3, 0.15}
        };

        private static double[,] tableGammaSt =
        {
            {1.0, 1.0, 1.0, 0.85, 0.60, 0.37, 0.22, 0.10},
            {1.0, 1.0, 1.0, 0.85, 0.60, 0.37, 0.22, 0.10},
            {1.0, 1.0, 1.0, 0.85, 0.60, 0.37, 0.22, 0.10},
            {1.0, 1.0, 0.96, 0.8, 0.55, 0.3, 0.12, 0.08},
            {1.0, 1.0, 0.96, 0.8, 0.55, 0.3, 0.12, 0.08},
            {1.0, 1.0, 0.96, 0.8, 0.55, 0.3, 0.12, 0.08},
            {1.0, 1.0, 0.9, 0.65, 0.35, 0.15, 0.05, 0.02},
            {1.0, 1.0, 1.0, 0.92, 0.87, 0.76, 0.39, 0.18},
            {1.0, 0.92, 0.84, 0.76, 0.82, 0.69, 0.42, 0.13},
            {1.0, 0.97, 0.94, 0.87, 0.85, 0.72, 0.43, 0.17}
        };

        private static double[,] tableBetaS =
        {
            {1.0, 0.92, 0.9, 0.85, 0.80, 0.77, 0.72, 0.65},
            {1.0, 0.92, 0.9, 0.85, 0.80, 0.77, 0.72, 0.65},
            {1.0, 0.92, 0.9, 0.85, 0.80, 0.77, 0.72, 0.65},
            {1.0, 0.9, 0.85, 0.8, 0.76, 0.7, 0.66, 0.61},
            {1.0, 0.9, 0.85, 0.8, 0.76, 0.7, 0.66, 0.61},
            {1.0, 0.9, 0.85, 0.8, 0.76, 0.7, 0.66, 0.61},
            {1.0, 0.94, 0.86, 0.77, 0.64, 0.55, 0.45, 0.35},
            {1.0, 1.0, 1.0, 0.99, 0.94, 0.93, 0.77, 0.6},
            {1.0, 0.99, 0.99, 0.91, 0.91, 0.83, 0.72, 0.65},
            {1.0, 1.0, 1.0, 0.98, 0.93, 0.88, 0.82, 0.67}
        };

        private static Dictionary<string, double> fixationElementTable = new Dictionary<string, double>()
        {
            {"НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ", 0.5},
            {"НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ_С_ПОДАТЛИВЫМ_ОГРАНИЧЕННЫМ_ПОВОРОТОМ", 0.8},
            {"ШАРНИРНЫЕ_ОПОРЫ_НА_ДВУХ_КОНЦАХ", 1}
        };

        private static double[,] tableFiNumberEightDotOne =
        {
            {0.9, 0.8, 0.7 },
            {0.9, 0.8, 0.7 },
            {0.85, 0.68, 0.55 }
        };
    }
}
