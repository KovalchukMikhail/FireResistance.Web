using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    /// <summary>Интерфейс в общеем описывает объект содержащий методы для определения температуры элементов плиты перекрытия</summary>
    internal interface ISlabTemperature <T, K>
        where T : SlabFR
        where K : SourceData
    {
        /// <summary>Метод определяет температуру в плите перекрытия на определенном расстоянии</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру °C</returns>
        public double GetTemperature(T slab, double distanceToPoint, K sourceData);
        /// <summary>Метод определяет глубину прогрева бетона</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение глубины прогрева бетона</returns>
        public double GetDeepConcreteWarming(T slab, K sourceData, double criticalTemperature);
    }
}
