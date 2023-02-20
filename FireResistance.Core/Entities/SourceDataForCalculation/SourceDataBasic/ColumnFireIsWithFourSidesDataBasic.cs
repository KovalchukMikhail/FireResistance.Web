using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic
{
    public class ColumnFireIsWithFourSidesDataBasic : ColumnFireIsWithFourSidesData<Dictionary<string, string>>
    {
        public string FireResistanceValue { get; set; }
        public int LengthColumn { get; set; }
        public int HighColumn { get; set; }
        public int WidthColumn { get; set; }
        public int ArmatureInstallationDepth { get; set; }
        public string FixationElement { get; set; }
        public string ArmatureClass { get; set; }
        public string ConcreteType { get; set; }
        public string ConcreteClass { get; set; }
        public int ArmatureDiameter { get; set; }
        public int ArmatureCount { get; set; }
        public double Moment { get; set; }
        public double Strength { get; set; }


        public override Dictionary<string, string> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
