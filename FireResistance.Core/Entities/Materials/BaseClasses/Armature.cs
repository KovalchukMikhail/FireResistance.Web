using FireResistance.Core.Entities.Materials.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Materials.BaseClasses
{
    public class Armature : Material
    {
        public int Diameter { get; init; }
        public int Amount { get; init; }
        public double Area { get; init; }
        public double ResistNormativeForStretch { get; init; }
        public double ResistСalculationForStretch { get; init; }
        public double ResistСalculationForSqueeze { get; init; }
        public double ElasticityModulus { get; init; }
        public Armature(string className, int diameter, int amount, double area,
                        double resistNormativeForStretch, double resistСalculationForStretch,
                        double resistСalculationForSqueeze, double elasticityModulus) : base(className) 
        {
            Amount = amount;
            Diameter = diameter;
            Area = area;
            ResistNormativeForStretch = resistNormativeForStretch;
            ResistСalculationForStretch = resistСalculationForStretch;
            ResistСalculationForSqueeze = resistСalculationForSqueeze;
            ElasticityModulus = elasticityModulus;
        }

        public override string ToString()
        {
            return $"Класс_арматуры_по_прочности {base.ClassName}:" +
                $"Диаметр_арматуры {Diameter}:" +
                $"Количество_арматуры {Amount}:" +
                $"Площадь_арматуры {Area}:" +
                $"Нормативное_сопротивление_арматуры_растяжению {ResistNormativeForStretch}:" +
                $"Расчетное_сопротивление_арматуры_растяжению {ResistСalculationForStretch}:" +
                $"Расчетное_сопротивление_арматуры_сжатию {ResistСalculationForSqueeze}:" +
                $"Модуль_деформации_арматуры {ElasticityModulus}";
        }
    }
}
