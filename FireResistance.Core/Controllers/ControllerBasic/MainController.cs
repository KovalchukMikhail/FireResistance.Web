using FireResistance.Core.Controllers.Interfaces;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Controllers.ControllerBasic
{
    internal class MainController : IMainController
    {
        public bool Run(SourceData<Dictionary<string, string>> data) => data switch
        {
            ColumnFireIsWithFourSidesData<Dictionary<string, string>> => true,
            PlateWithRigidConnectionToColumnsData<Dictionary<string, string>> => true,
            PlateWithRigidConnectionToTwoWallsData<Dictionary<string, string>> => true,
            WallFireIsWithOneSideData<Dictionary<string, string>> => true,
            _ => false
        };
    }
}
