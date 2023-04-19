using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.SlabOnColumns.interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.SlabOnColumns;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.SlabOnColumns
{
    internal class SlabWithRigidConnectionToColumnsResultBuilder : ISlabWithRigidConnectionToColumnsResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>
    {
        private CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result;
        private SlabWithRigidConnectionToColumnsData sourceData;
        private SlabFR slab;
        private SlabFactoryFR slabFactory;
        private TempValuesForSlabOnColumns values;
        private ISlabWithRigidConnectionToColumnsEquationsManager equationsManager;
        private ISlabWithRigidConnectionToColumnsResultCreator resultCreator;

        private bool firstTime { get; set; } = true;

        public SlabWithRigidConnectionToColumnsResultBuilder(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result,
                                                        TempValuesForSlabOnColumns values,
                                                        ISlabWithRigidConnectionToColumnsEquationsManager equationsManager,
                                                        SlabFactoryFR slabFactory,
                                                        ISlabWithRigidConnectionToColumnsResultCreator resultCreator)
        {
            this.result = result;
            this.values = values;
            this.equationsManager = equationsManager;
            this.slabFactory = slabFactory;
            this.resultCreator = resultCreator;
        }

        public void SetSourceData(SourceData sourceData)
        {
            this.sourceData = sourceData as SlabWithRigidConnectionToColumnsData;
        }

        public void BuildConstructions()
        {
            try
            {
                slab = slabFactory.Create(sourceData) as SlabFR;
            }
            catch (ExceptionFRBasic ex)
            {
                result.ExeptionList.Add($"{ex.Message}. Значение переменной вызвавшей ошибку равно {ex.InvalidValue}");
            }
            catch (Exception ex)
            {
                result.ExeptionList.Add($"{ex.Message}.");
            }

        }

        public void BuildCalculation()
        {
            if (result.ExeptionList.Count > 0) return;
            try
            {

            }
            catch (ExceptionFRBasic ex)
            {
                result.ExeptionList.Add($"{ex.Message}. Значение переменной вызвавшей ошибку равно {ex.InvalidValue}.");
            }
            catch (Exception ex)
            {
                result.ExeptionList.Add($"{ex.Message}.");
            }
        }

        public void BuildResult()
        {
            //if (result.ExeptionList.Count > 0)
            //{
            //    result.ResultAsString = resultCreator.BuildError(result);
            //    return;
            //}
            //result.FinalEquations = values.MainEquations;
            //resultCreator.AddConstructionDataToResult(result, column);
            //if (values.FinalEquation == values.MainEquations[0]) resultCreator.AddResultIfLastIsEightDotTwentyThree(result, values);
            //else if (values.FinalEquation == values.MainEquations[1]) resultCreator.AddResultIfLastIsEightDotFifteen(result, values);
            //else if (values.FinalEquation == values.MainEquations[2]) resultCreator.AddResultIfLastIsEightDotTwentyFive(result, values);
            //result.ResultAsString = resultCreator.BuildString(result);
        }

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetCalculationResult()
        {
            return result;
        }
    }
}
