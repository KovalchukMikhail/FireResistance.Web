using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic
{
    internal class WallFireIsWithOneSideData : SourceData<Dictionary<string, string>>
    {
        public WallFireIsWithOneSideData(TypeCalculations type) : base(type) { }
        public override Dictionary<string, string> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
