using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic;
using FireResistance.Logger;



namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>
    {
        private CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result;
        private ColumnFireIsWithFourSidesData sourceData;
        private ColumnFR column;
        private ColumnFactoryFR columnFactory;
        private TempValuesForColumn values;
        private IColumnFireIsWithFourSidesEquationsManager equationsManager;
        private IColumnFireIsWithFourSidesResultCreator resultCreator;
        private FileLogger logger;

        private bool firstTime { get; set; } = true;

        public ColumnFireIsWithFourSidesResultBuilder(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result,
                                                        TempValuesForColumn values,
                                                        IColumnFireIsWithFourSidesEquationsManager equationsManager,
                                                        ColumnFactoryFR columnFactory,
                                                        IColumnFireIsWithFourSidesResultCreator resultCreator,
                                                        FileLogger logger)
        {
            this.result = result;
            this.values = values;
            this.equationsManager = equationsManager;
            this.columnFactory = columnFactory;
            this.resultCreator = resultCreator;
            this.logger = logger;
        }

        public void SetSourceData(SourceData sourceData)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData;
        }

        public void BuildConstructions()
        {
            try
            {
                column = columnFactory.Create(sourceData) as ColumnFR;
            }
            catch (ExceptionFRBasic ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"DateTime:{DateTime.Now}; {ex.Message}. Значение переменной вызвавшей ошибку равно {ex.InvalidValue}");
            }
            catch (Exception ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"{ex.Message}.");
            }

        }
        
        public void BuildCalculation()
        {
            if (result.ExeptionList.Count > 0) return;
            try
            {
                equationsManager.RunPartOneOfEquations(values, column);
                if (values.e0 <= Convert.ToDouble(column.Height) / 30 && values.Lambda <= 20)
                {
                    values.FinalEquation = values.MainEquations[0];
                    result.Status = equationsManager.RunEquationEightDotTwentyThree(values, column);
                    return;
                }
                equationsManager.RunPartTwoOfEquations(values, column);
                if (values.Ncr <= column.Strength)
                {
                    values.FinalEquation = values.MainEquations[1];
                    result.Status = false;
                    return;
                }
                equationsManager.RunPartThreeOfEquations(values, column);
                if (values.xt >= values.KsiR * column.WorkHeightProfileWithWarming && firstTime)
                {
                    columnFactory.OverrideColumn(sourceData, column, values.xt, values.KsiR);
                    firstTime = false;
                    BuildCalculation();
                }
                else
                {
                    values.FinalEquation = values.MainEquations[2];
                    result.Status = equationsManager.RunPartFourOfEquations(values, column);
                }
            }
            catch (ExceptionFRBasic ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"{ex.Message}. Значение переменной вызвавшей ошибку равно {ex.InvalidValue}.");
            }
            catch (Exception ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"{ex.Message}.");
            }
        }

        public void BuildResult()
        {
            if(result.ExeptionList.Count > 0)
            {
                result.ResultAsString = resultCreator.BuildError(result);
                return;
            }
            result.FinalEquations = values.MainEquations;
            resultCreator.AddConstructionDataToResult(result, column);
            if (values.FinalEquation == values.MainEquations[0]) resultCreator.AddResultIfLastIsEightDotTwentyThree(result, values);
            else if (values.FinalEquation == values.MainEquations[1]) resultCreator.AddResultIfLastIsEightDotFifteen(result, values);
            else if (values.FinalEquation == values.MainEquations[2]) resultCreator.AddResultIfLastIsEightDotTwentyFive(result, values);
            result.ResultAsString = resultCreator.BuildString(result);
        }

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetCalculationResult()
        { 
            return result;
        }



    }
}
