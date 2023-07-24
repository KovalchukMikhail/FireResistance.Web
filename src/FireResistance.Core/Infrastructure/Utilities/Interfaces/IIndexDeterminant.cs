
namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IIndexDeterminant
    {
        public double GetIndex(string value, List<string> list);
        public double GetIndex(double value, List<double> list);
    }
}
