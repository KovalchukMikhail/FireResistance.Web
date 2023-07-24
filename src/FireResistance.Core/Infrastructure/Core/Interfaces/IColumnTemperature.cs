using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    /// <summary>Интерфейс в общеем описывает объект содержащий методы для определения температуры элементов колонны</summary>
    internal interface IColumnTemperature <T> where T : ColumnFR
    {
        /// <summary>Метод определяет температуру арматуры в колонне</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру арматуры °C</returns>
        public double GetArmatureTemperature(T column);
        /// <summary>Метод определяет температуру бетона в колонне</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру бетона °C</returns>
        public double GetConcreteTemperature(T column, double criticalTemperature);

    }
}
