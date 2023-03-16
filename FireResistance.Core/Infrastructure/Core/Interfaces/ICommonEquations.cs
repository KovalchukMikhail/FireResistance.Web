using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface ICommonEquations
    {
        /// <summary>Moment of inertia of the concrete</summary>
        public double GetMomentOfInertiaOfConcrete(double bt, double ht);

        /// <summary>Moment of inertia of the armature</summary>
        public double GetMomentOfInertiaOfArmature(double As, double h, double a);
    }
}
