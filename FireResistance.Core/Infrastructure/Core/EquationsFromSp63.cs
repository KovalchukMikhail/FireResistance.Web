using FireResistance.Core.Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core
{
    internal class EquationsFromSp63 : IEquationsFromSp63
    {
        /// <summary>Equation from item 8.1.7</summary>
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height)
        {
            if (strength == 0) return -1;
            double ea = Math.Max(Math.Max(length / 600, height / 30), 10);
            if (staticallyDefinable) return moment / strength + ea;
            return Math.Max(moment/ strength, ea);
        }

        /// <summary>Equation from item 8.1.15</summary>
        public double GetDeltaE(double e0, double h)
        {
            if (h == 0) return -1;
            double deltaE = e0 / h;
            if (deltaE <= 0.15) return 0.15;
            else if (deltaE >= 1.5) return 1.5;
            else return deltaE;
        }

        /// <summary>Equation from item 8.1.15 for get fiL</summary>
        public double GetFiL(double Mone, double MlOne)
        {
            if (Mone == 0) return -1;
            double result = (1 + MlOne / Mone);
            if (result > 2) return 2;
            else return result;
        }

        /// <summary>Equation from item 8.1.15 for get kb</summary>
        public double GetKb(double Fil, double DeltaE)
            => 0.15 / (Fil * (0.3 + DeltaE));

        /// <summary>Equation from item 8.1.15 for get ks</summary>
        public double GetKs() => 0.7;

        /// <summary>Equation from item 8.1.15 for get D</summary>
        public double GetD(double kb, double Eb, double I, double ks, double Es, double Is)
            => kb * Eb * I + ks * Es * Is;
        /// <summary>Equation from item 8.1.15 for get Ncr</summary>
        public double GetNcr(double D, double l0) => Math.Pow(Math.PI, 2) * D / Math.Pow(l0, 2);
        /// <summary>Equation from item 8.1.15 for get n</summary>
        public double Getn(double N, double Ncr) => 1 / (1 - N / Ncr);
        /// <summary>Equation (8.1)</summary>
        public double GetKsiR(double eSel, double eb) => 0.8 / (1 + eSel / eb);
        /// <summary>Equation (8.2)</summary>
        public double GetESel(double Rs, double Es) => Rs / Es;

    }
}
