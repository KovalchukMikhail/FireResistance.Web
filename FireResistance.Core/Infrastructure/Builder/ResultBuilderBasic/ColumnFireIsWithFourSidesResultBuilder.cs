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
        public void BuildConstructions()
        {
            throw new NotImplementedException();
        }

        public void BuildSourceValues()
        {
            throw new NotImplementedException();
        }

        public void BuildCalculation()
        {
            throw new NotImplementedException();
        }

        public ResultAsDictionary GetCalculationResult()
        {
            throw new NotImplementedException();
        }
    }
}
