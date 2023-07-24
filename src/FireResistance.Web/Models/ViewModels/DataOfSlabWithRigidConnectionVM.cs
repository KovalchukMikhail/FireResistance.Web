using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;

namespace FireResistance.Web.Models.ViewModels
{
    /// <summary>Класс содержит исходные данные и результаты расчета плиты перекрытия на огнестойкость</summary>
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
