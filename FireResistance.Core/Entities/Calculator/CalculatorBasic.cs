using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculator.AbstractClasses;
using FireResistance.Core.Entities.Calculator.Interfaces;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Calculator
{
    internal class CalculatorBasic : CalculatorAbstract <IResultBuilder<ResultAsDictionary>>
    {
        public CalculatorBasic (IResultBuilder<ResultAsDictionary> resultbuilder) : base(resultbuilder) { }
        public override void Construct()
        {
            resultBuilder.BuildConstructions();
            resultBuilder.BuildSourceValues();
            resultBuilder.BuildCalculation();
        }
    }
}
