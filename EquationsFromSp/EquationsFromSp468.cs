using CalculationException;
using EquationsFromSp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSp
{
    public class EquationsFromSp468 : IEquationsFromSp468
    {
        public double GetRbWithGammaBt(double Rb, double gammaBt)
        {
            if(Rb < 0) throw new ValueException("Недопустимое значение Rb, ошибка возникла в формуле 5.1 СП468", Rb);
            else if (gammaBt < 0) throw new ValueException("Недопустимое значение gammaBt, ошибка возникла в формуле 5.1 СП468", gammaBt);
            else return Rb * gammaBt;
        }
        public double GetRbtWithGammaBtt(double Rbt, double gammaBtt)
        {
            if (Rbt < 0) throw new ValueException("Недопустимое значение Rbt, ошибка возникла в формуле 5.2 СП468", Rbt);
            else if (gammaBtt < 0) throw new ValueException("Недопустимое значение gammaBtt, ошибка возникла в формуле 5.2 СП468", gammaBtt);
            else return Rbt * gammaBtt;
        }

        public double GetEbt(double Eb, double betaB)
        {
            if (Eb < 0) throw new ValueException("Недопустимое значение Eb, ошибка возникла в формуле 5.3 СП468", Eb);
            else if (betaB < 0) throw new ValueException("Недопустимое значение betaB, ошибка возникла в формуле 5.3 СП468", betaB);
            else return Eb * betaB;
        }
        public double GetEbTau(double Eb, double FiBCr)
        {
            if (Eb < 0) throw new ValueException("Недопустимое значение Eb, ошибка возникла в формуле 5.4 СП468", Eb);
            else if (FiBCr < 0) throw new ValueException("Недопустимое значение FiBCr, ошибка возникла в формуле 5.4 СП468", FiBCr);
            else return Eb / (1 + FiBCr);
        }
        public double GetRsWithGammaSt(double Rs, double gammaSt)
        {
            if (Rs < 0) throw new ValueException("Недопустимое значение Rs, ошибка возникла в формуле 5.5 или 5.6 СП468", Rs);
            else if (gammaSt < 0) throw new ValueException("Недопустимое значение gammaSt, ошибка возникла в формуле 5.5 или 5.6 СП468", gammaSt);
            else return Rs * gammaSt;
        }
        public double GetEst(double Es, double betaS)
        {
            if (Es < 0) throw new ValueException("Недопустимое значение Es, ошибка возникла в формуле 5.7 СП468", Es);
            else if (betaS < 0) throw new ValueException("Недопустимое значение betaS, ошибка возникла в формуле 5.7 СП468", betaS);
            else return Es * betaS;
        }
        public double GetEs0(double Rst, double Est)
        {
            if (Est <= 0) throw new ValueException("Недопустимое значение Est, ошибка возникла в формуле 5.8 СП468", Est);
            else if (Rst < 0) throw new ValueException("Недопустимое значение Rst, ошибка возникла в формуле 5.8 СП468", Rst);
            else return Rst / Est;
        }
        public double GetBtFireThreeSides(double b, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.2 СП468", at);
            else if (b < 2 * at) throw new ValueException("Недопустимое значение b, ошибка возникла в формуле 8.2 СП468, b < 2*at", b);
            else return b - 2 * at;
        }
        public double GetBftFireThreeSides(double bf, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.3 СП468", at);
            else if (bf < 2 * at) throw new ValueException("Недопустимое значение bf, ошибка возникла в формуле 8.3 СП468, bf < 2*at", bf);
            else return bf - 2 * at;
        }
        public double GetHftFireThreeSides(double hf, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.4 СП468", at);
            else if (hf < at) throw new ValueException("Недопустимое значение hf, ошибка возникла в формуле 8.4 СП468, hf < at", hf);
            else return hf - at;
        }
        public double GetHtFireThreeSides(double h, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.5 СП468", at);
            else if (h < at) throw new ValueException("Недопустимое значение h, ошибка возникла в формуле 8.5 СП468, h < at", h);
            else return h - at;
        }
        public double GetAredColumnFireThreeSides(double h, double b, double at) 
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.6 СП468", at);
            else if (h < at) throw new ValueException("Недопустимое значение h, ошибка возникла в формуле 8.6 СП468, h < at", h);
            else if (b < 2 * at) throw new ValueException("Недопустимое значение b, ошибка возникла в формуле 8.6 СП468, b < 2*at", b);
            else return 0.95 * (b - 2 * at) * (h - at);
        } 
        public double GetHtFireFourSides(double h, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.7 СП468", at);
            else if (h < 2 * at) throw new ValueException("Недопустимое значение h, ошибка возникла в формуле 8.7 СП468, h < 2*at", h);
            else return h - 2 * at;
        }
        public double GetAredColumnFourSides(double h, double b, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.8 СП468", at);
            else if (h < 2 * at) throw new ValueException("Недопустимое значение h, ошибка возникла в формуле 8.8 СП468, h < 2*at", h);
            else if (b < 2 * at) throw new ValueException("Недопустимое значение b, ошибка возникла в формуле 8.8 СП468, b < 2*at", b);
            else return 0.9 * (b - 2 * at) * (h - 2 * at);
        }
        public double GetH0tWithFire(double h0, double at)
        {
            if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.9 СП468", at);
            else if (h0 < at) throw new ValueException("Недопустимое значение h0, ошибка возникла в формуле 8.9 СП468, h0 < at", h0);
            else return h0 - at;
        }
        public double GetMultTEquationEightDotTen(double Rbnt, double b, double xt, double h0, double Rsct, double AsSqueeze, double a)
        {
            if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.10 СП468", Rbnt);
            else if (b < 0) throw new ValueException("Недопустимое значение b, ошибка возникла в формуле 8.10 СП468", b);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.10 СП468", xt);
            else if (h0 < xt) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.10 СП468, xt > h0", xt);
            else if (h0 < a) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.10 СП468, a > h0", a);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.10 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.10 СП468", AsSqueeze);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.10 СП468", a);
            else return Rbnt * b * xt * (h0 - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);
        }
        public double GetXtEquationEightDotEleven(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbnt, double b)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.11 СП468", Rbnt);
            else if (b <= 0) throw new ValueException("Недопустимое значение b, ошибка возникла при определении Xt в формуле 8.11 СП468", b);
            else if (Rsnt < 0) throw new ValueException("Недопустимое значение Rsnt, ошибка возникла при определении Xt в формуле 8.11 СП468", Rsnt);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла при определении Xt в формуле 8.11 СП468", AsStretch);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла при определении Xt в формуле 8.11 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла при определении Xt в формуле 8.11 СП468", AsSqueeze);
            else
            {
                double result = (Rsnt * AsStretch - Rsct * AsSqueeze) / (Rbnt * b);
                if (result >= 0) return result;
                else return 0;
            }
        }
        public double GetMultTEquationEightDotTwelve(double Rsnt, double AsStretch, double h0, double xt, double Rsct, double AsSqueeze, double a)
        {
            if (Rsnt < 0) throw new ValueException("Недопустимое значение Rsnt, ошибка возникла в формуле 8.12 СП468", Rsnt);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла при определении Xt в формуле 8.12 СП468", AsStretch);
            else if (h0 < xt) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.12 СП468, xt > h0", xt);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.12 СП468", xt);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.12 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.12 СП468", AsSqueeze);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.12 СП468", a);
            else return Rsnt * AsStretch * (h0 - 0.5 * xt) + Rsct * AsSqueeze * (0.5 * xt - a);
        }
            
        public double GetGammaStCrFirstOption(double Mn, double Rsn, double AsStretch, double h0, double xt)
        {
            if (Rsn <= 0) throw new ValueException("Недопустимое значение Rsn, ошибка возникла в формуле 8.13 СП468", Rsn);
            else if (AsStretch <= 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.13 СП468", AsStretch);
            else if (h0 <= 0) throw new ValueException("Недопустимое значение h0, ошибка возникла в формуле 8.13 СП468", h0);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.13 СП468", xt);
            else
            {
                try
                {
                    return Mn / (Rsn * AsStretch * (h0 - 0.5 * xt));
                }
                catch (DivideByZeroException)
                {
                    throw new Exception("Недопустимое значение в знаменателе, ошибка возникла в формуле 8.13 СП468");
                }
            }

        }
        public double GetGammaStCrSecondOption(double Mn, double Rsct, double AsSqueeze, double xt, double a, double Rsn, double AsStretch, double h0)
        {
            if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.14 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.14 СП468", AsSqueeze);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.14 СП468", xt);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.14 СП468", a);
            else if (Rsn <= 0) throw new ValueException("Недопустимое значение Rsn, ошибка возникла в формуле 8.13 СП468", Rsn);
            else if (AsStretch <= 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.11 СП468", AsStretch);
            else if (h0 <= 0) throw new ValueException("Недопустимое значение h0, ошибка возникла в формуле 8.10 СП468", h0);
            else
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
        }
        public bool GetNs(double n1, double Rbtnt, double ls, double us, double alpha, double Rsnt, double AsStretch, out double partLeft, out double partRight)
        {
            if (alpha <= 0) throw new ValueException("Недопустимое значение alpha, ошибка возникла в формуле 8.15 СП468", alpha);
            else if (n1 < 0) throw new ValueException("Недопустимое значение n1, ошибка возникла в формуле 8.15 СП468", n1);
            else if (Rbtnt < 0) throw new ValueException("Недопустимое значение Rbtnt, ошибка возникла в формуле 8.15 СП468", Rbtnt);
            else if (ls < 0) throw new ValueException("Недопустимое значение ls, ошибка возникла в формуле 8.15 СП468", ls);
            else if (us < 0) throw new ValueException("Недопустимое значение us, ошибка возникла в формуле 8.15 СП468", us);
            else if (Rsnt < 0) throw new ValueException("Недопустимое значение Rsnt, ошибка возникла в формуле 8.15 СП468", Rsnt);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.15 СП468", AsStretch);
            else
            {
                partLeft = n1 * Rbtnt * ls * us / alpha;
                partRight = Rsnt * AsStretch;
                return partLeft < partRight;
            }
        }
        public bool CheckEquationEightDotSixteen(double Rsnt, double AsStretch, double Rbnt, double bft, double hft, double Rsct, double AsSqueeze, out double partLeft, out double partRight)
        {
            if (Rsnt < 0) throw new ValueException("Недопустимое значение Rsnt, ошибка возникла в формуле 8.16 СП468", Rsnt);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.16 СП468", AsStretch);
            else if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.16 СП468", Rbnt);
            else if (bft < 0) throw new ValueException("Недопустимое значение bft, ошибка возникла в формуле 8.16 СП468", bft);
            else if (hft < 0) throw new ValueException("Недопустимое значение hft, ошибка возникла в формуле 8.16 СП468", hft);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.16 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.16 СП468", AsSqueeze);
            else
            {
                partLeft = Rsnt * AsStretch;
                partRight = Rbnt * bft * hft + Rsct * AsSqueeze;
                return partLeft < partRight;
            }
        }
        public double GetMultTEquationEightDotSeventeen(double Rbnt, double bt, double xt, double h0, double Rbn, double bft, double hft, double Rsct, double AsStretch, double a)
        {
            if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.17 СП468", Rbnt);
            else if (bt < 0) throw new ValueException("Недопустимое значение bt, ошибка возникла в формуле 8.17 СП468", bt);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.17 СП468", xt);
            else if (h0 < 0) throw new ValueException("Недопустимое значение ho, ошибка возникла в формуле 8.17 СП468", h0);
            else if (Rbn < 0) throw new ValueException("Недопустимое значение Rbn, ошибка возникла в формуле 8.17 СП468", Rbn);
            else if (bft < 0) throw new ValueException("Недопустимое значение bft, ошибка возникла в формуле 8.17 СП468", bft);
            else if (hft < 0) throw new ValueException("Недопустимое значение hft, ошибка возникла в формуле 8.17 СП468", hft);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.17 СП468", Rsct);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.17 СП468", AsStretch);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.17 СП468", a);
            else
            {
                return Rbnt * bt * xt * (h0 - 0.5 * xt) + Rbn * (bft - bt) * hft * (h0 - 0.5 * hft) + Rsct * AsStretch * (h0 - a);
            } 
        }    
        public double GetXtEquationEightDotEighteen(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbn, double bft, double bt, double hft, double Rbnt)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.18 СП468", Rbnt);
            else if (bt <= 0) throw new ValueException("Недопустимое значение bt, ошибка возникла в формуле 8.18 СП468", bt);
            else if (Rsnt < 0) throw new ValueException("Недопустимое значение Rsnt, ошибка возникла в формуле 8.18 СП468", Rsnt);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.18 СП468", AsStretch);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.18 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.18 СП468", AsSqueeze);
            else if (Rbn < 0) throw new ValueException("Недопустимое значение Rbn, ошибка возникла в формуле 8.18 СП468", Rbn);
            else if (bft < 0) throw new ValueException("Недопустимое значение bft, ошибка возникла в формуле 8.18 СП468", bft);
            else if (bt < 0) throw new ValueException("Недопустимое значение bt, ошибка возникла в формуле 8.18 СП468", bt);
            else if (hft < 0) throw new ValueException("Недопустимое значение hft, ошибка возникла в формуле 8.18 СП468", hft);
            else if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.18 СП468", Rbnt);
            else return (Rsnt * AsStretch - Rsct * AsSqueeze - Rbn * (bft - bt) * hft) / (Rbnt * bt);
        }
        public double GetMultTEquationEightDotNineteen(double[] Rsnt, double[] AsStretch, double[] h0, double[] xtForLeft, double[] xtForRight, double[] Rsct, double[] AsSqueeze, double[] a)
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
        public double GetGammaSCr(double Mn, double A, double B, double Rsn, double AsStretch, double h0, double xt)
        {
            if (Rsn <= 0) throw new ValueException("Недопустимое значение Rsn, ошибка возникла в формуле 8.20 СП468", Rsn);
            else if (AsStretch < 0) throw new ValueException("Недопустимое значение AsStretch, ошибка возникла в формуле 8.20 СП468", AsStretch);
            else if (h0 < 0) throw new ValueException("Недопустимое значение ho, ошибка возникла в формуле 8.20 СП468", h0);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.20 СП468", xt);
            else
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
        }
        public double GetA(double Rbnt, double bt, double xt, double h0, double hft)
        {
            if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.21 СП468", Rbnt);
            else if (bt < 0) throw new ValueException("Недопустимое значение bt, ошибка возникла в формуле 8.21 СП468", bt);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.21 СП468", xt);
            else if (h0 < 0) throw new ValueException("Недопустимое значение ho, ошибка возникла в формуле 8.21 СП468", h0);
            else if (hft < 0) throw new ValueException("Недопустимое значение hft, ошибка возникла в формуле 8.21 СП468", hft);
            else return Rbnt * (bt * xt * (h0 - 0.5 * xt) - hft * (h0 - 0.5 * hft));
        }  
        public double GetB(double Rsct, double AsSqueeze, double h0, double a)
        {
            if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.22 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.22 СП468", AsSqueeze);
            else if (h0 <= a) throw new ValueException("Недопустимое значение ho, ошибка возникла в формуле 8.22 СП468", h0);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.10 СП468", a);
            else return Rsct * AsSqueeze * (h0 - a);
        }
            

        public bool CheckEquationEightDotTwentyThree(double fi, double Nn, double Rbnt, double Ared, double Rsct, double Astot, out double partRight)
        {
            if (fi < 0) throw new ValueException("Недопустимое значение fi, ошибка возникла в формуле 8.23 СП468", fi);
            else if (Nn < 0) throw new ValueException("Недопустимое значение Nn, ошибка возникла в формуле 8.23 СП468", Nn);
            else if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.23 СП468", Rbnt);
            else if (Ared < 0) throw new ValueException("Недопустимое значение Ared, ошибка возникла в формуле 8.23 СП468", Ared);
            else if (Astot < 0) throw new ValueException("Недопустимое значение Astot, ошибка возникла в формуле 8.23 СП468", Astot);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.23 СП468", Rsct);
            else
            {
                partRight = fi * (Rbnt * Ared + Rsct * Astot);
                return Nn <= partRight;
            }
        }
        public double GetAred(double d, double at)
        {
            if(d < 0) throw new ValueException("Недопустимое значение d, ошибка возникла в формуле 8.24 СП468", d);
            else if (at < 0) throw new ValueException("Недопустимое значение at, ошибка возникла в формуле 8.24 СП468", at);
            else return 0.785 * Math.Pow(d - 2 * at, 2);
        } 
        public bool CheckEquationEightDotTwentyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            if (Nn < 0) throw new ValueException("Недопустимое значение Nn, ошибка возникла в формуле 8.25 СП468", Nn);
            else if (e < 0) throw new ValueException("Недопустимое значение e, ошибка возникла в формуле 8.25 СП468", e);
            else if (Rbnt < 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.25 СП468", Rbnt);
            else if (bt < 0) throw new ValueException("Недопустимое значение bt, ошибка возникла в формуле 8.25 СП468", bt);
            else if (xt < 0) throw new ValueException("Недопустимое значение xt, ошибка возникла в формуле 8.25 СП468", xt);
            else if (h0t < 0) throw new ValueException("Недопустимое значение h0t, ошибка возникла в формуле 8.25 СП468", h0t);
            else if (Rsct < 0) throw new ValueException("Недопустимое значение Rsct, ошибка возникла в формуле 8.25 СП468", Rsct);
            else if (AsSqueeze < 0) throw new ValueException("Недопустимое значение AsSqueeze, ошибка возникла в формуле 8.25 СП468", AsSqueeze);
            else if (h0 < 0) throw new ValueException("Недопустимое значение ho, ошибка возникла в формуле 8.25 СП468", h0);
            else if (a < 0) throw new ValueException("Недопустимое значение a, ошибка возникла в формуле 8.25 СП468", a);
            else
            {
                partLeft = Nn * e;
                partRight = Rbnt * bt * xt * (h0t - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);
                return partLeft <= partRight;
            }
        }
        public double GetXtEquationEightDotTwentySix(double Nn, double Rsnt, double AsStretch, double Rsct, double Rbnt, double bt)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.26 СП468", Rbnt);
            if (bt <= 0) throw new ValueException("Недопустимое значение bt, ошибка возникла при определении Xt в формуле 8.26 СП468", bt);
            return (Nn + Rsnt * AsStretch - Rsct * AsStretch) / (Rbnt * bt);
        }
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
        public double GetEEquationEightDotTwentyEight(double e0, double n, double h0, double a, double et)
            => e0 * n + 0.5 * (h0 - a) + et;
        public double GetEt(double a, double alphaSt, double ts, double alphaBt, double tb, double lo, double h0t)
        {
            if (h0t <= 0) throw new ValueException("Недопустимое значение h0t, ошибка возникла при определении et в формуле 8.29 СП468", h0t);
            return a * (alphaSt * ts - alphaBt * tb) * Math.Pow(lo, 2) / (8 * h0t);
        }
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
        public bool CheckEquationEightDotThirtyOne(double Nn, double NultT)
            => Nn < NultT;
        public double GetNultT(double Rsnt, double Astot)
            => Rsnt * Astot;
        public bool CheckEquationEightDotThirtyThree(double Nn, double e, double Rsnt, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = Nn * e;
            partRight = Rsnt * AsSqueeze * (h0 - a);
            return partLeft <= partRight;
        }
        public bool CheckEquationEightDotThirtyFour(double Nn, double e, double Rsnt, double AsStretch, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = Nn * e;
            partRight = Rsnt * AsStretch * (h0 - a);
            return partLeft <= partRight;
        }
        public bool CheckEquationEightDotThirtyFive(double NultT, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight)
        {
            partLeft = NultT * e;
            partRight = Rbnt * bt * xt * (h0t - 0.5 * xt) + Rsct * AsSqueeze * (h0 - a);
            return partLeft <= partRight;
        }
        public double GetXtEquationEightDotThirtySix(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Nn, double Rbnt, double bt)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла при определении Xt в формуле 8.36 СП468", Rbnt);
            if (bt <= 0) throw new ValueException("Недопустимое значение bt, ошибка возникла при определении Xt в формуле 8.36 СП468", bt);
            return (Rsnt * AsStretch - Rsct * AsSqueeze - Nn) / (Rbnt * bt);
        }
        public double GetMt(double temperatureCurvature, double D) => temperatureCurvature * D;
        public double GetMosh(double Mo, double Mt) => Mo + 0.5 * Mt;
        public bool CheckEquationEightDotFourty(double Mn, double MultT) => Mn < MultT;
        public bool CheckEquationEightDotFourtyOne(double Mo, double Mt, double MultT, out double partLeft)
        {
            partLeft = Mo + 0.5 * Mt;
            return partLeft <= MultT;
        }
        public bool CheckEquationEightDotFourtyTwo(double q, double lOne, double lTwo, double c, double Rsn, double AsLeft, double AsRight, double AsMiddle, double zLeft, double zRight, double zMiddle, double Rsnt, out double partLeft, out double partRight)
        {
            partLeft = q * lTwo * Math.Pow((lOne - 2 * c), 2) / 8;
            partRight = 0.5 * Rsn * AsLeft * zLeft + Rsnt * AsMiddle * zMiddle + 0.5 * Rsn * AsRight * zRight;
            return partLeft <= partRight;
        }
        public double GetZ(double h0, double xit) => h0 - 0.5 * xit;
        public double GetXitEquationEightDotFourtyFour(double Rsn, double As, double Rbnt, double lTwo)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.36 СП468", Rbnt);
            if (lTwo <= 0) throw new ValueException("Недопустимое значение lTwo, ошибка возникла в формуле 8.36 СП468", lTwo);
            return Rsn * As / (Rbnt * lTwo);
        }
        public double GetXitEquationEightDotFourtyFive(double Rsnt, double As, double Rbnt, double lTwo)
        {
            if (Rbnt <= 0) throw new ValueException("Недопустимое значение Rbnt, ошибка возникла в формуле 8.36 СП468", Rbnt);
            if (lTwo <= 0) throw new ValueException("Недопустимое значение lTwo, ошибка возникла в формуле 8.36 СП468", lTwo);
            return Rsnt * As / (Rbnt * lTwo);
        }
        public bool CheckEquationEightDotFourtySix(double q, double lOne, double lTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight)
        {
            partLeft = q * Math.Pow(lOne, 2) * (3 * lTwo - lOne) / 12;
            partRight = 2 * MOne + 2 * MTwo + MILeft + MIRight + MIIDown + MIIUp;
            return partLeft <= partRight;
        }
        public double GetMEquationEightDotFourtySeven(double As, double Rsnt, double z) => As * Rsnt * z;
        public double GetMEquationEightDotFourtyEight(double As, double Rsn, double z) => As * Rsn * z;
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
        public double GetDeltaSigmaEquationEightDotFifty(double deltaTs, double sigmaSp) => 0.001 * deltaTs * sigmaSp;
        public double GetDeltaSigmaEquationEightDotFiftyOne(double alphaSt, double alphaBt, double deltaTs, double Est)
            => (alphaSt - alphaBt) * deltaTs * Est;
        public double GetSigmaEquationEightDotFiftyTwo(double ts) => 84 - 0.4 * ts;
        public double GetSigmaEquationEightDotFiftyThree(double ts) => 87 - 0.39 * ts;
        public double GetSigmaEquationEightDotFiftyFour(double ts) => 92 - 0.26 * ts;
        public double GetSigmaEquationEightDotFiftyFive(double ts) => 89 - 0.27 * ts;
        public double GetDistanceFromBringToPointAverageTemperatureForColumn(double h0t, double at, double xt = 0, double KsiR = 0)
        {
            if (xt == 0 || KsiR == 0) return 0.2 * h0t + at;
            else return 0.5 * xt + at;
        }
        public double GetDistanceFromBringToPointAverageTemperatureForSlab(double h0t, double at, double xt = 0, double KsiR = 0)
        {
            if (xt == 0 || KsiR == 0) return 0.1 * h0t + at;
            else return 0.5 * xt + at;
        }
        public double GetKsi(double xt, double h0t)
        {
            if (h0t <= 0) throw new ValueException("Недопустимое значение h0t, ошибка возникла при определении ξ по п. 8.20 СП468", h0t);
            return xt / h0t;
        }
    }
}
