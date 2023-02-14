using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataSP468
    {
        public double GetGammaBT(string concreteType, int temperature);
        public double GetBetaB(string concreteType, int temperature);
        public double GetGammaSt(string armatureClass, int temperature);
        public double GetBetaS(string armatureClass, int temperature);
        public double GetСoefficientFixationElement(string fixationElement);
    }
}
