﻿using FireResistance.Core.Data;
using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core
{
    internal class CommonEquations : ICommonEquations
    {
        public double GetMomentOfInertiaOfConcrete(double bt, double ht) 
            => bt * Math.Pow(ht, 3) / 12;

        public double GetMomentOfInertiaOfArmature(double As, double h, double a)
            => As * Math.Pow(h - 2 * a, 2) / 2;

        public double GetWorkHeight(double h, double a) => h - a;

        public double GetWorkLenth(double l, double coefficientFixationElement) => l * coefficientFixationElement;

        public double GetFinalСoefficient(double checkedValue, double criticalValue)
        {
            if (criticalValue == 0) throw new ExceptionFRBasic("Невозможно определить коэффициент использования так как критическое значение равно 0", criticalValue);
            return checkedValue / criticalValue;
        }
    }
}