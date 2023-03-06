using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Calculator
{
    internal class CalculatorBasic : CalculatorAbstract <IResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>>
    {
        public override bool TryConstruct(ServiceProvider provider)
        {
            if(!ResultBuilder.BuildConstructions(provider) 
                || !ResultBuilder.BuildSourceValues() 
                || !ResultBuilder.BuildCalculation()) return false;
            return true;
        }
    }
}
