using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces;
using FireResistance.Core.Infrastructure.Core;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab
{
    internal class SlabWithRigidConnectionEquationsManager : ISlabWithRigidConnectionEquationsManager
    {
        private IEquationsFromSp468 equationsSp468;
        private ICommonEquations commonEquations;
        public SlabWithRigidConnectionEquationsManager(IEquationsFromSp468 equationsSp468, ICommonEquations commonEquations)
        {
            this.equationsSp468 = equationsSp468;
            this.commonEquations = commonEquations;
        }
        public virtual bool RunEquations(TempValuesForSlab values, SlabFR slab)
        {
            values.XLiT = equationsSp468.GetXitEquationEightDotFourtyFour(slab.ArmatureFRFromAbove.ResistWithTemperatureNormative, slab.ArmatureFRFromAbove.Area, slab.ConcreteFromBelowFR.ResistWithTemperatureNormativeForSqueeze, slab.Width);
            values.XRiT = equationsSp468.GetXitEquationEightDotFourtyFour(slab.ArmatureFRFromAbove.ResistWithTemperatureNormative, slab.ArmatureFRFromAbove.Area, slab.ConcreteFromBelowFR.ResistWithTemperatureNormativeForSqueeze, slab.Width);
            values.X1T = equationsSp468.GetXitEquationEightDotFourtyFive(slab.ArmatureFRFromBelow.ResistWithTemperatureNormative, slab.ArmatureFRFromBelow.Area, slab.ConcreteOnTopFR.ResistWithTemperatureNormativeForSqueeze, slab.Width);
            values.ZLI = equationsSp468.GetZ(slab.WorkHeightProfileWithWarmingForAboveArmature, values.XLiT);
            values.ZRI = equationsSp468.GetZ(slab.WorkHeightProfileWithWarmingForAboveArmature, values.XRiT);
            values.Z1 = equationsSp468.GetZ(slab.WorkingHeightForBelowArmature, values.X1T);
            bool check = equationsSp468.CheckEquationEightDotFourtyTwo(slab.DistributedLoad, slab.Length, slab.Width, slab.DistanceFromEdgeOfColumnToHinge, slab.ArmatureFRFromAbove.ResistNormativeForStretch, slab.ArmatureFRFromAbove.Area, slab.ArmatureFRFromAbove.Area, slab.ArmatureFRFromBelow.Area, values.ZLI, values.ZRI, values.Z1, slab.ArmatureFRFromBelow.ResistWithTemperatureNormative, out double partLeft, out double partRight);
            values.LeftPartOfFinalEquation = partLeft;
            values.RightPartOfFinalEquation = partRight;
            values.FinalСoefficient = commonEquations.GetFinalСoefficient(values.LeftPartOfFinalEquation, values.RightPartOfFinalEquation);
            return check;
        }
    }
}
