using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.ExceptionFR
{
    internal class ExceptionFRBasic : Exception
    {
        public double InvalidValue { get; set; }
        public ExceptionFRBasic(string message) : base(message) { }

        public ExceptionFRBasic(string message, double invalidValue) : this(message)
        {
            this.InvalidValue = invalidValue;
        }
    }
}
