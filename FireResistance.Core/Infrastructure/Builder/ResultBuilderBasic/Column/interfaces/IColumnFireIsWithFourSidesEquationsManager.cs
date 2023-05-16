using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces
{
    internal interface IColumnFireIsWithFourSidesEquationsManager
    {
        public void RunPartOneOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartTwoOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartThreeOfEquations(TempValuesForColumn values, ColumnFR column);

        public bool RunEquationEightDotTwentyThree(TempValuesForColumn values, ColumnFR column);

        public bool RunPartFourOfEquations(TempValuesForColumn values, ColumnFR column);
    }
}
