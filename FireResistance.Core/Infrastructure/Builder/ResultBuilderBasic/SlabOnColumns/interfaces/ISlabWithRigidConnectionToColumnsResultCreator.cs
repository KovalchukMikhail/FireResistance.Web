using FireResistance.Core.Entities.Calculations.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.SlabOnColumns.interfaces
{
    internal interface ISlabWithRigidConnectionToColumnsResultCreator
    {
        public string BuildError(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result);
    }
}
