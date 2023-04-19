using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic
{
    internal class SlabWithRigidConnectionToTwoWallsDataFactory : ISlabWithRigidConnectionToTwoWallsDataFactory<SlabWithRigidConnectionToTwoWallsData>
    {
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out SlabWithRigidConnectionToTwoWallsData result)
        {
            throw new NotImplementedException();
        }
    }
}
