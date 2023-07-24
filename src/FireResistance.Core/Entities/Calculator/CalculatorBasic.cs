using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;


namespace FireResistance.Core.Entities.Calculator
{
    internal class CalculatorBasic : CalculatorAbstract <IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>>
    {
        public override void Construct()
        {
            ResultBuilder.BuildConstructions();
            ResultBuilder.BuildCalculation();
            ResultBuilder.BuildResult();
        }
    }
}
