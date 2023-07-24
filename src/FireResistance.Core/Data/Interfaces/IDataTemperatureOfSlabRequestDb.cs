
namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataTemperatureOfSlabRequestDb
    {
        public double[,] GetArrayTemperature(int height, string concreteType);
    }
}
