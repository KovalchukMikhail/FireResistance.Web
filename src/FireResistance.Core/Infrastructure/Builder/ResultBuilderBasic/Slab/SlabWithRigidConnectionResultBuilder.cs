using CalculationException;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic;
using FireResistance.Logger;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab
{
    /// <summary>Класс описывает методы позволяющие построить объекты плиты перекрытия на основании исходных данных и результаты расчетов к ним</summary>
    internal class SlabWithRigidConnectionResultBuilder : ISlabWithRigidConnectionResultBuilder<CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>
    {
        private CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result;
        private SlabWithRigidConnectionData sourceData;
        private SlabFR slab;
        private SlabFactoryFR slabFactory;
        private TempValuesForSlab values;
        private ISlabWithRigidConnectionEquationsManager equationsManager;
        private ISlabWithRigidConnectionResultCreator resultCreator;
        private FileLogger logger;

        private bool firstTime { get; set; } = true;

        public SlabWithRigidConnectionResultBuilder(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result,
                                                        TempValuesForSlab values,
                                                        ISlabWithRigidConnectionEquationsManager equationsManager,
                                                        SlabFactoryFR slabFactory,
                                                        ISlabWithRigidConnectionResultCreator resultCreator,
                                                        FileLogger logger)
        {
            this.result = result;
            this.values = values;
            this.equationsManager = equationsManager;
            this.slabFactory = slabFactory;
            this.resultCreator = resultCreator;
            this.logger = logger;
        }
        /// <summary>Устанавливает исходные данные для экземпляра класса SlabWithRigidConnectionData</summary>
        public void SetSourceData(SourceData sourceData)
        {
            this.sourceData = sourceData as SlabWithRigidConnectionData;
        }
        /// <summary>Строит экземпляр объекта SlabFR на основании исходных данных</summary>
        public void BuildConstructions()
        {
            try
            {
                slab = slabFactory.Create(sourceData) as SlabFR;
            }
            catch (ValueException ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"{ex.Message}. Значение переменной вызвавшей ошибку равно {ex.InvalidValue}");
            }
            catch (Exception ex)
            {
                logger.AddLogException($"DateTime:{DateTime.Now}; ex.Message:{ex.Message}; sourceData:{sourceData}");
                result.ExeptionList.Add($"{ex.Message}.");
            }

        }
        /// <summary>Метод выполняет процесс построения расчета</summary>
        public void BuildCalculation()
        {
            if (result.ExeptionList.Count > 0) return;
            try
            {
                result.Status = equationsManager.RunEquations(values, slab);
            }
            catch (ValueException ex)
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
        /// <summary>Метод выполняет процесс построения результатов расчета</summary>
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
        /// <summary>Метод возвращает объект содержащий результаты расчетов</summary>
        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetCalculationResult()
        {
            return result;
        }
    }
}
