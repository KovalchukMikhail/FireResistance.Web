using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Infrastructure.Builder.Interfaces
{
    internal interface IResultBuilder <N, T, K> where N : CalculationResult<T, K>
    {
        public void SetSourceData(SourceData sourceData);
        public void BuildConstructions();
        public void BuildCalculation();
        public void BuildResult(); 
        public N GetCalculationResult();
    }
}
