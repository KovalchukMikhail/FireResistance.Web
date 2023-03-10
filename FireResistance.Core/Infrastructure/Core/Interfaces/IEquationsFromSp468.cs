using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IEquationsFromSp468
    {
        /// <summary>Equation (5.1)</summary>
        public double GetRbWithGammaBt(double Rb, double gammaBt);

        /// <summary>Equation (5.2)</summary>
        public double GetRbtWithGammaBtt(double Rbt, double gammaBtt);

        /// <summary>Equation (5.3)</summary>
        public double GetEbt(double Eb, double betaB);

        /// <summary>Equation (5.4)</summary>
        public double GetEbTau(double Eb, double FiBCr);

        /// <summary>Equation (5.5, 5.6)</summary>
        public double GetRsWithGammaSt(double Rs, double gammaSt);

        /// <summary>Equation (5.7)</summary>
        public double Est(double Es, double betaS);

        /// <summary>Equation (5.8)</summary>
        public double GetEs0(double Rst, double Est);

        /// <summary>Equation (8.2)</summary>
        public double GetBtFireThreeSides(int b, int at);

        /// <summary>Equation (8.3)</summary>
        public double GetBftFireThreeSides(int bf, int at);

        /// <summary>Equation (8.4)</summary>
        public double GetHftFireThreeSides(int hf, int at);

        /// <summary>Equation (8.5)</summary>
        public double GetHtFireThreeSides(int h, int at);

        /// <summary>Equation (8.6)</summary>
        public double GetAredColumnFireThreeSides(int h, int b, int at);

        /// <summary>Equation (8.7)</summary>
        public double GetHtFireFourSides(int h, int at);

        /// <summary>Equation (8.8)</summary>
        public double GetAredColumnFourSides(int h, int width, int at);

        /// <summary>Equation (8.9)</summary>
        public double GetH0tFireFourSides(int h0, int at);

        /// <summary>Equation (8.10)</summary>
        public double GetMultTEquationEightDotTen(double Rbnt, int b, double xt, int h0, double Rsct, double AsSqueeze, double a);

        /// <summary>Equation (8.11)</summary>
        public double GetXtEquationEightDotEleven(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbnt, int b);

        /// <summary>Equation (8.12)</summary>
        public double GetMultTEquationEightDotTwelve(double Rsnt, double AsStretch, int h0, double xt, double Rsct, double AsSqueeze, int a);

        /// <summary>Equation (8.13)</summary>
        public double GetGammaStCrFirstOption(double Mn, double Rsn, double AsStretch, int h0, double xt);

        /// <summary>Equation (8.14)</summary>
        public double GetGammaStCrSecondOption(double Mn, double Rsct, double AsSqueeze, double xt, int a, double Rsn, double AsStretch, int h0);

        /// <summary>Equation (8.15)</summary>
        public bool GetNs(double n1, double Rbtnt, double ls, double us, double alpha, double Rsnt, double AsStretch, out double partLeft, out double partRight);

        /// <summary>Equation (8.16)</summary>
        public bool CheckEquationEightDotSixteen(double Rsnt, double AsStretch, double Rbnt, double bft, double hft, double Rsct, double AsSqueeze, out double partLeft, out double partRight);

        /// <summary>Equation (8.17)</summary>
        public double GetMultTEquationEightDotSeventeen(double Rbnt, int bt, int xt, int h0, double Rbn, double bft, double hft, double Rsct, double AsStretch, int a);

        /// <summary>Equation (8.18)</summary>
        public double GetXtEquationEightDotEighteen(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbn, double bft, double bt, double hft, double Rbnt);

        /// <summary>Equation (8.19)</summary>
        /// <remarks> Length of Rsnt must be equal to length AsStretch, h0, xtForLeft and Length of Rsct must be equal to xtForRight, AsSqueeze, a. Otherwise it will return -1</remarks>
        public double GetMultTEquationEightDotNineteen(double[] Rsnt, double[] AsStretch, double[] h0, double[] xtForLeft, double[] xtForRight, double[] Rsct, double[] AsSqueeze, double[] a);

        /// <summary>Equation (8.20)</summary>
        public double GetGammaSCr(double Mn, double A, double B, double Rsn, double AsStretch, double h0, double xt);

        /// <summary>Equation (8.21)</summary>
        public double GetA(double Rbnt, double bt, double xt, double h0, double hft);

        /// <summary>Equation (8.22)</summary>
        public double GetB(double Rsct, double AsStretch, double h0, double a);

        /// <summary>Equation (8.23)</summary>
        public bool CheckEquationEightDotTwentyThree(double fi, double NultT, double Rbnt, double Ared, double Rsct, double Astot, out double partRight);

        /// <summary>Equation (8.24)</summary>
        public double GetAred(double d, double at);

        /// <summary>Equation (8.25)</summary>
        public bool CheckEquationEightDotTwentyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Equation (8.26)</summary>
        public double GetXtEquationEightDotTwentySix(double Nn, double Rsnl, double AsStretch, double Rsct, double Rbnt, double bt);

        /// <summary>Equation (8.27)</summary>
        public double GetXtEquationEightDotTwentySeven(double Nn, double Rsnt, double AsStretch, double Er, double Rsct, double AsSqueeze, double Rbnt, double bt, double h0t);

        /// <summary>Equation (8.28)</summary>
        public double GetEEquationEightDotTwentyEight(double e0, double n, double h0, double a, double et);

        /// <summary>Equation (8.29)</summary>
        public double GetEt(double a, double alphaSt, double ts, double alphaBt, double tb, double lo, double h0t);

        /// <summary>Equation (8.30)</summary>
        public double GetEEquationEightDotThirty(double e0, double Eb1, double Jred, double Nn, double l0);

        /// <summary>Equation (8.31)</summary>
        public bool CheckEquationEightDotThirtyOne(double Nn, double NultT);

        /// <summary>Equation (8.32)</summary>
        public double GetNultT(double Rsnt, double Astot);

        /// <summary>Equation (8.33)</summary>
        public bool CheckEquationEightDotThirtyThree(double Nn, double e, double Rsnt, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Equation (8.34)</summary>
        public bool CheckEquationEightDotThirtyFour(double Nn, double e, double Rsnt, double AsStretch, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Equation (8.35)</summary>
        public bool CheckEquationEightDotThirtyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Equation (8.36)</summary>
        public double GetXtEquationEightDotThirtySix(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Nn, double Rbnt, double bt);

        /// <summary>Equation (8.38)</summary>
        public double GetMt(double temperatureCurvature, double D);

        /// <summary>Equation (8.39)</summary>
        public double GetMosh(double Mo, double Mt);

        /// <summary>Equation (8.40)</summary>
        public bool CheckEquationEightDotFourty(double Mn, double MultT);

        /// <summary>Equation (8.41)</summary>
        public bool CheckEquationEightDotFourtyOne(double Mo, double Mt, double MultT, out double partLeft);

        /// <summary>Equation (8.42)</summary>
        public bool CheckEquationEightDotFourtyTwo(double q, double lOne, double lTwo, double c, double Rsn, double AsLeft, double AsRight, double AsMiddle, double zLeft, double zRight, double zMiddle, double Rsnt, out double partLeft, out double partRight);

        /// <summary>Equation (8.43)</summary>
        public double GetZ(double h0, double xit);

        /// <summary>Equation (8.44)</summary>
        public double GetXitEquationEightDotFourtyFour(double Rsn, double As, double Rbnt, double lTwo);

        /// <summary>Equation (8.45)</summary>
        public double GetXitEquationEightDotFourtyFive(double Rsnt, double As, double Rbnt, double lTwo);

        /// <summary>Equation (8.46)</summary>
        public bool CheckEquationEightDotFourtySix(double q, double lOne, double lTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Equation (8.47)</summary>
        public double GetMEquationEightDotFourtySeven(double As, double Rsnt, double z);

        /// <summary>Equation (8.48)</summary>
        public double GetMEquationEightDotFourtyEight(double As, double Rsn, double z);

        /// <summary>Equation (8.49)</summary>
        public bool CheckEquationEightDotFourtyNine(double q, double lOne, double lTwo, double aOne, double aTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Equation (8.50)</summary>
        public double GetDeltaSigmaEquationEightDotFifty(double deltaTs, double sigmaSp);

        /// <summary>Equation (8.51)</summary>
        public double GetDeltaSigmaEquationEightDotFiftyOne(double alphaSt, double alphaBt, double deltaTs, double Est);

        /// <summary>Equation (8.52)</summary>
        public double GetSigmaEquationEightDotFiftyTwo(double ts);

        /// <summary>Equation (8.53)</summary>
        public double GetSigmaEquationEightDotFiftyThree(double ts);

        /// <summary>Equation (8.54)</summary>
        public double GetSigmaEquationEightDotFiftyFour(double ts);

        /// <summary>Equation (8.55)</summary>
        public double GetSigmaEquationEightDotFiftyFive(double ts);
    }
}
