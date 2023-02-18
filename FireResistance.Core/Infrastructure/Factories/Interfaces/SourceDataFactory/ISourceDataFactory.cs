using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory
{
    public interface ISourceDataFactory<T>
    {
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out T result);
    }
}
