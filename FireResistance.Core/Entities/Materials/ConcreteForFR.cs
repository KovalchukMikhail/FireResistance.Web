using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Materials
{
    internal class ConcreteForFR : Concrete
    {
        public double criticalTemperature { get; set; }
        public double Temperature { get; set; }
        public double GammaBT { get; set; }
        public double BetaB { get; set; }
        public double ResistWithTemperatureNormative { get; set; }

    }
}
