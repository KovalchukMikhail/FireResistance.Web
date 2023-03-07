using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory
{
    public interface ISourceDataFactory<T, K> 
        where T : SourceData<K>
    {
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out T result);
    }
}
