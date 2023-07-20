using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSp.Interfaces
{
    public interface IEquationsFromSp63
    {
        /// <summary>Equation from item 8.1.7</summary>
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height);

        /// <summary>Equation from item 8.1.15 for get deltaE</summary>
        public double GetDeltaE(double e0, double h);

        /// <summary>Equation from item 8.1.15 for get fiL</summary>
        public double GetFiL(double Mone, double MlOne);

        /// <summary>Equation from item 8.1.15 for get kb</summary>
        public double GetKb(double Fil, double DeltaE);

        /// <summary>Equation from item 8.1.15 for get ks</summary>
        public double GetKs();

        /// <summary>Equation from item 8.1.15 for get D</summary>
        public double GetD(double kb, double Eb, double I, double ks, double Es, double Is);
        /// <summary>Equation from item 8.1.15 for get Ncr</summary>
        public double GetNcr(double D, double l0);
        /// <summary>Equation from item 8.1.15 for get n</summary>
        public double Getn(double N, double Ncr);

        /// <summary>Equation (8.1)</summary>
        public double GetKsiR(double eSel, double ebTwo);
        /// <summary>Value of ebTwo from item 6.1.20</summary>
        public double GetEbTwo() => 0.0035;
        /// <summary>Equation (8.2)</summary>
        public double GetESel(double Rs, double Es);
    }
}
