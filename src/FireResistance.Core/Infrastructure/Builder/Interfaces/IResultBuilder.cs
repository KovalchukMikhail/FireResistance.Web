using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    /// <summary>Интерфейс описывает методы позволяющие построить объекты конструкций на основании исходных данных и результаты расчетов к ним</summary>
    internal interface IResultBuilder <N, T, K> where N : CalculationResult<T, K>
    {
        /// <summary>Устанавливает исходные данные</summary>
        public void SetSourceData(SourceData sourceData);
        /// <summary>Метод выполняет процесс построения объекта конструкции</summary>
        public void BuildConstructions();
        /// <summary>Метод выполняет процесс построения расчета</summary>
        public void BuildCalculation();
        /// <summary>Метод выполняет процесс построения результатов расчета</summary>
        public void BuildResult();
        /// <summary>Метод возвращает объект содержащий результаты расчетов</summary>
        public N GetCalculationResult();
    }
}
