using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataSP63
    {
        public double GetConcreteResistNormative(string concreteClass);
        public double GetConcreteStartElasticityModulus(string concreteClass);
        public double GetArmatureResistNormative(string armatureClass);
        public double GetArmatureResistSqueezeСalculation(string armatureClass);
        public double GetArmatureResistStretchСalculation(string armatureClass);


    }
}
