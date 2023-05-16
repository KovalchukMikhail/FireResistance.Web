using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class TemperatureOfSlabWithOutSql : IDataTemperatureOfSlabRequestDb
    {
        NameColumns nameColumns;
        public TemperatureOfSlabWithOutSql(NameColumns nameColumns)
        {
            this.nameColumns = nameColumns;
        }
        public double[,] GetArrayTemperature (int height, string concreteType)
        {
            if (concreteType == nameColumns.ConcreteType[0])
            {
                return GetArrayTemperatureForSilicate(height);
            }
            else if (concreteType == nameColumns.ConcreteType[1])
            {
                return GetArrayTemperatureForCarbonate(height);
            }
            else if (concreteType == nameColumns.ConcreteType[2])
            {
                return GetArrayTemperatureForСlaydite(height);
            }
            else return new double[0, 0];
        }
        private double[,] GetArrayTemperatureForSilicate(int height)
        {
            return height switch
            {
                40 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH40,
                60 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH60,
                80 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH80,
                100 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH100,
                120 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH120,
                140 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH140,
                160 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH160,
                180 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH180,
                200 => TemperatureDataOfSlabFromSp468.TemperatureForSilicateH200,
                _ => new double[,] {}
            };
        }

        private double[,] GetArrayTemperatureForCarbonate(int height)
        {
            return height switch
            {
                40 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH40,
                60 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH60,
                80 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH80,
                100 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH100,
                120 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH120,
                140 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH140,
                160 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH160,
                180 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH180,
                200 => TemperatureDataOfSlabFromSp468.TemperatureForCarbonateH200,
                _ => new double[,] { }
            };
        }
        private double[,] GetArrayTemperatureForСlaydite(int height)
        {
            return height switch
            {
                40 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH40,
                60 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH60,
                80 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH80,
                100 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH100,
                120 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH120,
                140 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH140,
                160 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH160,
                180 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH180,
                200 => TemperatureDataOfSlabFromSp468.TemperatureForСlayditeH200,
                _ => new double[,] { }
            };
        }
    }
}
