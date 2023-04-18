using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    public class DataOfPlateWithRigidConnectionToColumnsVM
    {
        public PlateWithRigidConnectionToColumnsData SourceData { get; set; }
        public ResultAsDictionary Result { get; set; }
        public DataOfPlateWithRigidConnectionToColumnsVM(PlateWithRigidConnectionToColumnsData sourceData)
        {
            SourceData = sourceData;
        }
    }
}
