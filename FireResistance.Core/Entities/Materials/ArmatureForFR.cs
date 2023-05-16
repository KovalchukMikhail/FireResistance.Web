using FireResistance.Core.Entities.Materials.BaseClasses;

namespace FireResistance.Core.Entities.Materials
{
    internal class ArmatureForFR : Armature
    {
        public double Temperature { get; set; }
        public double ResistWithTemperatureNormative { get; set; }

        public double ResistSqueezeWithTemperatureСalculation { get; set; }

        public double ResistStretchWithTemperatureСalculation { get; set; }
        public double ElasticityModulusWithWarming { get; set; }
        public double GammaST { get; set; }
        public double BetaS { get; set; }



    }
}
