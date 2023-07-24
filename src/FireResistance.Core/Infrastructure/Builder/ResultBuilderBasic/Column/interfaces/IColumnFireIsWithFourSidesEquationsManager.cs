using FireResistance.Core.Entities.Constructions.ConstructionBasic;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces
{
    /// <summary>Интерфейс содержит общее описание методов запускающих в правельной последовательности формулы для расчета колонны на огнестойкость</summary>
    internal interface IColumnFireIsWithFourSidesEquationsManager
    {
        public void RunPartOneOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartTwoOfEquations(TempValuesForColumn values, ColumnFR column);

        public void RunPartThreeOfEquations(TempValuesForColumn values, ColumnFR column);

        public bool RunEquationEightDotTwentyThree(TempValuesForColumn values, ColumnFR column);

        public bool RunPartFourOfEquations(TempValuesForColumn values, ColumnFR column);
    }
}
