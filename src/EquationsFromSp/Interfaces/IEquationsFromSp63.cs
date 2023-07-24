using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSp.Interfaces
{
    public interface IEquationsFromSp63
    {
        /// <summary>Метод определяет эксцентриситет продольной силы на основании требований пункта 8.1.7</summary>
        /// <param name="staticallyDefinable">Указывает статическиопределенная конструкция или нет</param>
        /// <param name="moment">Изгибающий момент</param>
        /// <param name="strength">Продольная силан</param>
        /// <param name="length">Длина элемента</param>
        /// <param name="height">Высота элемента</param>
        /// <returns>Возвращаемый тип double. Значение эксцентриситета продольной силы</returns>
        public double Gete0(bool staticallyDefinable, double moment, double strength, double length, double height);
        /// <summary>Метод определяет относительное значение эксцентриситета продольной силы на основании пункта 8.1.15</summary>
        /// <param name="e0">Эксцентриситет продольной силы</param>
        /// <param name="h">Высота сечения</param>
        /// <returns>Возвращаемый тип double. Значение относительного значения эксцентриситета продольной силы</returns>
        public double GetDeltaE(double e0, double h);
        /// <summary>Метод определяет коэффициент учитывающий влияние длительности действия нагрузки на основании пункта 8.1.15</summary>
        /// <param name="Mone">Момент относительно центра наиболее растянутого или наименее сжатого стержня от действия полной нагрузки</param>
        /// <param name="MlOne">Момент относительно центра наиболее растянутого или наименее сжатого стержня от действия постоянных и длительных нагрузок</param>
        /// <returns>Возвращаемый тип double. Значение коэффициента учитывающего влияние длительности действия нагрузки</returns>
        public double GetFiL(double Mone, double MlOne);
        /// <summary>Метод определяет коэффициент kb на основании пункта 8.1.15</summary>
        /// <param name="Fil">Коэффициент учитывающий влияние длительности действия нагрузки определяется на основании пункта 8.1.15</param>
        /// <param name="DeltaE">Относительное значение эксцентриситета продольной силы определяется на основании пункта 8.1.15</param>
        /// <returns>Возвращаемый тип double. Значение коэффициента kb</returns>
        public double GetKb(double Fil, double DeltaE);
        /// <summary>Метод определяет коэффициент ks на основании пункта 8.1.15</summary>
        /// <returns>Возвращаемый тип double. Значение коэффициента ks</returns>
        public double GetKs();
        /// <summary>Метод определяет жесткость железобетонного элемента в предельной по прочности стадии на основании пункта 8.1.15</summary>
        /// <param name="kb">Коэффициент определяется на основании пункта 8.1.15</param>
        /// <param name="ks">Коэффициент определяется на основании пункта 8.1.15</param>
        /// <param name="Eb">Модуль упругости бетона</param>
        /// <param name="Es">Модуль упругости арматуры</param>
        /// <param name="I">Момент инерции площади сечения бетона относительно центра тяжести поперечного сечения элемента</param>
        /// <param name="Is">Момент инерции площади сечения арматуры относительно центра тяжести поперечного сечения элемента</param>
        /// <returns>Возвращаемый тип double. Значение жесткости железобетонного элемента</returns>
        public double GetD(double kb, double Eb, double I, double ks, double Es, double Is);
        /// <summary>Метод определяет условную критическую силу на основании формулы 8.15</summary>
        /// <param name="D">Жесткость железобетонного элемента в предельной по прочности стадии определяется на основании пункта 8.1.15</param>
        /// <param name="l0">Расчтеная длинна элемента</param>
        /// <returns>Возвращаемый тип double. Значение условной критической силы.</returns>
        public double GetNcr(double D, double l0);
        /// <summary>Метод определяет коэффициент n при расчете конструкции по недеформированной схеме на основании формулы 8.14</summary>
        /// <param name="N">Продольная сила от внешних нагрузок</param>
        /// <param name="Ncr">Условная критическая сила, определяется по формуле 8.15</param>
        /// <returns>Возвращаемый тип double. Значение коэффициента n.</returns>
        public double Getn(double N, double Ncr);
        /// <summary>Метод определяет предельное значение относительной высоты сжатой зоны ξR на основании формулы 8.1</summary>
        /// <param name="eSel">Относительная деформация расстянутой арматуры</param>
        /// <param name="ebTwo">Относительная деформация сжатого бетона</param>
        /// <returns>Возвращаемый тип double. Значение предельного значения относительной высоты сжатой зоны ξR.</returns>
        public double GetKsiR(double eSel, double ebTwo);
        /// <summary>Метод определяет относительную деформацию сжатого бетона</summary>
        /// <returns>Возвращаемый тип double. Значение относительной деформации сжатого бетона.</returns>
        public double GetEbTwo();
        /// <summary>Equation (8.2)</summary>
        /// <summary>Метод определяет относительную деформацию растянутой арматуры при напряжениях равных Rs на основании формулы 8.2</summary>
        /// <param name="Rs">Расчетное значение сопротивления арматуры</param>
        /// <param name="Es">Модуль деформации арматуры</param>
        /// <returns>Возвращаемый тип double. Значение относительной деформации растянутой арматуры.</returns>
        public double GetESel(double Rs, double Es);
    }
}
