using FireResistance.Core.Entities.Materials.BaseClasses;

namespace FireResistance.Core.Entities.Materials
{
    /// <summary>Класс содержит описание бетона для выполнения расчетов на огнестойкость</summary>
    internal class ConcreteForFR : Concrete
    {
        public double CriticalTemperature { get; set; }
        public double Temperature { get; set; }
        public double GammaBT { get; set; }
        public double BetaB { get; set; }
        public double ResistWithTemperatureNormativeForSqueeze { get; set; }
        public double ElasticityModulusWithWarming { get; set; }

    }
}
