using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    public class DataOfSlabWithRigidConnectionVM
    {
        public SlabWithRigidConnectionData SourceData { get; set; }
        public ResultAsDictionary Result { get; set; }
        public DataOfSlabWithRigidConnectionVM(SlabWithRigidConnectionData sourceData)
        {
            SourceData = sourceData;
        }
    }
}
