using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Dependency;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.Calculator.Interfaces;
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
    internal class MainController : IMainController <SourceData<Dictionary<string, string>>, IResultBuilder<ResultAsDictionary>>
    {
        public bool Run(SourceData<Dictionary<string, string>> data, IResultBuilder<ResultAsDictionary> resultBuilder)
        {
            if (!data.Check) return false;

            using ServiceProvider provider = DependencyCreator.GetServiceProvider();
            

            switch (data)
            {
                case ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData:
                    resultBuilder = provider.GetService<IColumnFireIsWithFourSidesResultBuilder<ResultAsDictionary>>();
                    break;
                case PlateWithRigidConnectionToColumnsData<Dictionary<string, string>> sourceData:
                    resultBuilder = null;
                    break;
                case PlateWithRigidConnectionToTwoWallsData<Dictionary<string, string>> sourceData:
                    resultBuilder = null;
                    break;
                case WallFireIsWithOneSideData<Dictionary<string, string>> sourceData:
                    resultBuilder = null;
                    break;
                default: return false;
            };

            CalculatorAbstract<IResultBuilder<ResultAsDictionary>> calculator = provider.GetService<CalculatorAbstract<IResultBuilder<ResultAsDictionary>>>();


        }
    }
}
