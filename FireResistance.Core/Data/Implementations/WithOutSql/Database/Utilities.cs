using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql.Database
{
    internal static class Utilities
    {
        public static double[,] GetCopyArray(double[,] array)
        {
            double[,] arrayNew = new double[array.GetLength(0), array.GetLength(1)];
            Array.Copy(array,
                        array.GetLowerBound(0),
                        arrayNew,
                        arrayNew.GetLowerBound(0),
                        array.GetLength(0) * array.GetLength(1));
            return arrayNew;
        }
    }
}
