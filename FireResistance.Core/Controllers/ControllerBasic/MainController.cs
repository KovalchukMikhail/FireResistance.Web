using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Controllers.ControllerBasic
{
    internal class MainController : IMainController <SourceData<Dictionary<string, string>>,
                                                        CalculatorAbstract<IResultBuilder<Dictionary<string, string>, ResultAsDictionary, Dictionary<string, double>,
                                                        Dictionary<string, string>>>>
    {
        private IResultBuilder<Dictionary<string, string>,
                                ResultAsDictionary, Dictionary<string, double>,
                                Dictionary<string, string>> resultBuilder;
        public bool Run(SourceData<Dictionary<string, string>> data,
                            CalculatorAbstract<IResultBuilder<Dictionary<string, string>, ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>> calculator,
                            ServiceProvider provider)
        {
            if (!data.Check) return false;


            switch (data)
            {
                case ColumnFireIsWithFourSidesData<Dictionary<string, string>>:
                    resultBuilder = provider.GetService<IColumnFireIsWithFourSidesResultBuilder<Dictionary<string, string>,
                                                                                                ResultAsDictionary,
                                                                                                Dictionary<string, double>,
                                                                                                Dictionary<string, string>>>();
                    break;
                case PlateWithRigidConnectionToColumnsData<Dictionary<string, string>>:
                    resultBuilder = null;
                    break;
                case PlateWithRigidConnectionToTwoWallsData<Dictionary<string, string>>:
                    resultBuilder = null;
                    break;
                case WallFireIsWithOneSideData<Dictionary<string, string>>:
                    resultBuilder = null;
                    break;
                default: return false;
            };

            resultBuilder.SetSourceData(data, provider);
            calculator.ResultBuilder = resultBuilder;
            calculator.TryConstruct();
            return true;

        }
    }
}
