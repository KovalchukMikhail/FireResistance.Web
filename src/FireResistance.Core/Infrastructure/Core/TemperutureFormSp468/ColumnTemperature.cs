using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;

namespace FireResistance.Core.Infrastructure.Core.TemperutureFormSp468
{
    /// <summary>Класс описывает объект содержащий методы для определения температуры элементов колонны</summary>
    internal class ColumnTemperatureBasic : IColumnTemperature<ColumnFR>
    {
        private RequestDb db;
        IInterpolator interpolator;
        int minSize;
        int mediumSize;
        int maxSize;
        NameColumns nameColumns;
        

        public ColumnTemperatureBasic(RequestDb db, IInterpolator interpolator, NameColumns nameColumns) 
        {
            this.db = db;
            this.interpolator = interpolator;
            this.nameColumns = nameColumns;
            minSize = nameColumns.StandartHeightOfColumn["min"];
            mediumSize = nameColumns.StandartHeightOfColumn["medium"];
            maxSize = nameColumns.StandartHeightOfColumn["max"];
        }
        /// <summary>Метод определяет температуру арматуры в колонне</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру арматуры °C</returns>
        public virtual double GetArmatureTemperature(ColumnFR column)
        {
            int size = Convert.ToInt32(Math.Min(column.Width, column.Height));

            if (size == minSize || size == mediumSize || size == maxSize)
            {
                return GetTemperatureAtPoint(size, column.DistanceToArmature, column.DistanceToArmature, column);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetTemperatureAtPoint(minSize, column.DistanceToArmature, column.DistanceToArmature, column);
                double secondValue = GetTemperatureAtPoint(mediumSize, column.DistanceToArmature, column.DistanceToArmature, column);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetTemperatureAtPoint(mediumSize, column.DistanceToArmature, column.DistanceToArmature, column);
                double secondValue = GetTemperatureAtPoint(maxSize, column.DistanceToArmature, column.DistanceToArmature, column);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            else if (size > maxSize)
            {
                return GetTemperatureAtPoint(maxSize, column.DistanceToArmature, column.DistanceToArmature, column);
            }
            else throw new Exception("Ошибка возникла при определении температуры арматуры");
        }
        /// <summary>Метод определяет температуру бетона в колонне</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру бетона °C</returns>
        public virtual double GetConcreteTemperature(ColumnFR column, double criticalTemperature)
        {
            int size = Convert.ToInt32(Math.Min(column.Width, column.Height));

            if (size == minSize || size == mediumSize || size == maxSize)
            {
                return GetAveregeTemperature(size, column, criticalTemperature);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetAveregeTemperature(minSize, column, criticalTemperature);
                double secondValue = GetAveregeTemperature(mediumSize, column, criticalTemperature);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetAveregeTemperature(mediumSize, column, criticalTemperature);
                double secondValue = GetAveregeTemperature(maxSize, column, criticalTemperature);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            if(size > maxSize)
            {
                return GetAveregeTemperature(maxSize, column, criticalTemperature, (size - maxSize)/2);
            }
            else throw new Exception("Ошибка возникла при определении температуры бетона");
        }
        /// <summary>Метод определяет температуру в определенной точке колонны</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру в конкретной точке °C</returns>
        protected virtual double GetTemperatureAtPoint(int size, int distanceToPointByX, int distanceToPointByY, ColumnFR construction)
        {
            double[,] temperutureArray = db.TemperatureOfColumnDb.GetArrayTemperature(construction.FireResistanceVolume, size);
            List<double> distanceToArmatureForArray = db.TemperatureOfColumnDb.GetListOfDistanceToArmature(size);
            return interpolator.GetValueFromTemperatureTableOfColumn(distanceToArmatureForArray, distanceToPointByX, distanceToPointByY, temperutureArray);
        }
        /// <summary>Метод определяет среднюю температуру в определенной линии сечения</summary>
        /// <returns>Возвращаемый тип double. Возвращает среднюю температуру распределенную по определенной линии сечения °C</returns>
        protected virtual double GetAveregeTemperature(int size, ColumnFR construction, double criticalTemperature, int additionalSize = 0)
        {
            int positionForCalculation = Convert.ToInt32(construction.DistanceFromBringToPointAverageTemperature) > (size / 2) ?
                (size / 2)
                : Convert.ToInt32(construction.DistanceFromBringToPointAverageTemperature);
            int maxIndex = size / 2;
            double temperatureSum = 0;
            int count = 0;
            double last = 0;
            double currentTemperature = 0;
            for (int i = 0; i < maxIndex + 1; i++)
            {
                currentTemperature = GetTemperatureAtPoint(size, positionForCalculation, i, construction);
                if(currentTemperature <= criticalTemperature)
                {
                    temperatureSum += currentTemperature;
                    count++;
                    last = currentTemperature;
                }
            }
            temperatureSum += last * additionalSize;
            if (temperatureSum == 0) throw new Exception("Ошибка возникла при определении температуры бетона");
            else return temperatureSum/(count + additionalSize);

        }

    }
}
