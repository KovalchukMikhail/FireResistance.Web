using FireResistance.Core.Data;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Entities.SourceDataForCalculation.SourceDataBasic;
using FireResistance.Core.Infrastructure.Factories.Interfaces.ConstructionFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

        public SlabFactoryFR(NameColumns nameColumns, RequestDb db, SlabFR slab)
        {
            this.nameColumns = nameColumns;
            this.db = db;
            this.slab = slab;
        }

        public virtual Construction Create(SlabWithRigidConnectionToColumnsData sourceData)
        {

            return slab;
        }
    }
}
