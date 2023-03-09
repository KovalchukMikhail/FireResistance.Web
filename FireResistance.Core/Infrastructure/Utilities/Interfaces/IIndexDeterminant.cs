using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IIndexDeterminant
    {
        public double GetIndex(string value, List<string> list);
        public double GetIndex(double value, List<double> list);
    }
}
