using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IColumnTemperature <T> where T : ColumnFR
    {
        public double GetArmatureTemperature(T column);
        public double GetConcreteTemperature(T column, double criticalTemperature);

    }
}
