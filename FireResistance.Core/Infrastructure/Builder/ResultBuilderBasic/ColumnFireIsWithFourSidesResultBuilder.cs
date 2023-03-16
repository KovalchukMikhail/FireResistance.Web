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
        private ServiceProvider provider;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }

        public void SetSourceData(SourceData<Dictionary<string, string>> sourceData, ServiceProvider provider)
        {
            this.sourceData = sourceData as ColumnFireIsWithFourSidesData<Dictionary<string, string>>;
            this.provider = provider;
        }

        public bool BuildConstructions()
        {
            ColumnFactoryFR columnFactory = provider.GetRequiredService<ColumnFactoryFR>();
            column = columnFactory.Create(provider, sourceData) as ColumnFR;
            return true;
            
        }

        public bool BuildCalculation()
        {
            IEquationsFromSp468 equationsSp468 = provider.GetRequiredService<IEquationsFromSp468>();
            IEquationsFromSp63 equationsSp63 = provider.GetRequiredService<IEquationsFromSp63>();
            ICommonEquations commonEquations = provider.GetRequiredService<ICommonEquations>();
            double e0 = equationsSp63.Gete0(false, column.Moment, column.Strength, column.Length, column.Height);
            double deltaE = equationsSp63.GetDeltaE(e0, column.HeightProfileWithWarming);
            double fiL = equationsSp63.GetFiL(column.Moment, column.Moment);
            double momentOfInertiaOfConcrete = commonEquations.GetMomentOfInertiaOfConcrete(column.WidthProfileWithWarming, column.HeightProfileWithWarming);
            double momentOfInertiaOfArmature = commonEquations.GetMomentOfInertiaOfArmature(column.ArmatureFR.Area, column.Height, column.DistanceToArmature);
            double kb = equationsSp63.GetKb(fiL, deltaE);
            double ks = equationsSp63.GetKs();
            double D = equationsSp63.GetD(kb, column.ConcreteFR.ElasticityModulusWithWarming, momentOfInertiaOfConcrete, ks, column.ArmatureFR.ElasticityModulusWithWarming, momentOfInertiaOfArmature);
            double Ncr = equationsSp63.GetNcr(D, column.WorkLenth);
            if(Ncr <= column.Strength)
            {
                return false;
            }
            double n = equationsSp63.Getn(column.Strength, Ncr);
            double e = equationsSp468.GetEEquationEightDotTwentyEight(e0, n, column.WorkHeight, column.DistanceToArmature, 0);
            double eSel = equationsSp63.GetESel(column.ArmatureFR.ResistStretchWithTemperatureСalculation, column.ArmatureFR.ElasticityModulusWithWarming);
            double ebTwo = equationsSp63.GetEbTwo();
            double KsiR = equationsSp63.GetKsiR(eSel, ebTwo);
            double xtFirst = equationsSp468.GetXtEquationEightDotTwentySix(column.Strength,
                                                                            column.ArmatureFR.ResistWithTemperatureNormative,
                                                                            column.ArmatureFR.Area,
                                                                            column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                            column.ConcreteFR.ResistNormativeForSqueeze,
                                                                            column.WidthProfileWithWarming);
            double xtSecond = equationsSp468.GetXtEquationEightDotTwentySeven(column.Strength,
                                                                                column.ArmatureFR.ResistWithTemperatureNormative,
                                                                                column.ArmatureFR.Area,
                                                                                KsiR,
                                                                                column.ArmatureFR.ResistSqueezeWithTemperatureСalculation,
                                                                                column.ArmatureFR.Area,
                                                                                column.ConcreteFR.ResistNormativeForSqueeze,
                                                                                column.WidthProfileWithWarming,
                                                                                column.WorkHeightProfileWithWarming);

            double Ksi = equationsSp468.GetKsi(xtFirst, column.WorkHeightProfileWithWarming);
            double xt = Ksi <= KsiR ? xtFirst : xtSecond;

        }

        protected void BuildResult()
        {
           
        }

        public ResultAsDictionary GetCalculationResult()
        {
            return result;
        }

    }
}
