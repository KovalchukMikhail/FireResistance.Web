using FireResistance.Core.Entities.Calculations.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    internal interface IResultBuilder <N, T, K> where N : CalculationResult<T, K>
    {
        bool BuildConstructions(ServiceProvider provider);
        bool BuildSourceValues();
        bool BuildCalculation();
        N GetCalculationResult();
    }
}
