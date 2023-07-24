namespace FireResistance.Core
{
    /// <summary>Класс представляет точку входа для запуска расчета на огнестойкость</summary>
    internal interface IFireResistance <N, K>
    {
        /// <summary>Метод запускает процесс расчета конструкций на огнестойкость</summary>
        public void PerformCalculation(K data);
        /// <summary>Метод возвращает ссылку на объект хранящий результаты расчета на огнестойкость</summary>
        public N GetResult();
    }
}
