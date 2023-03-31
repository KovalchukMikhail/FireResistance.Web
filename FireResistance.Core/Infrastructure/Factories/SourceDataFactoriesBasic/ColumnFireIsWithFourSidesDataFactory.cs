﻿using FireResistance.Core.Data;
using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.Enum;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.SourceDataFactory;
using FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic
{
    public class ColumnFireIsWithFourSidesDataFactory : IColumnFireIsWithFourSidesDataFactory<ColumnFireIsWithFourSidesData>
    {
        private NameColumns nameColumns;

        public ColumnFireIsWithFourSidesDataFactory(NameColumns nameColumns)
        {
            this.nameColumns = nameColumns;
        }
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out ColumnFireIsWithFourSidesData result)
        {
            result = new ColumnFireIsWithFourSidesData();
            Utilities utilit = new Utilities();
            string[] keys = {ConstantsName.fireResistanceLabel,
                            ConstantsName.LenthElementLabel,
                            ConstantsName.HeighElementLabel,
                            ConstantsName.WidthElementLabel,
                            ConstantsName.ArmatureClassLabel,
                            ConstantsName.ArmatureDiameterLabel,
                            ConstantsName.ArmatureCountLabel,
                            ConstantsName.ArmatureInstallationDepthLabel,
                            ConstantsName.ConcreteClassLabel,
                            ConstantsName.ConcreteTypeLabel,
                            ConstantsName.FixationElementLabel,
                            ConstantsName.MomentLabel,
                            ConstantsName.StrengthLabel};

            if (!utilit.CheckCountValue(stringValues, doubleValues, keys)) return false;

            string tempStr = stringValues[ConstantsName.fireResistanceLabel];
            if (nameColumns.FireResistanceForCriticalTemperature.IndexOf(tempStr) != -1) result.FireResistanceValue = tempStr;
            else return false;

            double tempNumber = doubleValues[ConstantsName.LenthElementLabel];
            if (tempNumber > 0) result.LengthColumn = (int)tempNumber;
            else return false;

            tempNumber = doubleValues[ConstantsName.HeighElementLabel];
            if (tempNumber >= 200) result.HeighColumn = (int)tempNumber;
            else return false;

            tempNumber = doubleValues[ConstantsName.WidthElementLabel];
            if (tempNumber >= 200) result.WidthColumn = (int)tempNumber;
            else return false;

            tempStr = stringValues[ConstantsName.ArmatureClassLabel];
            if (nameColumns.ArmatureClass.IndexOf(tempStr) != -1) result.ArmatureClass = tempStr;
            else return false;

            tempNumber = doubleValues[ConstantsName.ArmatureDiameterLabel];
            if (nameColumns.ArmatureDiameter.IndexOf((int)tempNumber) != -1) result.ArmatureDiameter = (int)tempNumber;
            else return false;

            tempNumber = doubleValues[ConstantsName.ArmatureCountLabel];
            if (tempNumber > 0) result.ArmatureCount = (int)tempNumber;
            else return false;

            tempNumber = doubleValues[ConstantsName.ArmatureInstallationDepthLabel];
            if (tempNumber <= result.HeighColumn / 2 && tempNumber <= result.WidthColumn / 2) result.ArmatureInstallationDepth = (int)tempNumber;
            else return false;

            tempStr = stringValues[ConstantsName.ConcreteClassLabel];
            if (nameColumns.ConcreteClass.IndexOf(tempStr) != -1) result.ConcreteClass = tempStr;
            else return false;

            tempStr = stringValues[ConstantsName.ConcreteTypeLabel];
            if (nameColumns.ConcreteType.IndexOf(tempStr) != -1) result.ConcreteType = tempStr;
            else return false;

            tempStr = stringValues[ConstantsName.FixationElementLabel];
            if (nameColumns.FixationElement.IndexOf(tempStr) != -1) result.FixationElement = tempStr;
            else return false;

            tempNumber = doubleValues[ConstantsName.MomentLabel];
            if (tempNumber >= 0) result.Moment = tempNumber;
            else return false;

            tempNumber = doubleValues[ConstantsName.StrengthLabel];
            if (tempNumber >= 0) result.Strength = tempNumber;
            else return false;
            
            return result.Check = true;

        }

    }
}
