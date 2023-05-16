
namespace FireResistance.Core.Data
{
    public class NameColumns
    {
        public virtual List<string> ArmatureClass => new List<string>(armatureClass);
        public virtual List<string> ConcreteClass => new List<string>(concreteClass);
        public virtual List<string> ConcreteType => new List<string>(concreteType);
        public virtual List<string> FixationElement => new List<string>(fixationElement);
        public virtual List<double> TemperatureForTable => new List<double>(temperatureForTable);
        public virtual List<double> DistanceToArmatureH200 => new List<double>(distanceToArmatureH200);
        public virtual List<double> DistanceToArmatureH300 => new List<double>(distanceToArmatureH300);
        public virtual List<double> DistanceToArmatureH400 => new List<double>(distanceToArmatureH400);
        public virtual List<double> SizeForCriticalTemperature => new List<double>(sizeForCriticalTemperature);
        public virtual List<double> FlexibilityForTableEightDotOne => new List<double>(flexibilityForTableEightDotOne);
        public virtual List<string> FireResistanceForCriticalTemperature => new List<string>(fireResistanceForCriticalTemperature);
        public virtual Dictionary<string, int> StandartHeightOfColumn
        {
            get
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                return dict = standartHeightOfColumn.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public virtual Dictionary<string,int> BoundaryHeightOfSlab
        {
            get
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                return dict = boundaryHeightOfSlab.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public virtual List<int> ArmatureDiameter => new List<int>(armatureDiameter);

        private List<string> armatureClass = new List<string>()
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

        private List<string> concreteClass = new List<string>()
        {
            "B15", "B20", "B25", "B30", "B35", "B40", "B45", "B50"
        };

        private List<string> concreteType = new List<string>()
        {
            "ТЯЖЕЛЫЙ_НА_СИЛИКАТНОМ_ЗАПОЛНИТЕЛЕ",
            "ТЯЖЕЛЫЙ_НА_КАРБОНАТНОМ_ЗАПОЛНИТЕЛЕ",
            "КОНСТРУКЦИОННЫЙ_КЕРАМЗИТОБЕТОН"
        };
        private List<string> fixationElement = new List<string>()
        {
            "НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ",
            "НЕ_СМЕЩАЕМАЯ_ЗАДЕЛКА_НА_ДВУХ_КОНЦАХ_С_ПОДАТЛИВЫМ_ОГРАНИЧЕННЫМ_ПОВОРОТОМ",
            "ШАРНИРНЫЕ_ОПОРЫ_НА_ДВУХ_КОНЦАХ"
        };
        private List<double> temperatureForTable = new List<double>()
        {
            20, 200, 300, 400, 500, 600, 700, 800
        };
        private List<double> distanceToArmatureH200 = new List<double>()
        {
            0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        private List<double> distanceToArmatureH300 = new List<double>()
        {
            0, 30, 60, 90, 120, 150
        };

        private List<double> distanceToArmatureH400 = new List<double>()
        {
            0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200
        };

        private List<double> sizeForCriticalTemperature = new List<double>()
        {
            200, 300, 400, 500, 600, 700, 800, 900, 1000
        };

        private List<string> fireResistanceForCriticalTemperature = new List<string>()
        {
            "R30", "R45", "R60", "R90", "R120", "R150"
        };
        private Dictionary<string, int> standartHeightOfColumn = new Dictionary<string, int>()
        {
            {"min", 200 },
            {"medium", 300 },
            {"max", 400 }
        };
        private Dictionary<string, int> boundaryHeightOfSlab = new Dictionary<string, int>()
        {
            {"min", 40 },
            {"max", 200 }
        };
        private List<int> armatureDiameter = new List<int>()
        {
            6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40
        };

        private List<double> flexibilityForTableEightDotOne = new List<double>()
        {
            12, 16, 20
        };

    }
}
