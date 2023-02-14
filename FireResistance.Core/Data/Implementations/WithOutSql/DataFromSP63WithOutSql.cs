using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class DataFromSP63WithOutSql : IDataSP63
    {
        public double GetArmatureResistNormative(string armatureClass)
        {
            bool check = DataFromSp63.TableArmatureResistNormative.TryGetValue(armatureClass, out double result);
            if(check) return result;
            return -1;
        }

        public double GetArmatureResistSqueezeСalculation(string armatureClass)
        {
            bool check = DataFromSp63.TableArmatureResistSqueezeСalculation.TryGetValue(armatureClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetArmatureResistStretchСalculation(string armatureClass)
        {
            bool check = DataFromSp63.TableArmatureResistStretchСalculation.TryGetValue(armatureClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetConcreteResistNormative(string concreteClass)
        {
            bool check = DataFromSp63.TableConcreteResistNormative.TryGetValue(concreteClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetConcreteStartElasticityModulus(string concreteClass)
        {
            bool check = DataFromSp63.TableConcreteStartElasticityModulus.TryGetValue(concreteClass, out double result);
            if (check) return result;
            return -1;
        }
    }
}
