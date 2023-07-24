using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationException
{
    public class ValueException : Exception
    {
        public double InvalidValue { get; set; }
        public ValueException(string message, double invalidValue) : base(message)
        {
            InvalidValue = invalidValue;
        }
    }
}
