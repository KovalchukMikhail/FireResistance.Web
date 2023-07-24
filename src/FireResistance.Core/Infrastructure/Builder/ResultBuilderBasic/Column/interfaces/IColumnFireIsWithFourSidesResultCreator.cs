using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces
{
    internal interface IColumnFireIsWithFourSidesResultCreator
    {
        public void AddConstructionDataToResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, ColumnFR column);

        public void AddResultIfLastIsEightDotTwentyThree(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);

        public void AddResultIfLastIsEightDotFifteen(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);

        public void AddResultIfLastIsEightDotTwentyFive(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values);
        public string BuildString(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result);
        public string BuildError(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result);
    }
}
