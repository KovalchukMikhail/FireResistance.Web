using FireResistance.Core.Entities.Materials.AbstractClasses;

namespace FireResistance.Core.Entities.Materials.BaseClasses
{
    public class Armature : Material
    {
        public int Diameter { get; set; }
        public int Count { get; set; }
        public double Area { get; set; }
        public double ResistNormativeForStretch { get; set; }
        public double ResistСalculationForStretch { get; set; }
        public double ResistСalculationForSqueeze { get; set; }
        public double ElasticityModulus { get; set; }
        //public Armature(string className, int diameter, int amount, double area,
        //                double resistNormativeForStretch, double resistСalculationForStretch,
        //                double resistСalculationForSqueeze, double elasticityModulus) : base(className) 
        //{
        //    Amount = amount;
        //    Diameter = diameter;
        //    Area = area;
        //    ResistNormativeForStretch = resistNormativeForStretch;
        //    ResistСalculationForStretch = resistСalculationForStretch;
        //    ResistСalculationForSqueeze = resistСalculationForSqueeze;
        //    ElasticityModulus = elasticityModulus;
        //}

        public override string ToString()
        {
            return $"Класс_арматуры_по_прочности {base.ClassName}:" +
                $"Диаметр_арматуры {Diameter}:" +
                $"Количество_арматуры {Count}:" +
                $"Площадь_арматуры {Area}:" +
                $"Нормативное_сопротивление_арматуры_растяжению {ResistNormativeForStretch}:" +
                $"Расчетное_сопротивление_арматуры_растяжению {ResistСalculationForStretch}:" +
                $"Расчетное_сопротивление_арматуры_сжатию {ResistСalculationForSqueeze}:" +
                $"Модуль_деформации_арматуры {ElasticityModulus}";
        }
    }
}
