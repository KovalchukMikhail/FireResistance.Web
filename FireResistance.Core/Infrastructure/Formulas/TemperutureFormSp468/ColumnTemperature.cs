using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Infrastructure.Formulas.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Formulas.TemperutureFormSp468
{
    internal class ColumnTemperature : IConstructionTemperature <ColumnFR>
    {
        private RequestDb db;
        IInterpolator interpolator;
        int minSize;
        int mediumSize;
        int maxSize;
        

        public ColumnTemperature(RequestDb db, IInterpolator interpolator)
        {
            this.db = db;
            this.interpolator = interpolator;
            minSize = NameColumns.StandartHeight[0];
            mediumSize = NameColumns.StandartHeight[1];
            maxSize = NameColumns.StandartHeight[2];
        }

        public double GetArmatureTemperature(ColumnFR construction)
        {
            int size = Convert.ToInt32(Math.Min(construction.Width, construction.Height));

            if (size == minSize || size == mediumSize || size >= maxSize)
            {
                return GetTemperatureAtPoint(size, construction.distanceToArmature, construction);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetTemperatureAtPoint(minSize, construction.distanceToArmature, construction);
                double secondValue = GetTemperatureAtPoint(mediumSize, construction.distanceToArmature, construction);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetTemperatureAtPoint(mediumSize, construction.distanceToArmature, construction);
                double secondValue = GetTemperatureAtPoint(maxSize, construction.distanceToArmature, construction);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            else return -1;
        }

        public double GetConcreteTemperature(ColumnFR construction)
        {
            int size = Convert.ToInt32(Math.Min(construction.Width, construction.Height));

            if (size == minSize || size == mediumSize || size == maxSize)
            {
                return GetAveregeTemperature(size, construction);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetAveregeTemperature(minSize, construction);
                double secondValue = GetAveregeTemperature(mediumSize, construction);
                return interpolator.GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetAveregeTemperature(mediumSize, construction);
                double secondValue = GetAveregeTemperature(maxSize, construction);
                return interpolator.GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            if(size > maxSize)
            {
                return GetAveregeTemperature(maxSize, construction, (size - maxSize)/2);
            }
            else return -1;
        }

        private double GetTemperatureAtPoint(int size, int distanceToPoint, ColumnFR construction)
        {
            double[,] temperutureArray = db.TemperatureDb.GetArrayTemperature(construction.fireResistanceVolume, size);
            List<double> distanceToArmatureForArray = db.TemperatureDb.GetListOfDistanceToArmature(size);
            return interpolator.GetValueFromTemperatureTable(distanceToArmatureForArray, distanceToPoint, temperutureArray);
        }

        private double GetAveregeTemperature(int size, ColumnFR construction, int additionalSize = 0)
        {
            int positionForCalculation = construction.distanceFromBringToPointAverageTemperature > size / 2 ?
                size / 2
                : construction.distanceFromBringToPointAverageTemperature;
            double temperatureCount = 0;
            int count = 0;
            double last = 0;
            double currentTemperature = 0;
            double criticalTemperature = ((ConcreteForFR)construction.Concrete).criticalTemperature;
            for (int i = 0; i < positionForCalculation + 1; i++)
            {
                currentTemperature = GetTemperatureAtPoint(size, positionForCalculation, construction);
                if(currentTemperature <= criticalTemperature)
                {
                    temperatureCount += criticalTemperature;
                    count++;
                    last = currentTemperature;
                }
            }
            temperatureCount += last * additionalSize;
            if (temperatureCount == 0) return -1;
            else return temperatureCount/(count + additionalSize);

        }

    }
}
