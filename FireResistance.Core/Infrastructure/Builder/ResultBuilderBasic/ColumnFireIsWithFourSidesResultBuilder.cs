using FireResistance.Core.Entities.Calculations;
using FireResistance.Core.Infrastructure.Builder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic
{
    internal class ColumnFireIsWithFourSidesResultBuilder : IColumnFireIsWithFourSidesResultBuilder<ResultAsDictionary>
    {
        private ResultAsDictionary result;

        public ColumnFireIsWithFourSidesResultBuilder()
        {
            result = new ResultAsDictionary();
        }
        public bool BuildConstructions()
        {
            throw new NotImplementedException();
        }

        public bool BuildSourceValues()
        {
            throw new NotImplementedException();
        }

        public bool BuildCalculation()
        {
            throw new NotImplementedException();
        }

        public ResultAsDictionary GetCalculationResult()
        {
            return result;
        }
    }
}
