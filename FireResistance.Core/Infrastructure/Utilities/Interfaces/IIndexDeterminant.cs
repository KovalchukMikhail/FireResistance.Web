using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IIndexDeterminant <T, K> where K : IEnumerable
    {
        public double GetIndex(T value, K dict);
    }
}
