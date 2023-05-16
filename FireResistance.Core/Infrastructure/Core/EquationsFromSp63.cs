using FireResistance.Core.ExceptionFR;
using FireResistance.Core.Infrastructure.Core.Interfaces;

namespace FireResistance.Core.Infrastructure.Core
{
    internal class EquationsFromSp63 : IEquationsFromSp63
    {
        /// <summary>Equation from item 8.1.7</summary>
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height)
        {
            if (strength <= 0) throw new ExceptionFRBasic("Недопустимое значение продольной силы, ошибка возникла при определении значения e0 по п. 8.1.7 СП63", strength);
            double ea = Math.Max(Math.Max(length / 600, height / 30), 10);
            if (staticallyDefinable) return moment / strength + ea;
            return Math.Max(moment/ strength, ea);
        }

        /// <summary>Equation from item 8.1.15</summary>
        public double GetDeltaE(double e0, double h)
        {
            if (h <= 0) throw new ExceptionFRBasic("Недопустимое значение высоты сечения, ошибка возникла при определении значения δe по п. 8.1.15 СП63", h);
            double deltaE = e0 / h;
            if (deltaE <= 0.15) return 0.15;
            else if (deltaE >= 1.5) return 1.5;
            else return deltaE;
        }

        /// <summary>Equation from item 8.1.15 for get fiL</summary>
        public double GetFiL(double Mone, double MlOne)
        {
            if (Mone <= 0) throw new ExceptionFRBasic("Недопустимое значение изгибающего момента, ошибка возникла при определении значения φl по п. 8.1.15 СП63", Mone);
            double result = (1 + MlOne / Mone);
            if (result > 2) return 2;
            else return result;
        }

        /// <summary>Equation from item 8.1.15 for get kb</summary>
        public double GetKb(double Fil, double DeltaE)
        {
            if (Fil <= 0) throw new ExceptionFRBasic("Недопустимое значение φl, ошибка возникла при определении значения kb по п. 8.1.15 СП63", Fil);
            return 0.15 / (Fil * (0.3 + DeltaE));
        }

        /// <summary>Equation from item 8.1.15 for get ks</summary>
        public double GetKs() => 0.7;

        /// <summary>Equation from item 8.1.15 for get D</summary>
        public double GetD(double kb, double Eb, double I, double ks, double Es, double Is)
            => kb * Eb * I + ks * Es * Is;
        /// <summary>Equation from item 8.1.15 for get Ncr</summary>
        public double GetNcr(double D, double l0)
        {
            if (l0 <= 0) throw new ExceptionFRBasic("Недопустимое значение расчетной длинны элемента, ошибка возникла при определении значения Ncr по п. 8.1.15 СП63", l0);
            return Math.Pow(Math.PI, 2) * D / Math.Pow(l0, 2);
        }
        /// <summary>Equation from item 8.1.15 for get n</summary>
        public double Getn(double N, double Ncr)
        {
            if(Ncr <= 0) throw new ExceptionFRBasic("Недопустимое значение критической силы, ошибка возникла при определении η по п. 8.1.15 СП63", Ncr);
            if (Ncr == N) throw new ExceptionFRBasic("Недопустимое значение в знаменателе при определении η по п. 8.1.15 СП63. N = Ncr", Ncr);
            return 1 / (1 - N / Ncr);
        }
        /// <summary>Equation (8.1)</summary>
        public double GetKsiR(double eSel, double eb)
        {
            if(eb <= 0) throw new ExceptionFRBasic("Недопустимое значение εb, ошибка возникла при определении ξR по формуле 8.1 СП63", eb);
            return 0.8 / (1 + eSel / eb);
        }
        /// <summary>Equation (8.2)</summary>
        public double GetESel(double Rs, double Es)
        {
            if (Es <= 0) throw new ExceptionFRBasic("Недопустимое значение Es, ошибка возникла при определении εs,el по формуле 8.2 СП63", Es);
            return Rs / Es;
        }

    }
}
