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
        IIndexDeterminant IndexDeterminant { get; set; }
        public InterpolatorBasic(IIndexDeterminant indexDeterminant)
        {
            IndexDeterminant = indexDeterminant;
        }

        public double GetValueFromTable(List<string> namesOfRows, List<double> namesOfColumns, string rowName, int columnName, double table)
        {
            throw new NotImplementedException();
        }

        public double GetValueFromTemperatureTable(List<double> namesOfRows, int rowName, double[,] table)
        {
            double index = IndexDeterminant.GetIndex(rowName, namesOfRows);

            if (index % 1 == 0)
            {
                int indexInt = Convert.ToInt32(index);
                return table[indexInt, indexInt];
            }
            else if (index != -1)
            {
                int indexFirst = Convert.ToInt32(Math.Truncate(index));
                int indexNext = indexFirst + 1;
                double firstValue = table[indexFirst, indexFirst];
                double nextValue = table[indexNext, indexNext];
                return GetIntermediateValue(indexFirst, indexNext, index, firstValue, nextValue);
            }
            else return -1;
        }

        public double GetIntermediateValue(double pointOfMaxValue, double pointOfMinValue, double curentPoint, double maxValue, double minValue)
        {
            if(curentPoint > pointOfMaxValue)
            {
                return maxValue - (curentPoint - pointOfMaxValue) * (maxValue - minValue) / (pointOfMinValue - pointOfMaxValue);
            }
            else
            {
                return minValue + (curentPoint - pointOfMinValue) * (maxValue - minValue) / (pointOfMaxValue - pointOfMinValue);
            } 
        }

        public double GetIntermediateValue(int pointOfMaxValue, int pointOfMinValue, double curentPoint, double maxValue, double minValue)
        {
            if (curentPoint > pointOfMaxValue)
            {
                return maxValue - (curentPoint - pointOfMaxValue) * (maxValue - minValue) / (pointOfMinValue - pointOfMaxValue);
            }
            else
            {
                return minValue + (curentPoint - pointOfMinValue) * (maxValue - minValue) / (pointOfMaxValue - pointOfMinValue);
            }
        }
    }
}
