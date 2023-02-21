using FireResistance.Core.Entities.Calculations.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    internal interface IResultBuilder <N>
    {
        bool BuildConstructions();
        bool BuildSourceValues();
        bool BuildCalculation();
        N GetCalculationResult();
    }
}
