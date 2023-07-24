using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    /// <summary>Класс содержит коллекции исходных данных для расчета плит и колонн</summary>
    public class ArchiveVM
    {
        public List<ColumnFireIsWithFourSidesData> DataForColumn { get; set; }
        public List<SlabWithRigidConnectionData> DataForSlab { get; set; }

    }
}
