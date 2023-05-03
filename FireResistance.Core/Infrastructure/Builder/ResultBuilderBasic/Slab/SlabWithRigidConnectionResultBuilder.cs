using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireResistance.Core.Entities.Constructions.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab
{
    internal class SlabWithRigidConnectionResultBuilder : ISlabWithRigidConnectionResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>
    {
        private CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result;
        private SlabWithRigidConnectionData sourceData;
        private SlabFR slab;
        private SlabFactoryFR slabFactory;
        private TempValuesForSlab values;
        private ISlabWithRigidConnectionEquationsManager equationsManager;
        private ISlabWithRigidConnectionResultCreator resultCreator;

        private bool firstTime { get; set; } = true;

        public SlabWithRigidConnectionResultBuilder(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result,
                                                        TempValuesForSlab values,
                                                        ISlabWithRigidConnectionEquationsManager equationsManager,
                                                        SlabFactoryFR slabFactory,
                                                        ISlabWithRigidConnectionResultCreator resultCreator)
        {
            this.result = result;
            this.values = values;
            this.equationsManager = equationsManager;
            this.slabFactory = slabFactory;
            this.resultCreator = resultCreator;
        }

        public void SetSourceData(SourceData sourceData)
        {
            this.sourceData = sourceData as SlabWithRigidConnectionData;
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
                result.Status = equationsManager.RunEquations(values, slab);
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
            if (result.ExeptionList.Count > 0)
            {
                result.ResultAsString = resultCreator.BuildError(result);
                return;
            }
            resultCreator.AddConstructionDataToResult(result, slab);
            resultCreator.AddResult(result, values);
            result.ResultAsString = resultCreator.BuildString(result, slab.IsOnColumns);
        }

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetCalculationResult()
        {
            return result;
        }
    }
}
