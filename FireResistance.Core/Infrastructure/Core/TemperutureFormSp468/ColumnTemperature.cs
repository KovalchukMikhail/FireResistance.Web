using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.TemperutureFormSp468
{
    internal class ColumnTemperature : IConstructionTemperature <ColumnFR>
    {
        private RequestDb db;
        IInterpolator interpolator;
        int minSize;
        int mediumSize;
        int maxSize;
        NameColumns nameColumns;
        

        public ColumnTemperature(RequestDb db, IInterpolator interpolator, NameColumns nameColumns)
        {
            this.db = db;
            this.interpolator = interpolator;
            this.nameColumns = nameColumns;
            minSize = nameColumns.StandartHeight[0];
            mediumSize = nameColumns.StandartHeight[1];
            maxSize = nameColumns.StandartHeight[2];
        }

        public double GetArmatureTemperature(ColumnFR construction)
        {
            int size = Convert.ToInt32(Math.Min(construction.Width, construction.Height));

            if (size == minSize || size == mediumSize || size >= maxSize)
            {
                return GetTemperatureAtPoint(size, construction.DistanceToArmature, construction);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetTemperatureAtPoint(minSize, construction.DistanceToArmature, construction);
                double secondValue = GetTemperatureAtPoint(mediumSize, construction.DistanceToArmature, construction);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetTemperatureAtPoint(mediumSize, construction.DistanceToArmature, construction);
                double secondValue = GetTemperatureAtPoint(maxSize, construction.DistanceToArmature, construction);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            else return -1;
        }

        public double GetConcreteTemperature(ColumnFR construction, double criticalTemperature)
        {
            int size = Convert.ToInt32(Math.Min(construction.Width, construction.Height));

            if (size == minSize || size == mediumSize || size == maxSize)
            {
                return GetAveregeTemperature(size, construction, criticalTemperature);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetAveregeTemperature(minSize, construction, criticalTemperature);
                double secondValue = GetAveregeTemperature(mediumSize, construction, criticalTemperature);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetAveregeTemperature(mediumSize, construction, criticalTemperature);
                double secondValue = GetAveregeTemperature(maxSize, construction, criticalTemperature);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            if(size > maxSize)
            {
                return GetAveregeTemperature(maxSize, construction, criticalTemperature, (size - maxSize)/2);
            }
            else return -1;
        }

        private double GetTemperatureAtPoint(int size, int distanceToPoint, ColumnFR construction)
        {
            double[,] temperutureArray = db.TemperatureDb.GetArrayTemperature(construction.FireResistanceVolume, size);
            List<double> distanceToArmatureForArray = db.TemperatureDb.GetListOfDistanceToArmature(size);
            return interpolator.GetValueFromTemperatureTable(distanceToArmatureForArray, distanceToPoint, temperutureArray);
        }

        private double GetAveregeTemperature(int size, ColumnFR construction, double criticalTemperature, int additionalSize = 0)
        {
            int positionForCalculation = Convert.ToInt32(construction.DistanceFromBringToPointAverageTemperature) > (size / 2) ?
                (size / 2)
                : Convert.ToInt32(construction.DistanceFromBringToPointAverageTemperature);
            double temperatureSum = 0;
            int count = 0;
            double last = 0;
            double currentTemperature = 0;
            for (int i = 0; i < positionForCalculation + 1; i++)
            {
                currentTemperature = GetTemperatureAtPoint(size, i, construction);
                if(currentTemperature <= criticalTemperature)
                {
                    temperatureSum += currentTemperature;
                    count++;
                    last = currentTemperature;
                }
            }
            temperatureSum += last * additionalSize;
            if (temperatureSum == 0) return -1;
            else return temperatureSum/(count + additionalSize);

        }

    }
}
