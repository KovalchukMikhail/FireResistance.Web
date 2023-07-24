using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FireResistance.Core.Controllers.ControllerBasic
{
    internal class MainController : IMainController <SourceData,
                                                        CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>,
                                                        Dictionary<string, string>>>>
    {
        private IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>,
                                Dictionary<string, string>> resultBuilder;
        public void Run(SourceData data,
                            CalculatorAbstract<IResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>> calculator,
                            ServiceProvider provider)
        {
            switch (data)
            {
                case ColumnFireIsWithFourSidesData:
                    resultBuilder = provider.GetService<IColumnFireIsWithFourSidesResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                    Dictionary<string, double>,
                                                                    Dictionary<string, string>>>();
                    break;
                case SlabWithRigidConnectionData:
                    resultBuilder = provider.GetService<ISlabWithRigidConnectionResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>,
                                                                    Dictionary<string, double>,
                                                                    Dictionary<string, string>>>();
                    break;
            };

            if(resultBuilder != null)
            {
                resultBuilder.SetSourceData(data);
                calculator.ResultBuilder = resultBuilder;
                calculator.Construct();
            }
        }
    }
}
