using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface ICommonEquations
    {
        public double GetMomentOfInertiaOfConcrete(double bt, double ht);

        public double GetMomentOfInertiaOfArmature(double As, double h, double a);

        public double GetWorkHeight(double h, double a);

        public double GetWorkLenth(double l, double coefficientFixationElement);

        public double GetFinalСoefficient(double checkedValue, double criticalValue);
    }
}
