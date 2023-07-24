using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;


namespace FireResistance.Core.Entities.Calculator
{
    /// <summary>Класс содержит описание объекта предназначеного для управления процессом построения результатов расчета</summary>
    internal class CalculatorBasic : CalculatorAbstract <IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>>
    {
        /// <summary>Метод запускает операции по построению результата расчетов</summary>
        public override void Construct()
        {
            ResultBuilder.BuildConstructions();
            ResultBuilder.BuildCalculation();
            ResultBuilder.BuildResult();
        }
    }
}
