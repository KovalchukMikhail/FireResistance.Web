using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces
{
    internal interface ISlabWithRigidConnectionResultCreator
    {
        public void AddConstructionDataToResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, SlabFR slab);
        public void AddResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForSlab values);
        public string BuildString(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, bool isOnColumns);
        public string BuildError(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result);
    }
}
