using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class TemperatureСolumnWithOutSql : IDataTemperatureСolumnRequestDb
    {
        NameColumns nameColumns;
        public TemperatureСolumnWithOutSql(NameColumns nameColumns)
        {
            this.nameColumns = nameColumns;
        }
        public double[,] GetTableOfDeepWarmingToCriticalTemperatureForСolumn(string concreteType)
        {
            if (concreteType == nameColumns.ConcreteType[0])
            {
                return TemperatureDataFromSp468.DeepCriticalTemperatureConcreteSilicate;
            }
            else if (concreteType == nameColumns.ConcreteType[1] || concreteType == nameColumns.ConcreteType[2])
            {
                return TemperatureDataFromSp468.DeepCriticalTemperatureConcreteCarbonate;
            }
            else return new double[0, 0];
        }

        public double GetTemperatureOfСolumn(string fireResistans, int height, int deep)
        {
            List<double> deepList = GetListOfDistanceToArmature(height);
            double[,] array = GetArrayTemperature(fireResistans, height);
            int deepIndex = deepList.IndexOf(deep);
            if (array.GetLength(0) == 0 || deepIndex == -1) return -1;
            return array[deepIndex, deepIndex];
        }

        public double[,] GetArrayTemperature(string fireResistans, int height)
        {
            string name = $"H{height}{fireResistans}";
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

        public List<double> GetListOfDistanceToArmature(int height)
        {
            return height switch
            {
                200 => nameColumns.DistanceToArmatureH200,
                300 => nameColumns.DistanceToArmatureH300,
                400 => nameColumns.DistanceToArmatureH400,
                _ => new List<double>()
            };
        }
    }
}
