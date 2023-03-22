using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
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
        public void SetSourceData(SourceData sourceData, ServiceProvider provider);
        public void BuildConstructions();
        public void BuildCalculation();
        public void BuildResult(); 
        public N GetCalculationResult();
    }
}
