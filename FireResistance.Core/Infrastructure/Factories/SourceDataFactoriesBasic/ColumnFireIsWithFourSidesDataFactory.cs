using FireResistance.Core.Data;
using FireResistance.Core.Data.Implementations.WithOutSql.Database;
using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
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
        public bool TryCreate(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, out ColumnFireIsWithFourSidesData result)
        {
            result = new ColumnFireIsWithFourSidesData();
            Utilities utilit = new Utilities();
            string[] keys = {ConstantsName.fireResistanceLabel,
                            ConstantsName.LenthElementLabel,
                            ConstantsName.HighElementLabel,
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



            //result.Check = stringValues.TryGetValue("Предел_огнестойкости", out string resistance);
            //if (result.Check && NameColumns.FireResistanceForCriticalTemperature.IndexOf(resistance) >= 0) result.FireResistanceValue = resistance;
            //else return false;






        }

    }
}
