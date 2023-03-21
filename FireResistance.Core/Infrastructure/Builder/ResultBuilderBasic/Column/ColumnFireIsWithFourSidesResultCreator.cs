using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class ColumnFireIsWithFourSidesResultCreator : IColumnFireIsWithFourSidesResultCreator
    {
        public virtual void AddConstructionDataToResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, ColumnFR column)
        {
            result.AddItemDescription("FireResistanceVolume", column.FireResistanceVolume);
            result.AddItemDescription("FixationElement", column.FixationElement);
            result.AddItemDescription("ClassNameOfConcrete", column.ConcreteFR.ClassName);
            result.AddItemDescription("TypeNameOfConcrete", column.ConcreteFR.TypeName);
            result.AddItemDescription("ClassNameOfArmature", column.ArmatureFR.ClassName);
            result.AddItemResult("L", column.Length);
            result.AddItemResult("h", column.Height);
            result.AddItemResult("b", column.Width);
            result.AddItemResult("СoefficientFixationElement", column.СoefficientFixationElement);
            result.AddItemResult("a", column.DistanceToArmature);
            result.AddItemResult("DiameterOfArmature", column.ArmatureFR.Diameter);
            result.AddItemResult("CountOfArmature", column.ArmatureFR.Count);
            result.AddItemResult("As", column.ArmatureFR.Area);
            result.AddItemResult("TemperaturOfArmature", column.ArmatureFR.Temperature);
            result.AddItemResult("TemperaturOfConcrete", column.ConcreteFR.Temperature);
            result.AddItemResult("Mn", column.Moment);
            result.AddItemResult("Nn", column.Strength);
            result.AddItemResult("Rbn", column.ConcreteFR.ResistNormativeForSqueeze);
            result.AddItemResult("GammaBT", column.ConcreteFR.GammaBT);
            result.AddItemResult("BetaB", column.ConcreteFR.BetaB);
            result.AddItemResult("Rbnt", column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze);
            result.AddItemResult("Rsn", column.ArmatureFR.ResistNormativeForStretch);
            result.AddItemResult("Rsnt", column.ArmatureFR.ResistWithTemperatureNormative);
            result.AddItemResult("GammaST", column.ArmatureFR.GammaST);
            result.AddItemResult("BetaS", column.ArmatureFR.BetaS);
            result.AddItemResult("Rsc", column.ArmatureFR.ResistСalculationForSqueeze);
            result.AddItemResult("Rsct", column.ArmatureFR.ResistSqueezeWithTemperatureСalculation);
            result.AddItemResult("Rs", column.ArmatureFR.ResistСalculationForStretch);
            result.AddItemResult("Rst", column.ArmatureFR.ResistStretchWithTemperatureСalculation);
            result.AddItemResult("Es", column.ArmatureFR.ElasticityModulus);
            result.AddItemResult("Eb", column.ConcreteFR.StartElasticityModulus);
            result.AddItemResult("Est", column.ArmatureFR.ElasticityModulusWithWarming);
            result.AddItemResult("Ebt", column.ConcreteFR.ElasticityModulusWithWarming);
            result.AddItemResult("at", column.DeepConcreteWarming);
            result.AddItemResult("h0", column.WorkHeight);
            result.AddItemResult("ht", column.HeightProfileWithWarming);
            result.AddItemResult("h0t", column.WorkHeightProfileWithWarming);
            result.AddItemResult("bt", column.WidthProfileWithWarming);
            result.AddItemResult("Ared", column.AreaChangedProfile);
            result.AddItemResult("l0", column.WorkLenth);
        }

        public virtual void AddResultIfLastIsEightDotTwentyThree(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            AddPartOneResult(result, values);
            result.AddItemResult("Astot", values.Astot);
            result.AddItemResult("fi", values.Fi);
            result.AddItemResult("RightPartOfFinalEquation", values.RightPartOfFinalEquation);
            result.AddItemDescription("FinalEquation", values.FinalEquation);
        }

        public virtual void AddResultIfLastIsEightDotFifteen(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            AddPartOneResult(result, values);
            AddPartTwoResult(result, values);
            result.AddItemDescription("FinalEquation", values.FinalEquation);
        }

        public virtual void AddResultIfLastIsEightDotTwentyFive(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            AddPartOneResult(result, values);
            AddPartTwoResult(result, values);
            AddPartThreeResult(result, values);
            AddPartFourResult(result, values);
            result.AddItemDescription("FinalEquation", values.FinalEquation);
        }

        protected virtual void AddPartOneResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            result.AddItemResult("e0", values.e0);
            result.AddItemResult("lambda", values.Lambda);
        }

        protected virtual void AddPartTwoResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            result.AddItemResult("deltaE", values.DeltaE);
            result.AddItemResult("fiL", values.FiL);
            result.AddItemResult("I", values.MomentOfInertiaOfConcrete);
            result.AddItemResult("Is", values.MomentOfInertiaOfArmature);
            result.AddItemResult("kb", values.kb);
            result.AddItemResult("ks", values.ks);
            result.AddItemResult("D", values.D);
            result.AddItemResult("Ncr", values.Ncr);
        }

        protected virtual void AddPartThreeResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            result.AddItemResult("n", values.n);
            result.AddItemResult("e", values.e);
            result.AddItemResult("eSel", values.eSel);
            result.AddItemResult("ebTwo", values.ebTwo);
            result.AddItemResult("KsiR", values.KsiR);
            result.AddItemResult("xtFirst", values.xtFirst);
            result.AddItemResult("xtSecond", values.xtSecond);
            result.AddItemResult("Ksi", values.Ksi);
            result.AddItemResult("xt", values.xt);
        }
        protected virtual void AddPartFourResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForColumn values)
        {
            result.AddItemResult("LeftPartOfFinalEquation", values.LeftPartOfFinalEquation);
            result.AddItemResult("RightPartOfFinalEquation", values.RightPartOfFinalEquation);
        }

        
    }
}
