using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data
{
    public static class NameColumns
    {
        public static List<string> ArmatureClass => new List<string>(armatureClass);
        public static List<string> ConcreteClass => new List<string>(concreteClass);
        public static List<string> ConcreteType => new List<string>(concreteType);
        public static List<string> FixationElement => new List<string>(fixationElement);
        public static List<double> TemperatureForTable => new List<double>(temperatureForTable);
        public static List<double> DistanceToArmatureH200 => new List<double>(distanceToArmatureH200);
        public static List<double> DistanceToArmatureH300 => new List<double>(distanceToArmatureH300);
        public static List<double> DistanceToArmatureH400 => new List<double>(distanceToArmatureH400);
        public static List<double> SizeForCriticalTemperature => new List<double>(sizeForCriticalTemperature);
        public static List<double> FlexibilityForTableEightDotOne => new List<double>(flexibilityForTableEightDotOne);
        public static List<string> FireResistanceForCriticalTemperature => new List<string>(fireResistanceForCriticalTemperature);
        public static List<int> StandartHeight => new List<int>(standartHeight);
        public static List<int> ArmatureDiameter => new List<int>(armatureDiameter);

        private static List<string> armatureClass = new List<string>()
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

private static List<string> concreteClass = new List<string>()
        {
            "B15", "B20", "B25", "B30", "B35", "B40", "B45", "B50"
        };

        private static List<string> concreteType = new List<string>()
        {
            "ТЯЖЕЛЫЙ_НА_СИЛИКАТНОМ_ЗАПОЛНИТЕЛЕ",
            "ТЯЖЕЛЫЙ_НА_КАРБОНАТНОМ_ЗАПОЛНИТЕЛЕ",
            "КОНСТРУКЦИОННЫЙ_КЕРАМЗИТОБЕТОН"
        };
        private static List<string> fixationElement = new List<string>()
        {
            "НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ",
            "НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ_С_ПОДАТЛИВЫМ_ОГРАНИЧЕННЫМ_ПОВОРОТОМ",
            "ШАРНИРНЫЕ_ОПОРЫ_НА_ДВУХ_КОНЦАХ"
        };
        private static List<double> temperatureForTable = new List<double>()
        {
            20, 200, 300, 400, 500, 600, 700, 800
        };
        private static List<double> distanceToArmatureH200 = new List<double>()
        {
            0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        private static List<double> distanceToArmatureH300 = new List<double>()
        {
            0, 30, 60, 90, 120, 150
        };

        private static List<double> distanceToArmatureH400 = new List<double>()
        {
            0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200
        };

        private static List<double> sizeForCriticalTemperature = new List<double>()
        {
            200, 300, 400, 500, 600, 700, 800, 900, 1000
        };

        private static List<string> fireResistanceForCriticalTemperature = new List<string>()
        {
            "R30", "R45", "R60", "R90", "R120", "R150"
        };
        private static List<int> standartHeight = new List<int>()
        {
            200, 300, 400
        };

        private static List<int> armatureDiameter = new List<int>()
        {
            6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40
        };

        private static List<double> flexibilityForTableEightDotOne = new List<double>()
        {
            12, 16, 20
        };

    }
}
