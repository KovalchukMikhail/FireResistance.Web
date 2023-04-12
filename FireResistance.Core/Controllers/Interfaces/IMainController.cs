using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Controllers.Interfaces
{
    internal interface IMainController <T, K>
    {
        public void Run(T data, K calculator, ServiceProvider provider);
    }
}
