using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    public class ArchiveVM
    {
        public List<ColumnFireIsWithFourSidesData> DataForColumn { get; set; }
        public List<SlabWithRigidConnectionData> DataForSlab { get; set; }

    }
}
