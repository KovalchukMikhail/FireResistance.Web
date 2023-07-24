using FireResistance.Core.Entities.Constructions.AbstractClasses;


namespace FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory
{
    internal interface IConstructionFactory <T>
    {
        public Construction Create(T sourceData);
    }
}
