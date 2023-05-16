using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    public class DataOfColumnFireFourSideVM
    {
        public ColumnFireIsWithFourSidesData SourceData { get; set; }
        public ResultAsDictionary Result { get; set; }
        public DataOfColumnFireFourSideVM(ColumnFireIsWithFourSidesData sourceData)
        {
            SourceData = sourceData;
        }
    }
}
