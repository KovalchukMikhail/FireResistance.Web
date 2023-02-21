using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Calculator.AbstractClasses
{
    internal abstract class CalculatorAbstract <T>
    {
        protected T resultBuilder;

        public CalculatorAbstract(T resultbuilder)
        {
            this.resultBuilder = resultbuilder;
        }
        public abstract void Construct();
    }
}
