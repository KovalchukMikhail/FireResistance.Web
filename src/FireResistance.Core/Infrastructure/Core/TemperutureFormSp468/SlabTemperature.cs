﻿using CalculationException;
using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;

namespace FireResistance.Core.Infrastructure.Core.TemperutureFormSp468
{
    /// <summary>Класс описывает объект содержащий методы для определения температуры элементов плиты перекрытия</summary>
    internal class SlabTemperatureBasic : ISlabTemperature<SlabFR, SlabWithRigidConnectionData>
    {
        private RequestDb db;
        IInterpolator interpolator;
        NameColumns nameColumns;
        int minHeight;
        int maxHeight;


        public SlabTemperatureBasic(RequestDb db, IInterpolator interpolator, NameColumns nameColumns)
        {
            this.db = db;
            this.interpolator = interpolator;
            this.nameColumns = nameColumns;
            minHeight = nameColumns.BoundaryHeightOfSlab["min"];
            maxHeight = nameColumns.BoundaryHeightOfSlab["max"];
        }
        /// <summary>Метод определяет температуру в плите перекрытия на определенном расстоянии</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру °C</returns>
        public virtual double GetTemperature(SlabFR slab, double distanceToPoint, SlabWithRigidConnectionData sourceData)
        {
            if (slab.Height < distanceToPoint) throw new ValueException("Некорректное значение расстояния до точки в которой определяется температура", distanceToPoint);
            if (slab.Height >= minHeight && slab.Height <= maxHeight)
            {
                if (slab.Height % 20 == 0)
                {
                    return GetTemperatureAtPoint(slab.Height, distanceToPoint, sourceData.ConcreteType, slab.FireResistanceVolume);
                }
                else
                {   
                    GetTempValuesOfHeight(slab.Height, out int firstHeight, out int secondHeight);
                    double secondValue = GetTemperatureAtPoint(secondHeight, distanceToPoint, sourceData.ConcreteType, slab.FireResistanceVolume);
                    double firstValue;
                    if (firstHeight < distanceToPoint)
                        firstValue = GetTemperatureAtPoint(firstHeight, firstHeight, sourceData.ConcreteType, slab.FireResistanceVolume);
                    else firstValue = GetTemperatureAtPoint(firstHeight, distanceToPoint, sourceData.ConcreteType, slab.FireResistanceVolume);
                    return interpolator.GetIntermediateValue(firstHeight, secondHeight, slab.Height, firstValue, secondValue);
                }

            }
            else if(slab.Height >= maxHeight)
            {
                if (maxHeight > distanceToPoint)
                    return GetTemperatureAtPoint(maxHeight, distanceToPoint, sourceData.ConcreteType, slab.FireResistanceVolume);
                else return GetTemperatureAtPoint(maxHeight, maxHeight, sourceData.ConcreteType, slab.FireResistanceVolume);
            }
            else throw new Exception("Ошибка возникла при определении температуры плиты");
        }
        /// <summary>Метод определяет глубину прогрева бетона</summary>
        /// <returns>Возвращаемый тип double. Возвращает значение глубины прогрева бетона</returns>
        public virtual double GetDeepConcreteWarming(SlabFR slab, SlabWithRigidConnectionData sourceData, double criticalTemperature)
        {
            if (slab.Height >= minHeight && slab.Height <= maxHeight)
            {
                if (slab.Height % 20 == 0)
                {
                    for (int deep = 0; deep <= slab.Height; deep++)
                    {
                        if (GetTemperatureAtPoint(slab.Height, deep, sourceData.ConcreteType, slab.FireResistanceVolume) <= criticalTemperature)
                            return deep;
                    }
                    throw new ValueException("Все сечение нагрето выше предельно допустимой температуры", criticalTemperature);
                }
                else
                {
                    GetTempValuesOfHeight(slab.Height, out int firstHeight, out int secondHeight);
                    bool check = false;
                    double firstDeep = 0;
                    double secondDeep = 0;
                    for (firstDeep = 0; firstDeep <= firstHeight; firstDeep++)
                    {
                        if (GetTemperatureAtPoint(firstHeight, firstDeep, sourceData.ConcreteType, slab.FireResistanceVolume) <= criticalTemperature)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check) throw new ValueException("Все сечение нагрето выше предельно допустимой температуры", criticalTemperature);
                    check = false;
                    for (secondDeep = 0; secondDeep <= secondHeight; secondDeep++)
                    {
                        if (GetTemperatureAtPoint(firstHeight, secondDeep, sourceData.ConcreteType, slab.FireResistanceVolume) <= criticalTemperature)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check) throw new ValueException("Все сечение нагрето выше предельно допустимой температуры", criticalTemperature);
                    return interpolator.GetIntermediateValue(firstHeight, secondHeight, slab.Height, firstDeep, secondDeep);
                }

            }
            else if (slab.Height >= maxHeight)
            {
                for (int deep = 0; deep <= slab.Height; deep++)
                {
                    if (GetTemperatureAtPoint(maxHeight, deep, sourceData.ConcreteType, slab.FireResistanceVolume) <= criticalTemperature)
                        return deep;
                }
                throw new ValueException("Сечение нагрето выше критической температуры на глубину более 200 мм, невозможно определить глубину прогрева бетона до критической температуры", criticalTemperature);
            }
            else throw new Exception("Ошибка возникла при определении температуры плиты");
        }
        protected virtual List<double> GetNamesOfColumns(double height)
        {
            List<double> result = new List<double>();
            for (double i = 0; i <= height; i += 10) result.Add(i);
            return result;
        }
        /// <summary>Метод определяет температуру в определенной точке плиты перекрытия</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру в конкретной точке °C</returns>
        protected virtual double GetTemperatureAtPoint(int height, double distanceToPoint, string concreteType, string fireResistanceVolume)
        {
            double[,] table = db.TemperatureOfSlabDb.GetArrayTemperature(height, concreteType);
            if (fireResistanceVolume == "R150" && table[table.GetLength(0) - 1, 0] < 0) throw new Exception("Для сечения указанной высоты не предусмотренна возможность определения температуры при R150");
            List<double> namesOfColumns = GetNamesOfColumns(height);
            return interpolator.GetValueFromTable(nameColumns.FireResistanceForCriticalTemperature, namesOfColumns, fireResistanceVolume, distanceToPoint, table);
        }
        /// <summary>Метод на основании значения высоты плиты перекрытия возвращает значения высоты плиты перекрытия(ближайшее большее и ближайшее меньшее значение) содержащихся в таблицах и графиках для определения температур</summary>
        /// <returns>Возвращаемый тип double. Возвращает температуру в конкретной точке °C</returns>
        protected virtual void GetTempValuesOfHeight (int height, out int firstHeight, out int secondHeight)
        {
            secondHeight = 0;
            firstHeight = 0;
            for (int i = minHeight; i <= maxHeight; i += 20)
            {
                if (i > height)
                {
                    secondHeight = i;
                    firstHeight = i - 20;
                }
            }
        }
    }
}
