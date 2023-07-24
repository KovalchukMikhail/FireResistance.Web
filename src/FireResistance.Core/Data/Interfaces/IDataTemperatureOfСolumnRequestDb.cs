
namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataTemperatureOfСolumnRequestDb
    {
        public double GetTemperatureOfСolumn(string fireResistans, int hight, int deep);
        public double[,] GetTableOfDeepWarmingToCriticalTemperatureForСolumn(string concreteType);
        public double[,] GetArrayTemperature(string fireResistans, int height);
        public List<double> GetListOfDistanceToArmature(int height);
    }
}
