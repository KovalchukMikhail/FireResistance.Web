using CalculationException;
using FireResistance.Core.Infrastructure.Core.Interfaces;


namespace FireResistance.Core.Infrastructure.Core
{
    /// <summary>Класс содержит общие формулы</summary>
    internal class CommonEquations : ICommonEquations
    {
        /// <summary>Метод определяет момент инерции прямоугольного сечения</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение момента инерции прямоугольного сечения</returns>
        public double GetMomentOfInertiaOfConcrete(double bt, double ht) 
            => bt * Math.Pow(ht, 3) / 12;
        /// <summary>Метод определяет момент инерции арматуры в прямоугольном сечении</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение момента инерции арматуры в прямоугольном сечении</returns>
        public double GetMomentOfInertiaOfArmature(double As, double h, double a)
            => As * Math.Pow(h - 2 * a, 2) / 2;
        /// <summary>Метод определяет рабочую высоту сечения железобетонного элемента</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение рабочей высоты железобетонного элемента</returns>
        public double GetWorkHeight(double h, double a) => h - a;
        /// <summary>Метод определяет рабочую длину элемента</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение рабочей длины элемента</returns>
        public double GetWorkLenth(double l, double coefficientFixationElement) => l * coefficientFixationElement;
        /// <summary>Метод определяет коэффициент использования сечения</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение коэффициента использования элемента</returns>
        public double GetFinalСoefficient(double checkedValue, double criticalValue)
        {
            if (criticalValue == 0) throw new ValueException("Невозможно определить коэффициент использования так как критическое значение равно 0", criticalValue);
            return checkedValue / criticalValue;
        }
    }
}
