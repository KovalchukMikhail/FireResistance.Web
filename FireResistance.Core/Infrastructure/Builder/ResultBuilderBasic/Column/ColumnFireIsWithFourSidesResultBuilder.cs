using FireResistance.Core.Data;
using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.Materials.AbstractClasses;
using FireResistance.Core.Entities.Materials.BaseClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Factories.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.Interfaces.MaterialFactory;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<Dictionary<string, string>, CalculationResult<Dictionary<string, double>, Dictionary<string, string>>, Dictionary<string, double>, Dictionary<string, string>>
    {
        private CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result;
        private ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData;
        private ColumnFR column;
        private ColumnFactoryFR columnFactory;
        private ServiceProvider provider;
        private TempValuesForColumn values;
        private IColumnFireIsWithFourSidesEquationsManager equationsManager;
        private IColumnFireIsWithFourSidesResultCreator resultCreator;

        private bool firstTime { get; set; } = true;


  
        public ColumnFireIsWithFourSidesResultBuilder(CalculationResult<Dictionary<string, double>,
                                                        Dictionary<string, string>> result,
                                                        TempValuesForColumn values,
                                                        IColumnFireIsWithFourSidesEquationsManager equationsManager,
                                                        ColumnFactoryFR columnFactory,
                                                        IColumnFireIsWithFourSidesResultCreator resultCreator)
        {
            this.result = result;
            this.values = values;
            this.equationsManager = equationsManager;
            this.columnFactory = columnFactory;
            this.resultCreator = resultCreator;
        }

        public void SetSourceData(SourceData<Dictionary<string, string>> sourceData, ServiceProvider provider)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData<Dictionary<string, string>>;
            this.provider = provider;
        }

        public void BuildConstructions()
        {
            column = columnFactory.Create(provider, sourceData) as ColumnFR;   
        }
        
        public void BuildCalculation()
        {
            equationsManager.RunPartOneOfEquations(values, column);
            if (values.e0 <= column.Height / 30 && values.Lambda <= 20)
            {
                values.FinalEquation = values.MainEquations[0];
                result.Status = equationsManager.RunEquationEightDotTwentyThree(values, column);
            }
            equationsManager.RunPartTwoOfEquations(values, column);
            if (values.Ncr <= column.Strength)
            {
                values.FinalEquation = values.MainEquations[1];
                result.Status = false;
            }
            equationsManager.RunPartThreeOfEquations(values, column);
            if (values.xt >= values.KsiR * column.WorkHeightProfileWithWarming && firstTime)
            {
                columnFactory.OverrideColumn(provider, sourceData, column, values.xt, values.KsiR);
                firstTime = false;
                BuildCalculation();
            }
            else
            {
                values.FinalEquation = values.MainEquations[2];
                result.Status = equationsManager.RunPartFourOfEquations(values, column); 
            }
        }

        public void BuildResult()
        {
            result.FinalEquations = values.MainEquations;
            resultCreator.AddConstructionDataToResult(result, column);
            if (values.FinalEquation == values.MainEquations[0]) resultCreator.AddResultIfLastIsEightDotTwentyThree(result, values);
            else if (values.FinalEquation == values.MainEquations[1]) resultCreator.AddResultIfLastIsEightDotFifteen(result, values);
            else if (values.FinalEquation == values.MainEquations[2]) resultCreator.AddResultIfLastIsEightDotTwentyFive(result, values);
        }

        public CalculationResult<Dictionary<string, double>, Dictionary<string, string>> GetCalculationResult()
        { 
            return result;
        }



    }
}
