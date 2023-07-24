using FireResistance.Core.Entities.Materials.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory
{
    internal interface IMaterialFactoryFR <T>
    {
        public Material Create(T sourceData, double temperuture);
    }
}
