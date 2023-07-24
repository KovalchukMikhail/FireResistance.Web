
namespace FireResistance.Core.Infrastructure.Utilities.Interfaces
{
    /// <summary>Интерфейс в общем описывает объект содержащий методы для определения фактических значений на основании имеющихся в таблицах значений</summary>
    internal interface IInterpolator
    {
        /// <summary>Метод определяет фактическое значение искомой переменной на основании переданных параметров и таблицы</summary>
        public double GetValueFromTable(List<string> namesOfRows, List<double> namesOfColumns, string rowName, double columnName, double[,] table);
        /// <summary>Метод определяет фактическое значение температуры на основании переданных параметров и таблицы</summary>
        public double GetValueFromTemperatureTableOfColumn(List<double> namesOfRows, int rowName, int columnName, double[,] table);
        /// <summary>Метод определяет фактическое значение искомой переменной на основании переданных граничных параметров</summary>
        public double GetIntermediateValue(double pointOfFirstValue, double pointOfSecondValue, double curentPoint, double firstValue, double secondValue);
        /// <summary>Метод определяет фактическое значение искомой переменной на основании переданных граничных параметров</summary>
        public double GetIntermediateValue(int pointOfFirstValue, int pointOfSecondValue, double curentPoint, double firstValue, double secondValue);
    }
}
