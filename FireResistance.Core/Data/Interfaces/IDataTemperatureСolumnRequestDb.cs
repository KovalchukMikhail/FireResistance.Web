using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data.Interfaces
{
    internal interface IDataTemperatureСolumnRequestDb
    {
        public double GetTemperatureOfСolumn(string fireResistans, int hight, int deep);
        public double GetDeepForSilicateСolumn(string fireResistans, int temperature);
        public double GetDeepForCarbonateСolumn(string fireResistans, int temperature);
        public double[,] GetArrayTemperature(string fireResistans, int height);
        public List<double> GetListOfDistanceToArmature(int height);
    }
}
