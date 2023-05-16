using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IColumnTemperature <T> where T : ColumnFR
    {
        public double GetArmatureTemperature(T column);
        public double GetConcreteTemperature(T column, double criticalTemperature);

    }
}
