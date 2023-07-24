
namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    /// <summary>Интерфейс в общем описывает методы необходимые для получения индекса элемента в списке</summary>
    internal interface IIndexDeterminant
    {
        /// <summary>Метод определяет индекс первого вхождения элемента в списке</summary>
        public double GetIndex(string value, List<string> list);
        /// <summary>Метод определяет индекс вхождения элемента в списке чисел или промежуточное значение в виде ввещественного числа между которое характеризует положение искомого значения между значениями в списке</summary>
        public double GetIndex(double value, List<double> list);
    }
}
