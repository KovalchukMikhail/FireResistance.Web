using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Formulas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Formulas.TemperutureFormSp468
{
    internal class ColumnTemperature : IConstructionTemperature <ColumnFR>
    {
        private RequestDb db;


        public ColumnTemperature(RequestDb db)
        {
            this.db = db;
        }

        public double GetArmatureTemperature(ColumnFR construction)
        {
            throw new NotImplementedException();
        }

        public double GetConcreteTemperature(ColumnFR construction)
        {
            throw new NotImplementedException();
        }
    }
}
