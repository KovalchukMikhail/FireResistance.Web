using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public double GetValueFromTable(List<string> namesOfRows, List<double> namesOfColumns, string rowName, double columnName, double [,] table)
        {
            int rowIndex = Convert.ToInt32(IndexDeterminant.GetIndex(rowName, namesOfRows));
            double columnIndex = IndexDeterminant.GetIndex(columnName, namesOfColumns);
            if(columnIndex % 1 == 0 && rowIndex != -1)
            {
                return table[rowIndex, Convert.ToInt32(columnIndex)];
            }
            else if (rowIndex != -1 && columnIndex != -1)
            {
                int indexFirst = Convert.ToInt32(Math.Truncate(columnIndex));
                int indexNext = indexFirst + 1;
                double firstValue = table[rowIndex, indexFirst];
                double nextValue = table[rowIndex, indexNext];
                return GetIntermediateValue(indexFirst, indexNext, columnIndex, firstValue, nextValue);
            }
            else return -1;
        }

        public double GetValueFromTemperatureTable(List<double> namesOfRows, int rowName, int columnName, double[,] table)
        {
            double indexRow = IndexDeterminant.GetIndex(rowName, namesOfRows);
            double indexColumn = IndexDeterminant.GetIndex(columnName, namesOfRows);

            if (indexRow % 1 == 0 && indexColumn % 1 == 0)
            {
                int indexRowInt = Convert.ToInt32(indexRow);
                int indexColumnInt = Convert.ToInt32(indexColumn);
                return table[indexRowInt, indexColumnInt];
            }
            else if (indexRow != -1 && indexColumn != -1)
            {
                int indexFirstRow = Convert.ToInt32(Math.Truncate(indexRow));
                int indexFirstColumn = Convert.ToInt32(Math.Truncate(indexColumn));
                int indexNextRow = indexFirstRow + 1;
                int indexNextColumn = indexFirstColumn + 1;
                double firstValue = table[indexFirstRow, indexFirstColumn];
                double nextValue = table[indexNextRow, indexNextColumn];
                return GetIntermediateValue(indexFirst, indexNext, index, firstValue, nextValue);
            }
            else return -1;
        }

        public double GetIntermediateValue(double pointOfFirstValue, double pointOfSecondValue, double curentPoint, double firstValue, double secondValue)
        {
            if (firstValue < secondValue)
            {
                return GetIntermediateValue(pointOfSecondValue, pointOfFirstValue, curentPoint, secondValue, firstValue);
            }
            else
            {
                if (curentPoint > pointOfFirstValue)
                {
                    return firstValue - (curentPoint - pointOfFirstValue) * (firstValue - secondValue) / (pointOfSecondValue - pointOfFirstValue);
                }
                else
                {
                    return secondValue + (curentPoint - pointOfSecondValue) * (firstValue - secondValue) / (pointOfFirstValue - pointOfSecondValue);
                }
            }

        }

        public double GetIntermediateValue(int pointOfFirstValue, int pointOfSecondValue, double curentPoint, double firstValue, double secondValue)
        {
            if (firstValue < secondValue)
            {
                return GetIntermediateValue(pointOfSecondValue, pointOfFirstValue, curentPoint, secondValue, firstValue);
            }
            else
            {
                if (curentPoint > pointOfFirstValue)
                {
                    return firstValue - (curentPoint - pointOfFirstValue) * (firstValue - secondValue) / (pointOfSecondValue - pointOfFirstValue);
                }
                else
                {
                    return secondValue + (curentPoint - pointOfSecondValue) * (firstValue - secondValue) / (pointOfFirstValue - pointOfSecondValue);
                }
            }
        }
    }
}
