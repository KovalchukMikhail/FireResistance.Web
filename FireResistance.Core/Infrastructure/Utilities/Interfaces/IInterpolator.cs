using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IInterpolator
    {
        public double GetValueFromTable(List<string> namesOfRows, List<double> namesOfColumns, string rowName, double columnName, double[,] table);
        public double GetValueFromTemperatureTable(List<double> namesOfRows, int rowName, double[,] table);

        public double GetIntermediateValue(double pointOfFirstValue, double pointOfSecondValue, double curentPoint, double firstValue, double secondValue);

        public double GetIntermediateValue(int pointOfFirstValue, int pointOfSecondValue, double curentPoint, double firstValue, double secondValue);
    }
}
