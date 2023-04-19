using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    public class DataOfSlabWithRigidConnectionToColumnsVM
    {
        public SlabWithRigidConnectionToColumnsData SourceData { get; set; }
        public ResultAsDictionary Result { get; set; }
        public DataOfSlabWithRigidConnectionToColumnsVM(SlabWithRigidConnectionToColumnsData sourceData)
        {
            SourceData = sourceData;
        }
    }
}
