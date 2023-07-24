using FireResistance.Core.Infrastructure.Utilities.Interfaces;

namespace FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic
{
    /// <summary>Класс описывает методы необходимые для получения индекса элемента в списке</summary>
    internal class IndexDeterminantBasic : IIndexDeterminant
    {
        /// <summary>Метод определяет индекс первого вхождения элемента в списке</summary>
        public double GetIndex(string value, List<string> list)
        {    
            return list.IndexOf(value);
        }
        /// <summary>Метод определяет индекс вхождения элемента в списке чисел или промежуточное значение в виде ввещественного числа между которое характеризует положение искомого значения между значениями в списке</summary>
        public double GetIndex(double value, List<double> list)
        {
            double indexValue = list.IndexOf(value);
            
            if(indexValue == -1)
            {
                int preIndex = 0;
                int nextIndex = 0;
                double preValue = 0;
                double nextValue = 0;
                for(int i = 0; i < list.Count - 1; i++)
                {
                    preValue = list[i];
                    nextValue = list[i + 1];

                    if (preValue < value && nextValue > value) 
                    {
                        preIndex = i;
                        nextIndex = i + 1;
                        double appendix = (value - preValue)/(nextValue - preValue);
                        indexValue = appendix + preIndex;
                        break;
                    } 
                }
            }
            return indexValue;
        }

    }
}

