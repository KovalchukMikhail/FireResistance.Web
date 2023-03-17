using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataSP468RequestDb
    {
        public double[,] GetGammaBtTable();
        public double[,] GetBetaBTable();
        public double[,] GetGammaStTable();
        public double[,] GetBetaSTable();
        public double GetСoefficientFixationElement(string fixationElement);
        public double GetCriticalTemperatureConcrete(string concreteType);
        public double[,] GetTableFiNumberEightDotOne();
    }
}
