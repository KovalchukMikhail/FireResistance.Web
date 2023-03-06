using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<ResultAsDictionary, Dictionary<string, double>, Dictionary<string, string>>
    {
        private ResultAsDictionary result;
        private ColumnFireIsWithFourSidesData<Dictionary<string, string>> sourceData;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }
        public bool BuildConstructions(ServiceProvider provider)
        {
            Column column = provider.GetRequiredService<Column>();
            result.AddItemDescription("ответ",column.ToString());

            return true;
            
        }

        public bool BuildSourceValues()
        {
            return true;
        }

        public bool BuildCalculation()
        {
            return true;
        }

        public ResultAsDictionary GetCalculationResult()
        {
            return result;
        }
    }
}
