using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    internal interface IInterpolator
    {
        public double GetValueFromTable(List<string> namesOfRows, List<double> namesOfColumns, string rowName, int columnName, double table);
        public double GetValueFromTemperatureTable(List<double> namesOfRows, int rowName, double[,] table);

        public double GetIntermediateValue(double pointMaxValue, double pointMinValue, double curentPoint, double maxValue, double minValue);

        public double GetIntermediateValue(int pointMaxValue, int pointMinValue, double curentPoint, double maxValue, double minValue);
    }
}
