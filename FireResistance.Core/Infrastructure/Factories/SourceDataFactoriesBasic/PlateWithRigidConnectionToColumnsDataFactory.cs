using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic
{
    public class PlateWithRigidConnectionToColumnsDataFactory : IPlateWithRigidConnectionToColumnsDataFactory<PlateWithRigidConnectionToColumnsDataBasic>
    {
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out PlateWithRigidConnectionToColumnsDataBasic result)
        {
            throw new NotImplementedException();
        }
    }
}
