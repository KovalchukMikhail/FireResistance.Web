using FireResistance.Core.Entities.Materials.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Materials.BaseClasses
{
    public class Concrete : Material
    {
        public string Type { get; init; }
        public double ResistNormativeForStretch { get; init; }
        public double ResistNormativeForSqueeze { get; init; }
        public double StartElasticityModulus { get; init; }



        public Concrete(string className, string type, double resistNormativeForStretch,
            double resistNormativeForSqueeze, double startElasticityModulus) : base(className)
        {
            Type = type;
            ResistNormativeForStretch = resistNormativeForStretch;
            ResistNormativeForSqueeze = resistNormativeForSqueeze;
            StartElasticityModulus = startElasticityModulus;
        }

        public override string ToString()
        {
            return $"Класс_бетона_по_прочности {ClassName}:" +
                $"Вид_бетона {Type}:" +
                $"Нормативное_сопротивление_бетона_растяжению {ResistNormativeForStretch}:" +
                $"Нормативное_сопротивление_бетона_сжатию {ResistNormativeForSqueeze}:" +
                $"Модуль_деформации_бетона {StartElasticityModulus}";
        }
    }
}
