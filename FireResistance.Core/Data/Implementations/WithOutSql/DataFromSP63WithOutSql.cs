using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Data.Interfaces;

namespace FireResistance.Core.Data.Implementations.WithOutSql
{
    internal class DataFromSP63WithOutSql : IDataSP63RequestDb
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

        public double GetConcreteResistNormativeSqueeze(string concreteClass)
        {
            bool check = DataFromSp63.TableConcreteResistNormativeSqueeze.TryGetValue(concreteClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetConcreteResistNormativeStretch(string concreteClass)
        {
            bool check = DataFromSp63.TableConcreteResistNormativeStretch.TryGetValue(concreteClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetConcreteStartElasticityModulus(string concreteClass)
        {
            bool check = DataFromSp63.TableConcreteStartElasticityModulus.TryGetValue(concreteClass, out double result);
            if (check) return result;
            return -1;
        }

        public double GetArmatureElasticityModulus(string armatureClass)
        {
            return DataFromSp63.ArmatureElasticityModulus;
        }
    }
}
