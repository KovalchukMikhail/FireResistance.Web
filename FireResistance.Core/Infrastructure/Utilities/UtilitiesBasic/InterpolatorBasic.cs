using FireResistance.Core.ExceptionFR;
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

            if (columnIndex < 0 || rowIndex < 0) throw new Exception("Недопустимое значение индексов при определении значения в таблице");

            if (columnIndex % 1 == 0)
            {
                return table[rowIndex, Convert.ToInt32(columnIndex)];
            }
            else
            {
                int indexFirst = Convert.ToInt32(Math.Truncate(columnIndex));
                int indexNext = indexFirst + 1;
                double firstValue = table[rowIndex, indexFirst];
                double nextValue = table[rowIndex, indexNext];
                return GetIntermediateValue(indexFirst, indexNext, columnIndex, firstValue, nextValue);
            }
        }

        public double GetValueFromTemperatureTable(List<double> namesOfRows, int rowName, int columnName, double[,] table)
        {
            double indexRow = IndexDeterminant.GetIndex(rowName, namesOfRows);
            double indexColumn = IndexDeterminant.GetIndex(columnName, namesOfRows);

            if (indexRow < 0 || indexColumn < 0) throw new Exception("Недопустимое значение индексов при определении значения температуры");

            if (indexRow % 1 == 0 && indexColumn % 1 == 0)
            {
                int indexRowInt = Convert.ToInt32(indexRow);
                int indexColumnInt = Convert.ToInt32(indexColumn);
                return table[indexRowInt, indexColumnInt];
            }
            else if (indexRow == indexColumn)
            {
                int indexFirstRow = Convert.ToInt32(Math.Truncate(indexRow));
                int indexNextRow = indexFirstRow + 1;
                double firstValue = table[indexFirstRow, indexFirstRow];
                double nextValue = table[indexNextRow, indexNextRow];
                return GetIntermediateValue(indexFirstRow, indexNextRow, indexRow, firstValue, nextValue);
            }
            else
            {
                int size = namesOfRows.Count;
                int indexFirstRow = Convert.ToInt32(Math.Truncate(indexRow));
                int indexFirstColumn = Convert.ToInt32(Math.Truncate(indexColumn));
                int indexNextRow = indexFirstRow < size - 1 ? indexFirstRow + 1 : indexFirstRow;
                int indexNextColumn = indexFirstColumn < size - 1 ? indexFirstColumn + 1 : indexFirstColumn;
                double firstValue = table[indexFirstRow, indexFirstColumn];
                double secondValue = table[indexFirstRow, indexNextColumn];
                double thirdValue = table[indexNextRow, indexFirstColumn];
                double fourthValue = table[indexNextRow, indexNextColumn];
                double ValueBetweenFirstAndSecond = GetIntermediateValue(indexFirstColumn, indexNextColumn, indexColumn, firstValue, secondValue);
                double ValueBetweenThirdAndFourth = GetIntermediateValue(indexFirstColumn, indexNextColumn, indexColumn, thirdValue, fourthValue);
                return GetIntermediateValue(indexFirstRow, indexNextRow, indexRow, ValueBetweenFirstAndSecond, ValueBetweenThirdAndFourth);
            }
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
