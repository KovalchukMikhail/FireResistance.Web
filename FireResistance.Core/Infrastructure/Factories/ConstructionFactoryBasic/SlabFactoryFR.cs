using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.Materials;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using FireResistance.Core.Infrastructure.Factories.MaterialFactoryBasic;

namespace FireResistance.Core.Infrastructure.Factories.ConstructionFactoryBasic
{
    internal class SlabFactoryFR : IConstructionFactory<SlabWithRigidConnectionData>
    {
        private NameColumns nameColumns;
        private RequestDb db;
        private SlabFR slab;
        private ICommonEquations commonEquation;
        private IEquationsFromSp468 equationsSp468;
        private ArmatureForFRFactory armatureFactory;
        private ConcreteForFRFactory concreteFactory;
        private ISlabTemperature<SlabFR, SlabWithRigidConnectionData> slabTemperature;

        public SlabFactoryFR(NameColumns nameColumns,
                            RequestDb db,
                            SlabFR slab,
                            ICommonEquations commonEquation,
                            IEquationsFromSp468 equationsSp468,
                            ArmatureForFRFactory armatureFactory,
                            ConcreteForFRFactory concreteFactory,
                            ISlabTemperature<SlabFR, SlabWithRigidConnectionData> slabTemperature)
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

        public virtual Construction Create(SlabWithRigidConnectionData sourceData)
        {
            slab.FireResistanceVolume = sourceData.FireResistanceValue;
            slab.IsOnColumns = sourceData.IsOnCollums == 1? true : false;
            slab.Height = sourceData.Heigh;
            slab.Length = sourceData.LengthAcross;
            slab.Width = sourceData.LengthAlong;
            slab.ArmatureInstallationDepthFromAbove = sourceData.ArmatureInstallationDepthFromAbove;
            slab.ArmatureInstallationDepthFromBelow = sourceData.ArmatureInstallationDepthFromBelow;
            if (slab.ArmatureInstallationDepthFromAbove > slab.Height / 2) throw new ExceptionFRBasic("Недопустимое расположение верхней арматуры. Арматура расположена в нижней зоне плиты", slab.ArmatureInstallationDepthFromAbove);
            if (slab.ArmatureInstallationDepthFromBelow > slab.Height / 2) throw new ExceptionFRBasic("Недопустимое расположение нижней арматуры. Арматура расположена в верхней зоне плиты", slab.ArmatureInstallationDepthFromAbove);
            slab.DistanceFromEdgeOfColumnToHinge = sourceData.DistanceFromEdgeOfColumnToHinge;
            slab.DistributedLoad = sourceData.DistributedLoad;
            slab.WorkingHeightForAboveArmature = commonEquation.GetWorkHeight(slab.Height, slab.ArmatureInstallationDepthFromAbove);
            slab.WorkingHeightForBelowArmature = commonEquation.GetWorkHeight(slab.Height, slab.ArmatureInstallationDepthFromBelow);
            double criticalTemperature = db.DataSP468Db.GetCriticalTemperatureConcrete(sourceData.ConcreteType);
            slab.DeepConcreteWarming = slabTemperature.GetDeepConcreteWarming(slab, sourceData, criticalTemperature);
            slab.WorkHeightProfileWithWarmingForAboveArmature = equationsSp468.GetH0tWithFire(slab.WorkingHeightForAboveArmature, slab.DeepConcreteWarming);
            double temperatureAboveArmature = slabTemperature.GetTemperature(slab, slab.WorkingHeightForAboveArmature, sourceData);
            double temperatureBelowArmature = slabTemperature.GetTemperature(slab, slab.ArmatureInstallationDepthFromBelow, sourceData);
            double distanceToPointForConcreteFromBelow = 0.1 * slab.WorkHeightProfileWithWarmingForAboveArmature + slab.DeepConcreteWarming;
            double distanceToPointForConcreteToTop = slab.Height - 0.1 * slab.WorkingHeightForBelowArmature;
            double temperatureConcreteFromBelow = slabTemperature.GetTemperature(slab, distanceToPointForConcreteFromBelow, sourceData);
            double temperatureConcreteToTop = slabTemperature.GetTemperature(slab, distanceToPointForConcreteToTop, sourceData);
            slab.ConcreteFromBelowFR = concreteFactory.Create(sourceData, temperatureConcreteFromBelow) as ConcreteForFR;
            slab.ConcreteOnTopFR = concreteFactory.Create(sourceData, temperatureConcreteToTop) as ConcreteForFR;
            slab.ArmatureFRFromAbove = armatureFactory.Create(sourceData, temperatureAboveArmature) as ArmatureForFR;
            slab.ArmatureFRFromBelow = armatureFactory.Create (sourceData, temperatureBelowArmature) as ArmatureForFR;
            return slab;
        }
    }
}
