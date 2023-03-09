using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic
{
    internal class InterpolatorBasic : IInterpolator
    {
        IIndexDeterminant<string, Dictionary<string, int>> IndexDeterminant { get; set; }
        public InterpolatorBasic(IIndexDeterminant<string, Dictionary<string, int>> indexDeterminant)
        {
            IndexDeterminant = indexDeterminant;
        }

        public double GetValueFromTable(List<string> namesOfRows, List<int> namesOfColumns, string rowName, int columnName, double table)
        {
            throw new NotImplementedException();
        }

        public double GetValueFromTemperatureTable(List<int> namesOfRows, int rowName, double[,] table)
        {
            throw new NotImplementedException();
        }
    }
}
