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

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<Dictionary<string, string>, ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>
    {
        private ResultAsDictionary result;
        private ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData;
        private ColumnFR column;
        ColumnFactoryFR columnFactory;
        private ServiceProvider provider;
        private IEquationsFromSp468 equationsSp468;
        private IEquationsFromSp63 equationsSp63;
        private ICommonEquations commonEquations;
        private IInterpolator interpolator;
        private RequestDb db;

        private double e0; // from item 8.1.7 SP63
        private double deltaE; // from item 8.1.15 SP63
        private double fi; // from item 8.18 SP468
        private double Astot; // from item 8.18 SP468
        private double lambda; // from item 8.18 SP468
        private double fiL; // from item 8.1.15 SP63
        private double momentOfInertiaOfConcrete;
        private double momentOfInertiaOfArmature;
        private double kb; // from item 8.1.15 SP63
        private double ks; // from item 8.1.15 SP63
        private double D; // from item 8.1.15 SP63
        private double Ncr; // Equation (8.15) SP63
        private double n; // Equation (8.14) SP63
        private double e; // Equation (8.28) SP568
        private double eSel; // Equation (8.2) SP63
        private double ebTwo; // from item 6.1.20 SP63
        private double KsiR; // Equation (8.1) SP63
        private double xtFirst; // Equation(8.26) SP468
        private double xtSecond; // Equation(8.27) SP468
        private double Ksi; // from item 8.20 SP468
        private double xt; // from item 8.20 SP468
        private double leftPartOfFinalEquation;
        private double RightPartOfFinalEquation;
        bool firstTime = true;
        string[] mainEquations = { "8.23:SP468", "8.15:SP63", "8.25:SP468" };
        string finalEquation;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }

        public void SetSourceData(SourceData<Dictionary<string, string>> sourceData, ServiceProvider provider)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData<Dictionary<string, string>>;
            this.provider = provider;
            equationsSp468 = provider.GetRequiredService<IEquationsFromSp468>();
            equationsSp63 = provider.GetRequiredService<IEquationsFromSp63>();
            commonEquations = provider.GetRequiredService<ICommonEquations>();
            interpolator = provider.GetRequiredService<IInterpolator>();
            db = provider.GetRequiredService<RequestDb>();
        }

        public bool BuildConstructions()
        {
            columnFactory = provider.GetRequiredService<ColumnFactoryFR>();
            column = columnFactory.Create(provider, sourceData) as ColumnFR;
            return true;
            
        }
        
        public bool BuildCalculation()
        {
            RunPartFirstOfEquations();
            if (e0 <= column.Height / 30 && lambda <= 20)
            {
                finalEquation = mainEquations[0];
                return RunEquationEightDotTwentyThree();
            }
            RunPartSecondOfEquations();
            if (Ncr <= column.Strength)
            {
                finalEquation = mainEquations[1];
                return false;
            }
            RunPartThirdOfEquations();
            if (xt >= KsiR * column.WorkHeightProfileWithWarming && firstTime)
            {
                columnFactory.OverrideColumn(provider, sourceData, column, xt, KsiR);
                firstTime = false;
                return BuildCalculation();
            }
            finalEquation = mainEquations[2];
            return equationsSp468.CheckEquationEightDotTwentyFive(column.Strength, e, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.WidthProfileWithWarming, xt, column.WorkHeightProfileWithWarming, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, column.ArmatureFR.Area, column.WorkHeight, column.DistanceToArmature, out leftPartOfFinalEquation, out RightPartOfFinalEquation);

        }

        public bool BuildResult()
        {
            result.AddItemDescription("ответ", finalEquation + "N= " + column.Strength + " Result= " + RightPartOfFinalEquation);
            return true;
        }

        public ResultAsDictionary GetCalculationResult()
        { 
            return result;
        }

        protected virtual void RunPartFirstOfEquations()
        {
            e0 = equationsSp63.Gete0(false, column.Moment, column.Strength, column.Length, column.Height);
            lambda = column.WorkLenth / column.HeightProfileWithWarming;
        }

        protected virtual void RunPartSecondOfEquations()
        {
            deltaE = equationsSp63.GetDeltaE(e0, column.HeightProfileWithWarming);
            fiL = equationsSp63.GetFiL(column.Moment, column.Moment);
            momentOfInertiaOfConcrete = commonEquations.GetMomentOfInertiaOfConcrete(column.WidthProfileWithWarming, column.HeightProfileWithWarming);
            momentOfInertiaOfArmature = commonEquations.GetMomentOfInertiaOfArmature(column.ArmatureFR.Area, column.Height, column.DistanceToArmature);
            kb = equationsSp63.GetKb(fiL, deltaE);
            ks = equationsSp63.GetKs();
            D = equationsSp63.GetD(kb, column.ConcreteFR.ElasticityModulusWithWarming, momentOfInertiaOfConcrete, ks, column.ArmatureFR.ElasticityModulusWithWarming, momentOfInertiaOfArmature);
            Ncr = equationsSp63.GetNcr(D, column.WorkLenth);
        }

        protected virtual void RunPartThirdOfEquations()
        {
            n = equationsSp63.Getn(column.Strength, Ncr);
            e = equationsSp468.GetEEquationEightDotTwentyEight(e0, n, column.WorkHeight, column.DistanceToArmature, 0);
            eSel = equationsSp63.GetESel(column.ArmatureFR.ResistStretchWithTemperatureСalculation, column.ArmatureFR.ElasticityModulusWithWarming);
            ebTwo = equationsSp63.GetEbTwo();
            KsiR = equationsSp63.GetKsiR(eSel, ebTwo);
            xtFirst = equationsSp468.GetXtEquationEightDotTwentySix(column.Strength,
                                                                            column.ArmatureFR.ResistWithTemperatureNormative,
                                                                            column.ArmatureFR.Area,
                                                                            column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                            column.ConcreteFR.ResistNormativeForSqueeze,
                                                                            column.WidthProfileWithWarming);
            xtSecond = equationsSp468.GetXtEquationEightDotTwentySeven(column.Strength,
                                                                                column.ArmatureFR.ResistWithTemperatureNormative,
                                                                                column.ArmatureFR.Area,
                                                                                KsiR,
                                                                                column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                                column.ArmatureFR.Area,
                                                                                column.ConcreteFR.ResistNormativeForSqueeze,
                                                                                column.WidthProfileWithWarming,
                                                                                column.WorkHeightProfileWithWarming);

            Ksi = equationsSp468.GetKsi(xtFirst, column.WorkHeightProfileWithWarming);
            xt = Ksi <= KsiR ? xtFirst : xtSecond;
        }

        protected virtual bool RunEquationEightDotTwentyThree()
        {
            lambda = lambda < 12 ? 12 : lambda;
            Astot = 2 * column.ArmatureFR.Area;
            fi = interpolator.GetValueFromTable(NameColumns.ConcreteType, NameColumns.FlexibilityForTableEightDotOne, column.ConcreteFR.TypeName, lambda, db.DataSP468Db.GetTableFiNumberEightDotOne());
            return equationsSp468.CheckEquationEightDotTwentyThree(fi, column.Strength, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.AreaChangedProfile, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, Astot, out RightPartOfFinalEquation);
        }

    }
}
