using FireResistance.Core.Entities.Materials.AbstractClasses;

namespace FireResistance.Core.Entities.Materials.BaseClasses
{
    /// <summary>Класс содержит описание бетона</summary>
    public class Concrete : Material
    {
        public string TypeName { get; set; }
        public double ResistNormativeForStretch { get; set; }
        public double ResistNormativeForSqueeze { get; set; }
        public double StartElasticityModulus { get; set; }
        public override string ToString()
        {
            return $"Класс_бетона_по_прочности {ClassName}:" +
                $"Вид_бетона {TypeName}:" +
                $"Нормативное_сопротивление_бетона_растяжению {ResistNormativeForStretch}:" +
                $"Нормативное_сопротивление_бетона_сжатию {ResistNormativeForSqueeze}:" +
                $"Модуль_деформации_бетона {StartElasticityModulus}";
        }
    }
}
