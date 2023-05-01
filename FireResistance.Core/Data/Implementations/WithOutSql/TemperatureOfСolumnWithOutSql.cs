using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using FireResistance.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class TemperatureOfСolumnWithOutSql : IDataTemperatureOfСolumnRequestDb
    {
        NameColumns nameColumns;
        public TemperatureOfСolumnWithOutSql(NameColumns nameColumns)
        {
            this.nameColumns = nameColumns;
        }
        public double[,] GetTableOfDeepWarmingToCriticalTemperatureForСolumn(string concreteType)
        {
            if (concreteType == nameColumns.ConcreteType[0])
            {
                return TemperatureDataOfColumnFromSp468.DeepCriticalTemperatureConcreteSilicate;
            }
            else if (concreteType == nameColumns.ConcreteType[1] || concreteType == nameColumns.ConcreteType[2])
            {
                return TemperatureDataOfColumnFromSp468.DeepCriticalTemperatureConcreteCarbonate;
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
                "H200R30" => TemperatureDataOfColumnFromSp468.TemperatureH200R30,
                "H200R45" => TemperatureDataOfColumnFromSp468.TemperatureH200R45,
                "H200R60" => TemperatureDataOfColumnFromSp468.TemperatureH200R60,
                "H200R90" => TemperatureDataOfColumnFromSp468.TemperatureH200R90,
                "H200R120" => TemperatureDataOfColumnFromSp468.TemperatureH200R120,
                "H200R150" => TemperatureDataOfColumnFromSp468.TemperatureH200R150,
                "H300R30" => TemperatureDataOfColumnFromSp468.TemperatureH300R30,
                "H300R45" => TemperatureDataOfColumnFromSp468.TemperatureH300R45,
                "H300R60" => TemperatureDataOfColumnFromSp468.TemperatureH300R60,
                "H300R90" => TemperatureDataOfColumnFromSp468.TemperatureH300R90,
                "H300R120" => TemperatureDataOfColumnFromSp468.TemperatureH300R120,
                "H300R150" => TemperatureDataOfColumnFromSp468.TemperatureH300R150,
                "H400R30" => TemperatureDataOfColumnFromSp468.TemperatureH400R30,
                "H400R45" => TemperatureDataOfColumnFromSp468.TemperatureH400R45,
                "H400R60" => TemperatureDataOfColumnFromSp468.TemperatureH400R60,
                "H400R90" => TemperatureDataOfColumnFromSp468.TemperatureH400R90,
                "H400R120" => TemperatureDataOfColumnFromSp468.TemperatureH400R120,
                "H400R150" => TemperatureDataOfColumnFromSp468.TemperatureH400R150,
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
