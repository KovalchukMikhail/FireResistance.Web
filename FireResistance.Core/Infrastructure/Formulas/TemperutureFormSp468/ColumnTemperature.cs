using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Formulas.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Formulas.TemperutureFormSp468
{
    internal class ColumnTemperature : IConstructionTemperature <ColumnFR>
    {
        private RequestDb db;
        IInterpolator interpolator;
        

        public ColumnTemperature(RequestDb db, IInterpolator interpolator)
        {
            this.db = db;
            this.interpolator = interpolator;
        }

        public double GetArmatureTemperature(ColumnFR construction)
        {
            int minSize = NameColumns.StandartHeight[0];
            int mediumSize = NameColumns.StandartHeight[1];
            int maxSize = NameColumns.StandartHeight[2];
            int size = Convert.ToInt32(Math.Min(construction.Width, construction.Height));

            if (size == minSize || size == mediumSize || size >= maxSize)
            {
                return GetTemperatureAtPoint(size, construction);
            }
            else if (size > minSize && size < mediumSize)
            {
                double firstValue = GetTemperatureAtPoint(minSize, construction);
                double secondValue = GetTemperatureAtPoint(mediumSize, construction);
                return GetIntermediateValue(minSize, mediumSize, size, firstValue, secondValue);
            }
            else if (size > mediumSize && size < maxSize)
            {
                double firstValue = GetTemperatureAtPoint(mediumSize, construction);
                double secondValue = GetTemperatureAtPoint(maxSize, construction);
                return GetIntermediateValue(mediumSize, maxSize, size, firstValue, secondValue);
            }
            else return -1;
        }

        public double GetConcreteTemperature(ColumnFR construction)
        {
            throw new NotImplementedException();
        }

        private double GetTemperatureAtPoint(int size, ColumnFR construction)
        {
            double[,] temperutureArray = db.TemperatureDb.GetArrayTemperature(construction.fireResistanceVolume, size);
            List<int> distanceToArmatureForArray = db.TemperatureDb.GetListOfDistanceToArmature(size);
            return interpolator.GetValueFromTemperatureTable(distanceToArmatureForArray, construction.distanceToArmature, temperutureArray);
        }

        private double GetIntermediateValue(double minSize, double maxSize, double size, double temperatureOfMinSize, double temperatureOfMaxSize)
        {
            return temperatureOfMinSize - (size - minSize) * (temperatureOfMinSize - temperatureOfMaxSize) / (maxSize - minSize);
        }
    }
}
