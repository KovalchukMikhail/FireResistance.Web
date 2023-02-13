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
        public static List<int> TemperatureForTable => new List<int>(temperatureForTable);
        public static List<int> LenthFromArmatureToEdgeForH200 => new List<int>(lenthFromArmatureToEdgeForH200);
        public static List<int> LenthFromArmatureToEdgeForH300 => new List<int>(lenthFromArmatureToEdgeForH300);
        public static List<int> LenthFromArmatureToEdgeForH400 => new List<int>(lenthFromArmatureToEdgeForH400);
        public static List<int> TemperatureForCriticalTemperature => new List<int>(temperatureForCriticalTemperature);
        public static List<string> FireResistanceForCriticalTemperature => new List<string>(fireResistanceForCriticalTemperature);

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
        private static List<int> temperatureForTable = new List<int>()
        {
            20, 200, 300, 400, 500, 600, 700, 800
        };
        private static List<int> lenthFromArmatureToEdgeForH200 = new List<int>()
        {
            0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        private static List<int> lenthFromArmatureToEdgeForH300 = new List<int>()
        {
            0, 30, 60, 90, 120, 150
        };

        private static List<int> lenthFromArmatureToEdgeForH400 = new List<int>()
        {
            0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200
        };

        private static List<int> temperatureForCriticalTemperature = new List<int>()
        {
            200, 300, 400, 500, 600, 700, 800, 900, 1000
        };

        private static List<string> fireResistanceForCriticalTemperature = new List<string>()
        {
            "R30", "R45", "R60", "R90", "R120", "R150"
        };



    }
}
