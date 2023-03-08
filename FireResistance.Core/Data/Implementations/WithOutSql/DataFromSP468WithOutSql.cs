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
        public double GetBetaB(string concreteType, int temperature)
        {
            int concreteTypeIndex = NameColumns.ConcreteType.IndexOf(concreteType);
            int temperatureIndex = NameColumns.TemperatureForTable.IndexOf(temperature);
            if (concreteTypeIndex == -1 || temperatureIndex == -1) return -1;
            return DataFromSp468.TableBetaB[concreteTypeIndex, temperatureIndex];
        }

        public double GetBetaS(string armatureClass, int temperature)
        {
            int armatureClassIndex = NameColumns.ArmatureClass.IndexOf(armatureClass);
            int temperatureIndex = NameColumns.TemperatureForTable.IndexOf(temperature);
            if (armatureClassIndex == -1 || temperatureIndex == -1) return -1;
            return DataFromSp468.TableBetaS[armatureClassIndex, temperatureIndex];
        }

        public double GetGammaBT(string concreteType, int temperature)
        {
            int concreteTypeIndex = NameColumns.ConcreteType.IndexOf(concreteType);
            int temperatureIndex = NameColumns.TemperatureForTable.IndexOf(temperature);
            if (concreteTypeIndex == -1 || temperatureIndex == -1) return -1;
            return DataFromSp468.TableGammaBT[concreteTypeIndex, temperatureIndex];
        }

        public double GetGammaSt(string armatureClass, int temperature)
        {
            int armatureClassIndex = NameColumns.ArmatureClass.IndexOf(armatureClass);
            int temperatureIndex = NameColumns.TemperatureForTable.IndexOf(temperature);
            if (armatureClassIndex == -1 || temperatureIndex == -1) return -1;
            return DataFromSp468.TableGammaSt[armatureClassIndex, temperatureIndex];
        }

        public double GetСoefficientFixationElement(string fixationElement)
        {
            bool check = DataFromSp468.FixationElementTable.TryGetValue(fixationElement, out double result);
            if (check) return result;
            return -1;
        }
    }
}
