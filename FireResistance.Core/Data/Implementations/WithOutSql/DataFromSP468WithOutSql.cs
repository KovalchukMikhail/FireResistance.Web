using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class DataFromSP468WithOutSql : IDataSP468RequestDb
    {
        public double [,] GetBetaBTable()
        {
            return DataFromSp468.TableBetaB;
        }

        public double [,] GetBetaSTable()
        {
            return DataFromSp468.TableBetaS;
        }

        public double [,] GetGammaBtTable()
        {
            return DataFromSp468.TableGammaBT;
        }

        public double [,] GetGammaStTable()
        {
            return DataFromSp468.TableGammaSt;
        }

        public double GetСoefficientFixationElement(string fixationElement)
        {
            bool check = DataFromSp468.FixationElementTable.TryGetValue(fixationElement, out double result);
            if (check) return result;
            return -1;
        }

        public double GetCriticalTemperatureConcrete(string concreteType)
        {
            bool check = TemperatureDataOfColumnFromSp468.CriticalTemperatureConcrete.TryGetValue(concreteType, out double result);
            if (check) return result;
            return -1;
        }

        public double[,] GetTableFiNumberEightDotOne()
        {
            return DataFromSp468.TableFiNumberEightDotOne;
        }
    }
}
