using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Column
{
    internal class TempValuesForColumn
    {
        public virtual double e0 { get; set; } // from item 8.1.7 SP63
        public virtual double DeltaE { get; set; } // from item 8.1.15 SP63
        public virtual double Fi { get; set; } // from item 8.18 SP468
        public virtual double Astot { get; set; } // from item 8.18 SP468
        public virtual double Lambda { get; set; } // from item 8.18 SP468
        public virtual double FiL { get; set; } // from item 8.1.15 SP63
        public virtual double MomentOfInertiaOfConcrete { get; set; }
        public virtual double MomentOfInertiaOfArmature { get; set; }
        public virtual double kb { get; set; } // from item 8.1.15 SP63
        public virtual double ks { get; set; } // from item 8.1.15 SP63
        public virtual double D { get; set; } // from item 8.1.15 SP63
        public virtual double Ncr { get; set; } // Equation (8.15) SP63
        public virtual double n { get; set; } // Equation (8.14) SP63
        public virtual double e { get; set; } // Equation (8.28) SP568
        public virtual double eSel { get; set; } // Equation (8.2) SP63
        public virtual double ebTwo { get; set; } // from item 6.1.20 SP63
        public virtual double KsiR { get; set; } // Equation (8.1) SP63
        public virtual double xtFirst { get; set; } // Equation(8.26) SP468
        public virtual double xtSecond { get; set; } // Equation(8.27) SP468
        public virtual double Ksi { get; set; } // from item 8.20 SP468
        public virtual double xt { get; set; } // from item 8.20 SP468
        public virtual double LeftPartOfFinalEquation { get; set; }
        public virtual double RightPartOfFinalEquation { get; set; }
        public virtual string FinalEquation { get; set; }
        public virtual double FinalСoefficient { get; set; }

        public string[] MainEquations { get; } = { "8.23:SP468", "8.15:SP63", "8.25:SP468" };
    }
}
