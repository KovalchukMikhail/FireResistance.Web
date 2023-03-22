using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces
{
    internal interface IColumnFireIsWithFourSidesResultCreator
    {
        public void AddConstructionDataToResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, ColumnFR column);

        public void AddResultIfLastIsEightDotTwentyThree(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);

        public void AddResultIfLastIsEightDotFifteen(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);

        public void AddResultIfLastIsEightDotTwentyFive(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);
        public string BuildString(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result);
    }
}
