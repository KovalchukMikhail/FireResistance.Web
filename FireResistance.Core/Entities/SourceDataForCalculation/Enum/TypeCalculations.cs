using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.Enum
{
    public enum TypeCalculations
    {
        ColumnFireIsWithFourSides,
        WallFireIsWithOneSide,
        PlateWithRigidConnectionToColumns,
        PlateWithRigidConnectionToTwoWalls
    }
}
