using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IInterpolator
    {
        public double GetValueFromTable(List<string> namesOfRows, List<int> namesOfColumns, string rowName, int columnName, double table);
        public double GetValueFromTemperatureTable(List<int> namesOfRows, int rowName, double[,] table);
    }
}
