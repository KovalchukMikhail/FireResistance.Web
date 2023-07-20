using EquationsFromSp.Interfaces;
using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column.interfaces;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Utilities.Interfaces;


namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class ColumnFireIsWithFourSidesEquationsManager : IColumnFireIsWithFourSidesEquationsManager
    {
        private RequestDb db;
        private IEquationsFromSp468 equationsSp468;
        private IEquationsFromSp63 equationsSp63;
        private ICommonEquations commonEquations;
        private IInterpolator interpolator;
        private NameColumns nameColumns;

        public ColumnFireIsWithFourSidesEquationsManager(RequestDb db,
                                                            IEquationsFromSp468 equationsSp468,
                                                            IEquationsFromSp63 equationsSp63,
                                                            ICommonEquations commonEquations,
                                                            IInterpolator interpolator,
                                                            NameColumns nameColumns)
        {
            this.db = db;
            this.equationsSp468 = equationsSp468;
            this.equationsSp63 = equationsSp63;
            this.commonEquations = commonEquations;
            this.interpolator = interpolator;
            this.nameColumns = nameColumns;
        }

        public virtual void RunPartOneOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            values.e0 = equationsSp63.Gete0(false, column.Moment, column.Strength, column.Length, column.Height);
            values.Lambda = column.WorkLenth / column.HeightProfileWithWarming;
        }

        public virtual void RunPartTwoOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            values.DeltaE = equationsSp63.GetDeltaE(values.e0, column.HeightProfileWithWarming);
            values.FiL = equationsSp63.GetFiL(column.Moment, column.Moment);
            values.MomentOfInertiaOfConcrete = commonEquations.GetMomentOfInertiaOfConcrete(column.WidthProfileWithWarming, column.HeightProfileWithWarming);
            values.MomentOfInertiaOfArmature = commonEquations.GetMomentOfInertiaOfArmature(column.ArmatureFR.Area, column.Height, column.DistanceToArmature);
            values.kb = equationsSp63.GetKb(values.FiL, values.DeltaE);
            values.ks = equationsSp63.GetKs();
            values.D = equationsSp63.GetD(values.kb, column.ConcreteFR.ElasticityModulusWithWarming, values.MomentOfInertiaOfConcrete, values.ks, column.ArmatureFR.ElasticityModulusWithWarming, values.MomentOfInertiaOfArmature);
            values.Ncr = equationsSp63.GetNcr(values.D, column.WorkLenth);
        }

        public virtual void RunPartThreeOfEquations(TempValuesForColumn values, ColumnFR column)
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
        public virtual bool RunPartFourOfEquations(TempValuesForColumn values, ColumnFR column)
        {
            bool check = equationsSp468.CheckEquationEightDotTwentyFive(column.Strength, values.e, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.WidthProfileWithWarming, values.xt, column.WorkHeightProfileWithWarming, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, column.ArmatureFR.Area, column.WorkHeight, column.DistanceToArmature, out double leftPartOfEquation, out double rightPartOfEquation);
            values.LeftPartOfFinalEquation = leftPartOfEquation;
            values.RightPartOfFinalEquation = rightPartOfEquation;
            values.FinalСoefficient = commonEquations.GetFinalСoefficient(leftPartOfEquation, rightPartOfEquation);
            return check;
        }

        public virtual bool RunEquationEightDotTwentyThree(TempValuesForColumn values, ColumnFR column)
        {
            values.Lambda = values.Lambda < 12 ? 12 : values.Lambda;
            values.Astot = 2 * column.ArmatureFR.Area;
            values.Fi = interpolator.GetValueFromTable(nameColumns.ConcreteType, nameColumns.FlexibilityForTableEightDotOne, column.ConcreteFR.TypeName, values.Lambda, db.DataSP468Db.GetTableFiNumberEightDotOne());
            bool check = equationsSp468.CheckEquationEightDotTwentyThree(values.Fi, column.Strength, column.ConcreteFR.ResistWithTemperatureNormativeForSqueeze, column.AreaChangedProfile, column.ArmatureFR.ResistSqueezeWithTemperatureСalculation, values.Astot, out  double rightPartEquation);
            values.RightPartOfFinalEquation = rightPartEquation;
            values.FinalСoefficient = commonEquations.GetFinalСoefficient(column.Strength, rightPartEquation);
            return check;
        }
    }
}
