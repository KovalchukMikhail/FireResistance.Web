using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Core.TemperutureFormSp468;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    internal class SlabFactoryFR : IConstructionFactory<SlabWithRigidConnectionToColumnsData>
    {
        private NameColumns nameColumns;
        private RequestDb db;
        private SlabFR slab;
        private ICommonEquations commonEquation;
        private IEquationsFromSp468 equationsSp468;
        private ArmatureForFRFactory armatureFactory;
        private ConcreteForFRFactory concreteFactory;
        private ISlabTemperature<SlabFR, SlabWithRigidConnectionToColumnsData> slabTemperature;

        public SlabFactoryFR(NameColumns nameColumns,
                                RequestDb db,
                                SlabFR slab,
                                ICommonEquations commonEquation,
                                IEquationsFromSp468 equationsSp468,
                                ArmatureForFRFactory armatureFactory,
                                ConcreteForFRFactory concreteFactory,
                                ISlabTemperature<SlabFR, SlabWithRigidConnectionToColumnsData> slabTemperature)
        {
            this.nameColumns = nameColumns;
            this.db = db;
            this.slab = slab;
            this.commonEquation = commonEquation;
            this.equationsSp468 = equationsSp468;
            this.armatureFactory = armatureFactory;
            this.concreteFactory = concreteFactory;
            this.slabTemperature = slabTemperature;
        }

        public virtual Construction Create(SlabWithRigidConnectionToColumnsData sourceData)
        {
            slab.Height = sourceData.Heigh;
            slab.Width = sourceData.LengthAcross;
            slab.Length = sourceData.LengthAlong;
            slab.ArmatureInstallationDepthFromAbove = sourceData.ArmatureInstallationDepthFromAbove;
            slab.ArmatureInstallationDepthFromBelow = sourceData.ArmatureInstallationDepthFromBelow;
            slab.DistanceFromEdgeOfColumnToHinge = sourceData.DistanceFromEdgeOfColumnToHinge;
            slab.DistributedLoad = sourceData.DistributedLoad;
            slab.FireResistanceVolume = sourceData.FireResistanceValue;
            slab.WorkingHeightForAboveArmature = commonEquation.GetWorkHeight(slab.Height, slab.ArmatureInstallationDepthFromAbove);
            slab.WorkingHeightForBelowArmature = commonEquation.GetWorkHeight(slab.Height, slab.ArmatureInstallationDepthFromBelow);
            slab.DeepConcreteWarming = 50;//!!!!!!!!!!!!!!!!!!
            slab.WorkHeightProfileWithWarmingForAboveArmature = equationsSp468.GetH0tWithFire(slab.WorkingHeightForAboveArmature, slab.DeepConcreteWarming);
            double temperatureAboveArmature = 400;//!!!!!!!!!!!!!!!!!!
            double temperatureBelowArmature = 400;//!!!!!!!!!!!!!!!!!!
            double temperatureConcrete = 400;//!!!!!!!!!!!!!!!!!!
            slab.ConcreteFR = concreteFactory.Create(sourceData, temperatureConcrete) as ConcreteForFR;
            slab.ArmatureFRFromAbove = armatureFactory.Create(sourceData, temperatureAboveArmature) as ArmatureForFR;
            slab.ArmatureFRFromBelow = armatureFactory.Create (sourceData, temperatureBelowArmature) as ArmatureForFR;
            return slab;
        }
    }
}
