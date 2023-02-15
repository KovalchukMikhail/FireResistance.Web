using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;

namespace FireResistance.Core
{
    public class FireResistance : IFireResistance<ResultAsDictionary>
    {
        public SourceData SourceData { get; }
        public FireResistance(SourceData sourceData)
        {
            SourceData = sourceData;
            // Сделать иньекцию зависимостей
        }
        public void PerformCalculation()
        {
            throw new NotImplementedException();
        }
        public ResultAsDictionary GetResult()
        {
            throw new NotImplementedException();
        }
    }
}