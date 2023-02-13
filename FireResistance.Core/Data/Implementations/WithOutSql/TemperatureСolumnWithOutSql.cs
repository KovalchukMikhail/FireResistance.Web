using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class TemperatureСolumnWithOutSql : IDataTemperatureСolumn
    {
        public double GetDeepForCarbonateСolumn(string fireResistans, int temperature)
        {
            throw new NotImplementedException();
        }

        public double GetDeepForSilicateСolumn(string fireResistans, int temperature)
        {
            throw new NotImplementedException();
        }

        public double GetTemperatureСolumn(string fireResistans, int hight, int deep)
        {
            throw new NotImplementedException();
        }

        public double[,] GetArrayTemperature(string fireResistans, int hight)
        {
            string name = $"H{hight}{fireResistans}";
            return name switch
            {
                "H200R30" => TemperatureDataFromSp468.TemperatureH200R30,
                "H200R45" => TemperatureDataFromSp468.TemperatureH200R45,
                "H200R60" => TemperatureDataFromSp468.TemperatureH200R60,
                "H200R90" => TemperatureDataFromSp468.TemperatureH200R90,
                "H200R120" => TemperatureDataFromSp468.TemperatureH200R120,
                "H200R150" => TemperatureDataFromSp468.TemperatureH200R150,
                "H300R30" => TemperatureDataFromSp468.TemperatureH300R30,
                "H300R45" => TemperatureDataFromSp468.TemperatureH300R45,
                "H300R60" => TemperatureDataFromSp468.TemperatureH300R60,
                "H300R90" => TemperatureDataFromSp468.TemperatureH300R90,
                "H300R120" => TemperatureDataFromSp468.TemperatureH300R120,
                "H300R150" => TemperatureDataFromSp468.TemperatureH300R150,
                "H400R30" => TemperatureDataFromSp468.TemperatureH400R30,
                "H400R45" => TemperatureDataFromSp468.TemperatureH400R45,
                "H400R60" => TemperatureDataFromSp468.TemperatureH400R60,
                "H400R90" => TemperatureDataFromSp468.TemperatureH400R90,
                "H400R120" => TemperatureDataFromSp468.TemperatureH400R120,
                "H400R150" => TemperatureDataFromSp468.TemperatureH400R150,
                _ => new double[,] {}
            };

        }
    }
}
