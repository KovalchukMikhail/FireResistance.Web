using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using FireResistance.Core.Infrastructure.Core;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class ColumnFireIsWithFourSidesEquationsManager : IColumnFireIsWithFourSidesEquationsManager
    {
        private RequestDb db;
        private IEquationsFromSp468 equationsSp468;
        private IEquationsFromSp63 equationsSp63;
        private ICommonEquations commonEquations;
        private IInterpolator interpolator;

        public ColumnFireIsWithFourSidesEquationsManager(RequestDb db, IEquationsFromSp468 equationsSp468, IEquationsFromSp63 equationsSp63, ICommonEquations commonEquations, IInterpolator interpolator)
        {
            this.db = db;
            this.equationsSp468 = equationsSp468;
            this.equationsSp63 = equationsSp63;
            this.commonEquations = commonEquations;
            this.interpolator = interpolator;
        }

        public virtual void RunPartFirstOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            values.e0 = equationsSp63.Gete0(false, column.Moment, column.Strength, column.Length, column.Height);
            values.lambda = column.WorkLenth / column.HeightProfileWithWarming;
        }

        public virtual void RunPartSecondOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            values.deltaE = equationsSp63.GetDeltaE(values.e0, column.HeightProfileWithWarming);
            values.fiL = equationsSp63.GetFiL(column.Moment, column.Moment);
            values.momentOfInertiaOfConcrete = commonEquations.GetMomentOfInertiaOfConcrete(column.WidthProfileWithWarming, column.HeightProfileWithWarming);
            values.momentOfInertiaOfArmature = commonEquations.GetMomentOfInertiaOfArmature(column.ArmatureFR.Area, column.Height, column.DistanceToArmature);
            values.kb = equationsSp63.GetKb(values.fiL, values.deltaE);
            values.ks = equationsSp63.GetKs();
            values.D = equationsSp63.GetD(values.kb, column.ConcreteFR.ElasticityModulusWithWarming, values.momentOfInertiaOfConcrete, values.ks, column.ArmatureFR.ElasticityModulusWithWarming, values.momentOfInertiaOfArmature);
            values.Ncr = equationsSp63.GetNcr(values.D, column.WorkLenth);
        }

        public virtual void RunPartThirdOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            values.n = equationsSp63.Getn(column.Strength, values.Ncr);
            values.e = equationsSp468.GetEEquationEightDotTwentyEight(values.e0, values.n, column.WorkHeight, column.DistanceToArmature, 0);
            values.eSel = equationsSp63.GetESel(column.ArmatureFR.ResistStretchWithTemperatureСalculation, column.ArmatureFR.ElasticityModulusWithWarming);
            values.ebTwo = equationsSp63.GetEbTwo();
            values.KsiR = equationsSp63.GetKsiR(values.eSel, values.ebTwo);
            values.xtFirst = equationsSp468.GetXtEquationEightDotTwentySix(column.Strength,
            column.ArmatureFR.ResistWithTemperatureNormative,
                                                                            column.ArmatureFR.Area,
                                                                            column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                            column.ConcreteFR.ResistNormativeForSqueeze,
                                                                            column.WidthProfileWithWarming);
            values.xtSecond = equationsSp468.GetXtEquationEightDotTwentySeven(column.Strength,
                                                                                column.ArmatureFR.ResistWithTemperatureNormative,
                                                                                column.ArmatureFR.Area,
                                                                                values.KsiR,
                                                                                column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                                column.ArmatureFR.Area,
                                                                                column.ConcreteFR.ResistNormativeForSqueeze,
                                                                                column.WidthProfileWithWarming,
                                                                                column.WorkHeightProfileWithWarming);

            values.Ksi = equationsSp468.GetKsi(values.xtFirst, column.WorkHeightProfileWithWarming);
            values.xt = values.Ksi <= values.KsiR ? values.xtFirst : values.xtSecond;
        }
        public virtual bool RunPartFourthOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            bool check = equationsSp468.CheckEquationEightDotTwentyFive(column.Strength, values.e, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.WidthProfileWithWarming, values.xt, column.WorkHeightProfileWithWarming, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, column.ArmatureFR.Area, column.WorkHeight, column.DistanceToArmature, out double leftPartOfEquation, out double rightPartOfEquation);
            values.LeftPartOfFinalEquation = leftPartOfEquation;
            values.RightPartOfFinalEquation = rightPartOfEquation;
            return check;
        }

        public virtual bool RunEquationEightDotTwentyThree(TempValuesForColumn values, ColumnFR column)
        {
            values.lambda = values.lambda < 12 ? 12 : values.lambda;
            values.Astot = 2 * column.ArmatureFR.Area;
            values.fi = interpolator.GetValueFromTable(NameColumns.ConcreteType, NameColumns.FlexibilityForTableEightDotOne, column.ConcreteFR.TypeName, values.lambda, db.DataSP468Db.GetTableFiNumberEightDotOne());
            bool check = equationsSp468.CheckEquationEightDotTwentyThree(values.fi, column.Strength, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.AreaChangedProfile, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, values.Astot, out  double rightPartEquation);
            values.RightPartOfFinalEquation = rightPartEquation;
            return check;
        }
    }
}
