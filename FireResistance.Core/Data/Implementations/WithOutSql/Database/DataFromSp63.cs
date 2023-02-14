using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql.Database
{
    internal class DataFromSp63
    {
        public static Dictionary<string, double> TableConcreteResistNormative
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = tableConcreteResistNormative.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public static Dictionary<string, double> TableConcreteStartElasticityModulus
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = tableConcreteStartElasticityModulus.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public static Dictionary<string, double> TableArmatureResistNormative
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = tableArmatureResistNormative.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public static Dictionary<string, double> TableArmatureResistSqueezeСalculation
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = tableArmatureResistSqueezeСalculation.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        public static Dictionary<string, double> TableArmatureResistStretchСalculation
        {
            get
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                return dict = tableArmatureResistStretchСalculation.ToDictionary(entry => entry.Key, entry => entry.Value);
            }
        }
        private static Dictionary<string, double> tableConcreteResistNormative = new Dictionary<string, double>()
        {
            {"B15", 11},
            {"B20", 15},
            {"B25", 18.5},
            {"B30", 22},
            {"B35", 25.5},
            {"B40", 29},
            {"B45", 32},
            {"B50", 36}
        };

        private static Dictionary<string, double> tableConcreteStartElasticityModulus = new Dictionary<string, double>()
        {
            {"B15", 24000},
            {"B20", 27500},
            {"B25", 30000},
            {"B30", 32500},
            {"B35", 34500},
            {"B40", 36000},
            {"B45", 37000},
            {"B50", 38000}
        };

        private static Dictionary<string, double> tableArmatureResistNormative = new Dictionary<string, double>()
        {
            {"A240", 240},
            {"А400", 390},
            {"А500", 500},
            {"А600", 600},
            {"А800", 800},
            {"А1000", 1000},
            {"В500", 500},
            {"А500С_МАРКА_25Г2С_ПО_ГОСТ_Р_52544-2006", 500},
            {"А600С_МАРКИ_18Г2СФ_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ", 600},
            {"А500С_МАРКИ_Ст3Гпс_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ_ПО_ГОСТ_34028-2016", 500}
        };
        private static Dictionary<string, double> tableArmatureResistSqueezeСalculation = new Dictionary<string, double>()
        {
            {"A240", 210},
            {"А400", 340},
            {"А500", 400},
            {"А600", 400},
            {"А800", 400},
            {"А1000", 400},
            {"В500", 380},
            {"А500С_МАРКА_25Г2С_ПО_ГОСТ_Р_52544-2006", 400},
            {"А600С_МАРКИ_18Г2СФ_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ", 400},
            {"А500С_МАРКИ_Ст3Гпс_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ_ПО_ГОСТ_34028-2016", 400}
        };

        private static Dictionary<string, double> tableArmatureResistStretchСalculation = new Dictionary<string, double>()
        {
            {"A240", 210},
            {"А400", 340},
            {"А500", 435},
            {"А600", 520},
            {"А800", 695},
            {"А1000", 870},
            {"В500", 415},
            {"А500С_МАРКА_25Г2С_ПО_ГОСТ_Р_52544-2006", 435},
            {"А600С_МАРКИ_18Г2СФ_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ", 520},
            {"А500С_МАРКИ_Ст3Гпс_ТЕРМОМЕХАНИЧЕСКИ_УПРОЧНЕННАЯ_ПО_ГОСТ 34028-2016", 435}
        };
    }
}
