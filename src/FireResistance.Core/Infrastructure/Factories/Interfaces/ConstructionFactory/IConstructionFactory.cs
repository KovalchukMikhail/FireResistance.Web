using FireResistance.Core.Entities.Constructions.AbstractClasses;


namespace FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory
{
    /// <summary>Интерфейс содержит общее описание фабричного метода для создания объекта класса Construction</summary>
    internal interface IConstructionFactory <T>
    {
        public Construction Create(T sourceData);
    }
}
