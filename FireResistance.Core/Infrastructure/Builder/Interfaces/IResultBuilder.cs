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
    internal interface IResultBuilder <P, N, T, K> where N : CalculationResult<T, K>
    {
        public void SetSourceData(SourceData<P> sourceData, ServiceProvider provider);
        public bool BuildConstructions();
        public bool BuildCalculation();
        public bool BuildResult(); 
        public N GetCalculationResult();
    }
}
