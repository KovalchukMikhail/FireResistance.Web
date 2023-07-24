
namespace FireResistance.Core.Entities.Calculator.AbstractClasses
{
    /// <summary>Класс содержит описание объекта предназначеного для управления процессом построения результатов расчета</summary>
    internal abstract class CalculatorAbstract <T>
    {
        /// <summary>Метод запускает операции по построению результата расчетов</summary>
        public T ResultBuilder { get; set; }

        public abstract void Construct();
    }
}
