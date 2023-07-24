using CalculationException;
using EquationsFromSp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSp
{
    public class EquationsFromSp63 : IEquationsFromSp63
    {
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height)
        {
            if (strength <= 0) throw new ValueException("Недопустимое значение продольной силы, ошибка возникла при определении значения e0 по п. 8.1.7 СП63", strength);
            double ea = Math.Max(Math.Max(length / 600, height / 30), 10);
            if (staticallyDefinable) return moment / strength + ea;
            return Math.Max(moment / strength, ea);
        }
        public double GetDeltaE(double e0, double h)
        {
            if (h <= 0) throw new ValueException("Недопустимое значение высоты сечения, ошибка возникла при определении значения δe по п. 8.1.15 СП63", h);
            double deltaE = e0 / h;
            if (deltaE <= 0.15) return 0.15;
            else if (deltaE >= 1.5) return 1.5;
            else return deltaE;
        }
        public double GetFiL(double Mone, double MlOne)
        {
            if (Mone <= 0) throw new ValueException("Недопустимое значение изгибающего момента, ошибка возникла при определении значения φl по п. 8.1.15 СП63", Mone);
            double result = (1 + MlOne / Mone);
            if (result > 2) return 2;
            else return result;
        }
        public double GetKb(double Fil, double DeltaE)
        {
            if (Fil <= 0) throw new ValueException("Недопустимое значение φl, ошибка возникла при определении значения kb по п. 8.1.15 СП63", Fil);
            return 0.15 / (Fil * (0.3 + DeltaE));
        }
        public double GetKs() => 0.7;
        public double GetD(double kb, double Eb, double I, double ks, double Es, double Is)
            => kb * Eb * I + ks * Es * Is;
        public double GetNcr(double D, double l0)
        {
            if (l0 <= 0) throw new ValueException("Недопустимое значение расчетной длинны элемента, ошибка возникла при определении значения Ncr по п. 8.1.15 СП63", l0);
            return Math.Pow(Math.PI, 2) * D / Math.Pow(l0, 2);
        }
        public double Getn(double N, double Ncr)
        {
            if (Ncr <= 0) throw new ValueException("Недопустимое значение критической силы, ошибка возникла при определении η по п. 8.1.15 СП63", Ncr);
            if (Ncr == N) throw new ValueException("Недопустимое значение в знаменателе при определении η по п. 8.1.15 СП63. N = Ncr", Ncr);
            return 1 / (1 - N / Ncr);
        }
        public double GetKsiR(double eSel, double eb)
        {
            if (eb <= 0) throw new ValueException("Недопустимое значение εb, ошибка возникла при определении ξR по формуле 8.1 СП63", eb);
            return 0.8 / (1 + eSel / eb);
        }
        public double GetESel(double Rs, double Es)
        {
            if (Es <= 0) throw new ValueException("Недопустимое значение Es, ошибка возникла при определении εs,el по формуле 8.2 СП63", Es);
            return Rs / Es;
        }
    }
}
