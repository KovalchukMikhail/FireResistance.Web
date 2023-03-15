using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IEquationsFromSp63
    {
        /// <summary>Equation from item 8.1.7</summary>
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height);
    }
}
