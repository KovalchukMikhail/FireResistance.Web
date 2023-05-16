using Microsoft.Extensions.DependencyInjection;


namespace FireResistance.Core.Controllers.Interfaces
{
    internal interface IMainController <T, K>
    {
        public void Run(T data, K calculator, ServiceProvider provider);
    }
}
