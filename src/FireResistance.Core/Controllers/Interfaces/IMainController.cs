using Microsoft.Extensions.DependencyInjection;


namespace FireResistance.Core.Controllers.Interfaces
{
    internal interface IMainController <T, K>
    {
        /// <summary>Метод последовательно выполняет операции необходимые для определения типа расчета, выполнения расчтета и подготовки результата расчета</summary>
        public void Run(T data, K calculator, ServiceProvider provider);
    }
}
