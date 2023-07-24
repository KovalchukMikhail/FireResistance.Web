using FireResistance.Core.Entities.Materials.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory
{
    /// <summary>Интерфейс содержит общее описание фабричного метода для создания объекта класса Material</summary>
    internal interface IMaterialFactoryFR <T>
    {
        public Material Create(T sourceData, double temperuture);
    }
}
