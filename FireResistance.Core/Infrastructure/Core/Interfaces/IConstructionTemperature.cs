using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IConstructionTemperature <T> where T: Construction
    {
        public double GetConcreteTemperature(T constraction, double criticalTemperature);
        public double GetArmatureTemperature(T construction);
    }
}
