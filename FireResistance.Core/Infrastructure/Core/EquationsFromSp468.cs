using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Core
{
    internal class EquationsFromSp468 : IEquationsFromSp468
    {
        /// <summary>Equation (5.1)</summary>
        public double GetRbWithGammaBt(double Rb, double gammaBt) => Rb * gammaBt;

        /// <summary>Equation (5.2)</summary>
        public double GetRbtWithGammaBtt(double Rbt, double gammaBtt) => Rbt * gammaBtt;

        /// <summary>Equation (5.3)</summary>
        public double GetEbt(double Eb, double betaB) => Eb * betaB;

        /// <summary>Equation (5.4)</summary>
        public double GetEbTau(double Eb, double FiBCr) => Eb / (1 + FiBCr);

        /// <summary>Equation (5.5, 5.6)</summary>
        public double GetRsWithGammaSt(double Rs, double gammaSt) => Rs * gammaSt;

        /// <summary>Equation (5.7)</summary>
        public double GetEst(double Es, double betaS) => Es * betaS;

        /// <summary>Equation (5.8)</summary>
        public double GetEs0(double Rst, double Est)
        {
            if (Est <= 0) throw new ExceptionFRBasic("Недопустимое значение Est, ошибка возникла при определении Es0 в формуле 5.8 СП468", Est);
            return Rst / Est;
        }

        /// <summary>Equation (8.2)</summary>
        public double GetBtFireThreeSides(double b, double at) => b - 2 * at;

        /// <summary>Equation (8.3)</summary>
        public double GetBftFireThreeSides(double bf, double at) => bf - 2 * at;

        /// <summary>Equation (8.4)</summary>
        public double GetHftFireThreeSides(double hf, double at) => hf - at;

        /// <summary>Equation (8.5)</summary>
        public double GetHtFireThreeSides(double h, double at) => h - at;

        /// <summary>Equation (8.6)</summary>
        public double GetAredColumnFireThreeSides(double h, double b, double at) => 0.95 * (b - 2 * at) * (h - at);

        /// <summary>Equation (8.7)</summary>
        public double GetHtFireFourSides(double h, double at) => h - 2 * at;

        /// <summary>Equation (8.8)</summary>
        public double GetAredColumnFourSides(double h, double b, double at) => 0.9 * (b - 2 * at) * (h - 2 * at);

        /// <summary>Equation (8.9)</summary>
        public double GetH0tWithFire(double h0, double at) => h0 - at;

        /// <summary>Equation (8.10)</summary>
        public double GetMultTEquationEightDotTen(double Rbnt, double b, double xt, double h0, double Rsct, double AsSqueeze, double a)
            => Rbnt * b * xt * (h0 - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);

        /// <summary>Equation (8.11)</summary>
        public double GetXtEquationEightDotEleven(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbnt, double b)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.11 СП468", Rbnt);
            if (b <= 0) throw new ExceptionFRBasic("Недопустимое значение b, ошибка возникла при определении Xt в формуле 8.11 СП468", b);
            return (Rsnt * AsStretch - Rsct * AsSqueeze) / (Rbnt * b);
        }

        /// <summary>Equation (8.12)</summary>
        public double GetMultTEquationEightDotTwelve(double Rsnt, double AsStretch, double h0, double xt, double Rsct, double AsSqueeze, double a)
            => Rsnt * AsStretch * (h0 - 0.5 * xt) + Rsct * AsSqueeze * (0.5 * xt - a);

        /// <summary>Equation (8.13)</summary>
        public double GetGammaStCrFirstOption(double Mn, double Rsn, double AsStretch, double h0, double xt)
        {
            try
            {
                return Mn / (Rsn * AsStretch * (h0 - 0.5 * xt));
            }
            catch(DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.13 СП468");
            }
            
        }

        /// <summary>Equation (8.14)</summary>
        public double GetGammaStCrSecondOption(double Mn, double Rsct, double AsSqueeze, double xt, double a, double Rsn, double AsStretch, double h0)
        {
            try
            {
                return (Mn - Rsct * AsSqueeze * (0.5 * xt - a)) / (Rsn * AsStretch * (h0 - 0.5 * xt));
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.14 СП468");
            }
        }

        /// <summary>Equation (8.15)</summary>
        public bool GetNs(double n1, double Rbtnt, double ls, double us, double alpha, double Rsnt, double AsStretch, out double partLeft, out double partRight)
        {
            if (alpha <= 0) throw new ExceptionFRBasic("Недопустимое значение alpha, ошибка возникла в формуле 8.15 СП468", alpha);
            partLeft = n1 * Rbtnt * ls * us / alpha;
            partRight = Rsnt * AsStretch;
            return partLeft < partRight;
        }

        /// <summary>Equation (8.16)</summary>
        public bool CheckEquationEightDotSixteen(double Rsnt, double AsStretch, double Rbnt, double bft, double hft, double Rsct, double AsSqueeze, out double partLeft, out double partRight)
        {
            partLeft = Rsnt * AsStretch;
            partRight = Rbnt * bft * hft + Rsct* AsSqueeze;
            return partLeft < partRight;
        }

        /// <summary>Equation (8.17)</summary>
        public double GetMultTEquationEightDotSeventeen(double Rbnt, double bt, double xt, double h0, double Rbn, double bft, double hft, double Rsct, double AsStretch, double a)
            => Rbnt * bt * xt * (h0 - 0.5 * xt) + Rbn * (bft - bt) * hft * (h0 - 0.5 * hft) + Rsct * AsStretch * (h0 - a);

        /// <summary>Equation (8.18)</summary>
        public double GetXtEquationEightDotEighteen(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbn, double bft, double bt, double hft, double Rbnt)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.18 СП468", Rbnt);
            if (bt <= 0) throw new ExceptionFRBasic("Недопустимое значение bt, ошибка возникла при определении Xt в формуле 8.18 СП468", bt);
            return (Rsnt * AsStretch - Rsct * AsSqueeze - Rbn * (bft - bt) * hft) / (Rbnt * bt);
        }

        /// <summary>Equation (8.19)</summary>
        public double GetMultTEquationEightDotNineteen(double [] Rsnt, double [] AsStretch, double [] h0, double [] xtForLeft, double[] xtForRight, double [] Rsct, double [] AsSqueeze, double [] a)
        {
            double equationLeft = 0;
            double equationRighht = 0;
            if (Rsnt.Length == AsStretch.Length
                && Rsnt.Length == h0.Length
                && Rsnt.Length == xtForLeft.Length
                && Rsct.Length == AsSqueeze.Length
                && Rsct.Length == xtForRight.Length
                && Rsct.Length == a.Length)
            {
                for (int i = 0; i < Rsnt.Length; i++)
                {
                    equationLeft += Rsnt[i] * AsStretch[i] * (h0[i] - 0.5 * xtForLeft[i]);
                }
                for (int i = 0; i < Rsct.Length; i++)
                {
                    equationLeft += Rsct[i] * AsSqueeze[i] * (0.5 * xtForRight[i] - a[i]);
                }
                return equationLeft + equationRighht;
            }
            else throw new Exception("Ошибка при расчете по формуле 8.19 СП468");
        }

        /// <summary>Equation (8.20)</summary>
        public double GetGammaSCr(double Mn, double A, double B, double Rsn, double AsStretch, double h0, double xt)
        {
            try
            {
                return (Mn - A - B) / (Rsn * AsStretch * (h0 - 0.5 * xt));
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.20 СП468");
            }
        }

        /// <summary>Equation (8.21)</summary>
        public double GetA(double Rbnt, double bt, double xt, double h0, double hft)
            => Rbnt * (bt * xt * (h0 - 0.5 * xt) - hft * (h0 - 0.5 * hft));

        /// <summary>Equation (8.22)</summary>
        public double GetB(double Rsct, double AsStretch, double h0, double a)
            => Rsct * AsStretch * (h0 - a);

        /// <summary>Equation (8.23)</summary>
        public bool CheckEquationEightDotTwentyThree(double fi, double Nn, double Rbnt, double Ared, double Rsct, double Astot, out double partRight)
        {
            partRight = fi * (Rbnt * Ared + Rsct * Astot);
            return Nn <= partRight;
        }

        /// <summary>Equation (8.24)</summary>
        public double GetAred(double d, double at) => 0.785 * Math.Pow(d - 2 * at, 2);

        /// <summary>Equation (8.25)</summary>
        public bool CheckEquationEightDotTwentyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = Nn * e;
            partRight = Rbnt * bt * xt * (h0t - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.26)</summary>
        public double GetXtEquationEightDotTwentySix(double Nn, double Rsnl, double AsStretch, double Rsct, double Rbnt, double bt)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.26 СП468", Rbnt);
            if (bt <= 0) throw new ExceptionFRBasic("Недопустимое значение bt, ошибка возникла при определении Xt в формуле 8.26 СП468", bt);
            return (Nn + Rsnl * AsStretch - Rsct * AsStretch) / (Rbnt * bt);
        }

        /// <summary>Equation (8.27)</summary>
        public double GetXtEquationEightDotTwentySeven(double Nn, double Rsnt, double AsStretch, double KsiR, double Rsct, double AsSqueeze, double Rbnt, double bt, double h0t)
        {
            try
            {
                return (Nn + Rsnt * AsStretch * (1 + KsiR) / (1 - KsiR) - Rsct * AsSqueeze)
                        / (Rbnt * bt + 2 * Rsnt * AsStretch / (h0t * (1 - KsiR)));
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.27 СП468");
            }
            
        }

        /// <summary>Equation (8.28)</summary>
        public double GetEEquationEightDotTwentyEight(double e0, double n, double h0, double a, double et)
            => e0 * n + 0.5 * (h0 - a) + et;

        /// <summary>Equation (8.29)</summary>
        public double GetEt(double a, double alphaSt, double ts, double alphaBt, double tb, double lo, double h0t)
        {
            if (h0t <= 0) throw new ExceptionFRBasic("Недопустимое значение h0t, ошибка возникла при определении et в формуле 8.29 СП468", h0t);
            return a * (alphaSt * ts - alphaBt * tb) * Math.Pow(lo, 2) / (8 * h0t);
        }

        /// <summary>Equation (8.30)</summary>
        public double GetEEquationEightDotThirty(double e0, double Eb1, double Jred, double Nn, double l0)
        {
            try
            {
                return e0 / ((Math.Pow(Math.PI, 2) * Eb1 * Jred / (Nn * Math.Pow(l0, 2))) - 1);
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.30 СП468");
            }
            
        }

        /// <summary>Equation (8.31)</summary>
        public bool CheckEquationEightDotThirtyOne(double Nn, double NultT)
            => Nn < NultT;

        /// <summary>Equation (8.32)</summary>
        public double GetNultT(double Rsnt, double Astot)
            => Rsnt * Astot;

        /// <summary>Equation (8.33)</summary>
        public bool CheckEquationEightDotThirtyThree(double Nn, double e, double Rsnt, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = Nn * e;
            partRight = Rsnt * AsSqueeze * (h0 - a);
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.34)</summary>
        public bool CheckEquationEightDotThirtyFour(double Nn, double e, double Rsnt, double AsStretch, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = Nn * e;
            partRight = Rsnt * AsStretch * (h0 - a);
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.35)</summary>
        public bool CheckEquationEightDotThirtyFive(double NultT, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = NultT * e;
            partRight = Rbnt * bt * xt * (h0t - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.36)</summary>
        public double GetXtEquationEightDotThirtySix(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Nn, double Rbnt, double bt)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.36 СП468", Rbnt);
            if (bt <= 0) throw new ExceptionFRBasic("Недопустимое значение bt, ошибка возникла при определении Xt в формуле 8.36 СП468", bt);
            return (Rsnt * AsStretch - Rsct * AsSqueeze - Nn) / (Rbnt * bt);
        }

        /// <summary>Equation (8.38)</summary>
        public double GetMt(double temperatureCurvature, double D) => temperatureCurvature * D;

        /// <summary>Equation (8.39)</summary>
        public double GetMosh(double Mo, double Mt) => Mo + 0.5 * Mt;

        /// <summary>Equation (8.40)</summary>
        public bool CheckEquationEightDotFourty(double Mn, double MultT) => Mn < MultT;

        /// <summary>Equation (8.41)</summary>
        public bool CheckEquationEightDotFourtyOne(double Mo, double Mt, double MultT, out double partLeft)
        {
            partLeft = Mo + 0.5 * Mt;
            return partLeft <= MultT;
        }

        /// <summary>Equation (8.42)</summary>
        public bool CheckEquationEightDotFourtyTwo(double q, double lOne, double lTwo, double c, double Rsn, double AsLeft, double AsRight, double AsMiddle, double zLeft, double zRight, double zMiddle, double Rsnt, out double partLeft, out double partRight)
        {
            partLeft = q * lTwo * Math.Pow((lOne - 2 * c), 2) / 8;
            partRight = 0.5 * Rsn * AsLeft * zLeft + Rsnt * AsMiddle * zMiddle + 0.5 * Rsn * AsRight * zRight;
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.43)</summary>
        public double GetZ(double h0, double xit) => h0 - 0.5 * xit;

        /// <summary>Equation (8.44)</summary>
        public double GetXitEquationEightDotFourtyFour(double Rsn, double As, double Rbnt, double lTwo)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла в формуле 8.36 СП468", Rbnt);
            if (lTwo <= 0) throw new ExceptionFRBasic("Недопустимое значение lTwo, ошибка возникла в формуле 8.36 СП468", lTwo);
            return Rsn * As / (Rbnt * lTwo);
        }

        /// <summary>Equation (8.45)</summary>
        public double GetXitEquationEightDotFourtyFive(double Rsnt, double As, double Rbnt, double lTwo)
        {
            if (Rbnt <= 0) throw new ExceptionFRBasic("Недопустимое значение Rbnt, ошибка возникла в формуле 8.36 СП468", Rbnt);
            if (lTwo <= 0) throw new ExceptionFRBasic("Недопустимое значение lTwo, ошибка возникла в формуле 8.36 СП468", lTwo);
            return Rsnt* As / (Rbnt * lTwo);
        }

        /// <summary>Equation (8.46)</summary>
        public bool CheckEquationEightDotFourtySix(double q, double lOne, double lTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight)
        {
            partLeft = q * Math.Pow(lOne, 2) * (3 * lTwo - lOne) / 12;
            partRight = 2 * MOne + 2 * MTwo + MILeft + MIRight + MIIDown + MIIUp;
            return partLeft <= partRight;
        }

        /// <summary>Equation (8.47)</summary>
        public double GetMEquationEightDotFourtySeven(double As, double Rsnt, double z) => As * Rsnt * z;

        /// <summary>Equation (8.48)</summary>
        public double GetMEquationEightDotFourtyEight(double As, double Rsn, double z) => As * Rsn * z;

        /// <summary>Equation (8.49)</summary>
        public bool CheckEquationEightDotFourtyNine(double q, double lOne, double lTwo, double aOne, double aTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight)
        {
            try
            {
                partLeft = q * (lOne * lTwo - lOne * aTwo + 4 * aOne * aTwo / 3);
                partRight = (2 * MOne + MILeft + MIRight) / aOne + (2 * MTwo + MIIDown + MIIUp) / aTwo;
                return partLeft <= partRight;
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.49 СП468");
            }
        }

        /// <summary>Equation (8.50)</summary>
        public double GetDeltaSigmaEquationEightDotFifty(double deltaTs, double sigmaSp) => 0.001 * deltaTs * sigmaSp;

        /// <summary>Equation (8.51)</summary>
        public double GetDeltaSigmaEquationEightDotFiftyOne(double alphaSt, double alphaBt, double deltaTs, double Est)
            => (alphaSt - alphaBt) * deltaTs* Est;

        /// <summary>Equation (8.52)</summary>
        public double GetSigmaEquationEightDotFiftyTwo(double ts) => 84 - 0.4 * ts;

        /// <summary>Equation (8.53)</summary>
        public double GetSigmaEquationEightDotFiftyThree(double ts) => 87 - 0.39 * ts;

        /// <summary>Equation (8.54)</summary>
        public double GetSigmaEquationEightDotFiftyFour(double ts) => 92 - 0.26 * ts;

        /// <summary>Equation (8.55)</summary>
        public double GetSigmaEquationEightDotFiftyFive(double ts) => 89 - 0.27 * ts;

        /// <summary>Equation from item 5.4</summary>
        public double GetDistanceFromBringToPointAverageTemperatureForColumn(double h0t, double at, double xt = 0, double KsiR = 0)
        {
            if (xt == 0 || KsiR == 0) return 0.2 * h0t + at;
            else return 0.5 * xt + at;
        }
        /// <summary>Equation from item 5.4</summary>
        public double GetDistanceFromBringToPointAverageTemperatureForSlab(double h0t, double at, double xt = 0, double KsiR = 0)
        {
            if (xt == 0 || KsiR == 0) return 0.1 * h0t + at;
            else return 0.5 * xt + at;
        }
        /// <summary>Equation from item 8.20 for Ksi</summary>
        public double GetKsi(double xt, double h0t)
        {
            if (h0t <= 0) throw new ExceptionFRBasic("Недопустимое значение h0t, ошибка возникла при определении ξ по п. 8.20 СП468", h0t);
            return xt / h0t;
        }
    }
}
