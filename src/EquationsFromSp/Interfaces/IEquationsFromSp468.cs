using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationsFromSp.Interfaces
{
    public interface IEquationsFromSp468
    {
        /// <summary>Формула (5.1)</summary>
        /// <param name="gammaBt">Коэфициент условий работы бетона при сжатии определяется по таблице 5.1</param>
        /// <param name="Rb">Сопротивление бетона(нормативное/расчетное) осевому сжатию. Определяется на основании СП63</param>
        /// <returns>Возвращаемый тип double. Значение сопротивления бетона(нормативное/расчетное) осевому сжатию с учетом увеличения температуры.</returns>
        public double GetRbWithGammaBt(double Rbn, double gammaBt);

        /// <summary>Формула (5.2)</summary>
        /// <param name="gammaBtt">Коэффициент условий работы бетона при растяжении определяется в соответствии с пунктом 5.3</param>
        /// <param name="Rbt">Сопротивление бетона(нормативное/расчетное) растяжению. Определяется на основании СП63</param>
        /// <returns>Возвращаемый тип double. Значение сопротивления бетона(нормативное/расчетное) растяжению с учетом увеличения температуры.</returns>
        public double GetRbtWithGammaBtt(double Rbt, double gammaBtt);

        /// <summary>Формула (5.3)</summary>
        /// <param name="Eb">Начальный модуль упругости. Определяется на основании СП63</param>
        /// <param name="betaB">Коэффициент определяемый по таблице 5.1</param>
        /// <returns>Возвращаемый тип double. Значение начального модуля упругости бетона с учетом увеличения температуры.</returns>
        public double GetEbt(double Eb, double betaB);

        /// <summary>Формула (5.4)</summary>
        /// <param name="Eb">Начальный модуль упругости бетона. Определяется на основании СП63</param>
        /// <param name="FiBCr">Коэффициент ползучести бетона после нагрева. Принимается по таблице 5.1</param>
        /// <returns>Возвращаемый тип double. Значение начального модуля упругости бетона с учетом увеличения температуры при расчете огнесохранности железобетонных
        /// конструкций по предельным состояниям второй группы.</returns>
        public double GetEbTau(double Eb, double FiBCr);
        /// <summary>Формула (5.5, 5.6)</summary>
        /// <param name="gammaSt">Коэфициент условий работы арматуры определяется по таблице 5.1</param>
        /// <param name="Rs">Сопротивление арматуры(нормативное/расчетное). Определяется на основании СП63</param>
        /// <returns>Возвращаемый тип double. Значение сопротивления арматуры(нормативное/расчетное) с учетом увеличения температуры.</returns>
        public double GetRsWithGammaSt(double Rs, double gammaSt);

        /// <summary>Формула (5.7)</summary>
        /// <param name="Es">Модуль упругости арматуры. Определяется на основании СП63</param>
        /// <param name="betaS">Коэффициент определяемый по таблице 5.6</param>
        /// <returns>Возвращаемый тип double. Значение модуля упругости арматуры с учетом увеличения температуры.</returns>
        public double GetEst(double Es, double betaS);

        /// <summary>Формула (5.8)</summary>
        /// <param name="Rst">Модуль упругости арматуры. Определяется на основании СП63</param>
        /// <param name="Est">Модуль упругости арматуры с учетом увеличения температуры. Определяется по уравнению 5.7</param>
        /// <returns>Возвращаемый тип double. Значение относительных деформаций удлинения арматуры при достижении напряжением расчетного сопротивления.</returns>
        public double GetEs0(double Rst, double Est);

        /// <summary>Формула (8.2)</summary>
        /// <param name="b">Ширина колонны или балки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение ширины колонны или балки при трехстороннем нагреве.</returns>
        public double GetBtFireThreeSides(double b, double at);

        /// <summary>Формула (8.3)</summary>
        /// <param name="bf">Ширина полки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение ширины полки при трехстороннем нагреве.</returns>
        public double GetBftFireThreeSides(double bf, double at);

        /// <summary>Формула (8.4)</summary>
        /// <param name="hf">Высота полки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение высоты полки при трехстороннем нагреве.</returns>
        public double GetHftFireThreeSides(double hf, double at);

        /// <summary>Формула (8.5)</summary>
        /// <param name="h">Высота сечения колонны или балки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение высоты колонны или балки при трехстороннем нагреве.</returns>
        public double GetHtFireThreeSides(double h, double at);

        /// <summary>>Формула (8.6)</summary>
        /// <param name="h">Высота сечения колонны или балки</param>
        /// <param name="b">Ширина колонны или балки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение площади колонны или балки при трехстороннем нагреве.</returns>
        public double GetAredColumnFireThreeSides(double h, double b, double at);

        /// <summary>Формула (8.7)</summary>
        /// <param name="h">Высота сечения колонны или балки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение высоты колонны или балки при четырехстороннем нагреве.</returns>
        public double GetHtFireFourSides(double h, double at);

        /// <summary>Формула (8.8)</summary>
        /// <param name="h">Высота сечения колонны или балки</param>
        /// <param name="b">Ширина колонны или балки</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение площади колонны или балки при четырехстороннем нагреве.</returns>
        public double GetAredColumnFourSides(double h, double b, double at);

        /// <summary>Формула (8.9)</summary>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры от обогреваемой грани сечения</param>
        /// <returns>Возвращаемый тип double. Значение рабочей высоты сечения при нагреве со стороны сжатой зоны .</returns>
        public double GetH0tWithFire(double h0, double at);

        /// <summary>Формула (8.10)</summary>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="b">Ширина сечения</param>
        /// <param name="xt">Высота сжатой зоны. Определяется по формуле 8.11</param>
        /// <param name="h0">Рабочая высота сечения</param>м
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <returns>Возвращаемый тип double. Значение предельног значение изгибающего момента плоского изгибаемого элемента в состоянии пределеного равновесия.</returns>
        public double GetMultTEquationEightDotTen(double Rbnt, double b, double xt, double h0, double Rsct, double AsSqueeze, double a);

        /// <summary>Формула (8.11)</summary>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="b">Ширина сечения</param>
        /// <param name="Rsnt">Нормативное сопротивление арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <returns>Возвращаемый тип double. Значение высоты сжатой зоны плоского изгибаемого железобетонного элемента.</returns>
        public double GetXtEquationEightDotEleven(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbnt, double b);

        /// <summary>Формула (8.12)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="xt">Высота сжатой зоны. Определяется по формуле 8.11</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <returns>Возвращаемый тип double. Предельное значение изгибающего момента плоского изгибаемого элемента в состоянии пределеного равновесия в сильно армированных плитах при ξ меньше ξR.</returns>
        public double GetMultTEquationEightDotTwelve(double Rsnt, double AsStretch, double h0, double xt, double Rsct, double AsSqueeze, double a);

        /// <summary>Формула (8.13)</summary>
        /// <param name="Mn">Нормативное значение изгибающего момента</param>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="xt">Высота сжатой зоны. Определяется по формуле 8.11</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <returns>Возвращаемый тип double. Критическое значение коэффициента условий работы растянутой арматуры при ξ меньше ξR и одиночном армировании.</returns>
        public double GetGammaStCrFirstOption(double Mn, double Rsn, double AsStretch, double h0, double xt);

        /// <summary>Формула (8.14)</summary>
        /// <param name="Mn">Нормативное значение изгибающего момента</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="xt">Высота сжатой зоны. Определяется по формуле 8.11</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <returns>Возвращаемый тип double. Критическое значение коэффициента условий работы растянутой арматуры при ξ меньше ξR и двойном армировании.</returns>
        public double GetGammaStCrSecondOption(double Mn, double Rsct, double AsSqueeze, double xt, double a, double Rsn, double AsStretch, double h0);

        /// <summary>Формула (8.15)</summary>
        /// <param name="n1">Коэфициент учитывающий влияние вида поверхности арматуры. Определяется в соответсвии с пунктом 8.11.</param>
        /// <param name="Rbtnt">Нормативное сопротивление бетона осевому растяжению, определяется в соответсвии с пунктом 8.11.</param>
        /// <param name="Rsnt">Нормативное сопротивление арматуры растяжени с учетом увеличения температуры. Определяется в соответствии с пунктом 8.11.</param>
        /// <param name="ls">Расстояние от конца анкеруемого стержня до рассматриваемого поперечного сечения плиты. Определяется в соответствии с пунктом 8.11.</param>
        /// <param name="us">Периметр поперечного сечения анкеруемог стержня, определяемый по его номинальному диаметру</param>
        /// <param name="alpha">Коэффициент учитывающий влияние напряженного состояния бетона, арматуры и конструктивного решения элемента в зоне анкеровки
        ///  на длину анкеровки. Определяется в соответствии с пунктом 8.11.</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <returns>Возвращаемый тип double. Значение усилия Ns воспринимаемого анкерующими стержнями арматуры.</returns>
        public bool GetNs(double n1, double Rbtnt, double ls, double us, double alpha, double Rsnt, double AsStretch, out double partLeft, out double partRight);

        /// <summary>Формула (8.16)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bft">Ширина полки с учетом увеличения температуры. Определяется по формуле (8.3)</param>
        /// <param name="hft">Высота полки с учетом увеличения температуры. Определяется по формуле (8.4)</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotSixteen(double Rsnt, double AsStretch, double Rbnt, double bft, double hft, double Rsct, double AsSqueeze, out double partLeft, out double partRight);

        /// <summary>Формула (8.17)</summary>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны. Определяется по формуле (8.18)</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="Rbn">Нормативное сопротивление бетона осевому сжатию. Определяется на основании СП63</param>
        /// <param name="bft">Ширина полки с учетом увеличения температуры. Определяется по формуле (8.3)</param>
        /// <param name="hft">Высота полки с учетом увеличения температуры. Определяется по формуле (8.4)</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <returns>Возвращаемый тип double. Предельное значение изгибающего момента таврого или двутаврового изгибаемого элемента если граница сжатой зоны проходит в ребре.</returns>
        public double GetMultTEquationEightDotSeventeen(double Rbnt, double bt, double xt, double h0, double Rbn, double bft, double hft, double Rsct, double AsStretch, double a);

        /// <summary>Формула (8.18)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="Rbn">Нормативное сопротивление бетона осевому сжатию. Определяется на основании СП63</param>
        /// <param name="bft">Ширина полки с учетом увеличения температуры. Определяется по формуле (8.3)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <param name="hft">Высота полки с учетом увеличения температуры. Определяется по формуле (8.4)</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <returns>Возвращаемый тип double. Значение высоты сжатой зоны таврового или двутаврого сечения если граница сжатой зоны прохдит в ребре.</returns>
        public double GetXtEquationEightDotEighteen(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Rbn, double bft, double bt, double hft, double Rbnt);

        /// <summary>Формула (8.19)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="xtForLeft">Высота сжатой зоны слева.</param>
        /// <param name="xtForRight">Высота сжатой зоны справа.</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <remarks> Длина массива Rsnt должна быть ровна длине массивов AsStretch, h0, xtForLeft и длина массива Rsct должна быть ровна длине массивов xtForRight, AsSqueeze, a.  Иначе вернется -1</remarks>
        /// <returns>Возвращаемый тип double. Предельное значение изгибающего момента для балок армированных разными классами стали, при многорядном армировании и ξ меньше ξR.</returns>
        public double GetMultTEquationEightDotNineteen(double[] Rsnt, double[] AsStretch, double[] h0, double[] xtForLeft, double[] xtForRight, double[] Rsct, double[] AsSqueeze, double[] a);

        /// <summary>Формула (8.20)</summary>
        /// <param name="Mn">Нормативное значение изгибающего момента</param>
        /// <param name="A">Определяется по формуле (8.21)</param>
        /// <param name="B">Определяется по формуле (8.22)</param>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="xt">Высота сжатой зоны.</param>
        /// <returns>Возвращаемый тип double. Критическое значение коэффициента условий работы растянутой арматуры.</returns>
        public double GetGammaSCr(double Mn, double A, double B, double Rsn, double AsStretch, double h0, double xt);

        /// <summary>Формула (8.21)</summary>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны.</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="hft">Высота полки с учетом увеличения температуры. Определяется по формуле (8.4)</param>
        /// <returns>Возвращаемый тип double.</returns>
        public double GetA(double Rbnt, double bt, double xt, double h0, double hft);

        /// <summary>Формула (8.22)</summary>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <returns>Возвращаемый тип double.</returns>
        public double GetB(double Rsct, double AsSqueeze, double h0, double a);

        /// <summary>Формула (8.23)</summary>
        /// <param name="fi">Коэфициент продольного изгиба. Определяется по таблице 8.1</param>
        /// <param name="Nn">Нормативное значение продольной силы</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="Ared">Приведенная площадь сечения. Определяется по формуле (8.8)</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="Astot">Площадь всей продольной арматуры в сечении</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotTwentyThree(double fi, double Nn, double Rbnt, double Ared, double Rsct, double Astot, out double partRight);

        /// <summary>Формула (8.24)</summary>
        /// <param name="d">Диаметр колонны</param>
        /// <param name="at">Глубина прогрева бетона для круглой колонны. Определяется по пункту 8.19</param>
        /// <returns>Возвращаемый тип double. Значение площади приведенного круглого сечения.</returns>
        public double GetAred(double d, double at);

        /// <summary>Формула (8.25)</summary>
        /// <param name="Nn">Нормативное значение продольной силы</param>
        /// <param name="e">Эксцентриситет или расстояние от точки пприложения продольной силы до центра тяжести сечения растянутой
        ///  или менее сжатой арматуры колонны при огневом воздействии. Определяется по формуле 8.28</param>
        ///  <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        ///  <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        ///  <param name="xt">Высота сжатой зоны. Определяется по формуле (8.26) при ξ меньше или равном ξR иначе по формуле (8.27)</param>
        ///  <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        ///  <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        ///  <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        ///  <param name="h0">Рабочая высота сечения</param>
        ///  <param name="a">Расстояние от края сечения до центра тяжести арматуры AsSqueeze</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotTwentyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.26)</summary>
        /// <param name="Nn">Нормативное значение продольной силы</param>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <returns>Возвращаемый тип double. Значение высоты сжатой зоны при ξ меньше или равном ξR.</returns>
        public double GetXtEquationEightDotTwentySix(double Nn, double Rsnt, double AsStretch, double Rsct, double Rbnt, double bt);

        /// <summary>Формула (8.27)</summary>
        /// <param name="Nn">Нормативное значение продольной силы</param>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="KsiR">Граничное значение относительной высоты сжатой зоны. Определется согласно СП63</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <returns>Возвращаемый тип double. Значение высоты сжатой зоны при ξ больше ξR.</returns>
        public double GetXtEquationEightDotTwentySeven(double Nn, double Rsnt, double AsStretch, double KsiR, double Rsct, double AsSqueeze, double Rbnt, double bt, double h0t);

        /// <summary>Формула (8.28)</summary>
        /// <param name="e0">Эксцентриситет. Определяется погласно СП63</param>
        /// <param name="n">Коэффициент учитывающий влияние прогиба на значение эксцентриситета продольной силы. Определяется погласно СП63</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры</param>
        /// <param name="et">Дополнительный эксцентриситет от огневого воздействия. Определяется по формуле 8.29 с учетом информации пункта 8.21</param>
        /// <returns>Возвращаемый тип double. Значение эксцентриситета или расстояния от точки пприложения продольной силы до центра тяжести сечения растянутой
        ///  или менее сжатой арматуры колонны при огневом воздействии.</returns>
        public double GetEEquationEightDotTwentyEight(double e0, double n, double h0, double a, double et);

        /// <summary>Формула (8.29)</summary>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры</param>
        /// <param name="alphaSt">Коэффициент принимаемый по таблице 5.7 в зависимости от температуры арматуры у нагреваемой грани.</param>
        /// <param name="alphaBt">Коэффициент принимаемый по таблице 5.3 в зависимости от температуры бетона менее нагретой сжатой грани.</param>
        /// <param name="ts">Температура арматуры.</param>
        /// <param name="tb">Температура бетона.</param>
        /// <param name="lo">расчетная длина колонны. Определяется в соответсвии с пунктом 8.21</param>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <returns>Возвращаемый тип double. Значение дополнительного эксцентриситета от огневого воздействия.</returns>
        public double GetEt(double a, double alphaSt, double ts, double alphaBt, double tb, double lo, double h0t);

        /// <summary>Формула (8.30)</summary>
        /// <param name="e0">Эксцентриситет. Определяется погласно СП63</param>
        /// <param name="Eb1">Определяют по формуле (12.7)</param>
        /// <param name="Jred">Определяют по формуле (8.125) СП 63.13330.2018 с учетом формулы (12.6)</param>
        /// <param name="Nn">Нормативное значение продольной силы</param>
        /// <param name="lo">расчетная длина колонны. Определяется в соответсвии с пунктом 8.21</param>
        /// <returns>Возвращаемый тип double. Значение эксцентриситета или расстояния от точки приложения продольной силы до центра тяжести сечения растянутой
        ///  или менее сжатой арматуры колонны при четырехстороннем огневом воздействии.</returns>
        public double GetEEquationEightDotThirty(double e0, double Eb1, double Jred, double Nn, double l0);

        /// <summary>Формула (8.31)</summary>
        /// <param name="Nn">Продольная растягивающая сила от нормативной внешней нагрузки</param>
        /// <param name="NultT"> Предельное значение продольной растягивающей силы, которое может быть воспринято элементом</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotThirtyOne(double Nn, double NultT);

        /// <summary>Формула (8.32)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="Astot"> Площадь сечения всей продольной растянутой арматуры</param>
        /// <returns>Возвращаемый тип double. Предельное значение продольной растягивающей силы, которое может быть воспринято элементом при центральном растяжении.</returns>
        public double GetNultT(double Rsnt, double Astot);

        /// <summary>Формула (8.33)</summary>
        /// <param name="Nn">Продольная растягивающая сила от нормативной внешней нагрузки</param>
        /// <param name="e">Эксцентриситет</param>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotThirtyThree(double Nn, double e, double Rsnt, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.34)</summary>
        /// <param name="Nn">Продольная растягивающая сила от нормативной внешней нагрузки</param>
        /// <param name="e">Эксцентриситет</param>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotThirtyFour(double Nn, double e, double Rsnt, double AsStretch, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.35)</summary>
        /// <param name="Nn">Продольная растягивающая сила от нормативной внешней нагрузки</param>
        /// <param name="e">Эксцентриситет. Определяется согласно пункту 8.28.</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны. Определяется согласно пункту 8.28.</param>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="a">Расстояние от края сечения до центра тяжести арматуры</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotThirtyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.36)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="AsStretch">Площадь сечения растянутой арматуры</param>
        /// <param name="Rsct">Расчетное сопротивление арматуры сжатию с учетом увеличения температуры. Определяется по формуле (5.6)</param>
        /// <param name="AsSqueeze">Площадь сечения сжатой арматуры</param>
        /// <param name="Nn">Продольная растягивающая сила от нормативной внешней нагрузки</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="bt">Ширина сечения с учетом увеличения температуры.</param>
        /// <returns>Возвращаемый тип double. Значение высоты сжатой зоны.</returns>
        public double GetXtEquationEightDotThirtySix(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Nn, double Rbnt, double bt);

        /// <summary>Формула (8.38)</summary>
        /// <param name="temperatureCurvature">Температурная кривизна.</param>
        /// <param name="D">Жесткость сечения в предельной по прочности стадии.</param>
        /// <returns>Возвращаемый тип double. Значение температурного изгибающего момента от неравномерного нагрева по высоте сечения элемента.</returns>
        public double GetMt(double temperatureCurvature, double D);

        /// <summary>Формула (8.39)</summary>
        /// <param name="Mo">Опорные моменты от нагрузки.</param>
        /// <param name="Mt">Опорные моменты от нагрева.</param>
        /// <returns>Возвращаемый тип double. Значение момента образования опорного пластического шарнира.</returns>
        public double GetMosh(double Mo, double Mt);

        /// <summary>Формула (8.40)</summary>
        /// <param name="Mn">Нормативный изгибающий момент от внешней нагрузки (постоянной и временной длительной)</param>
        /// <param name="MultT">Несущая способность железобетонной конструкции при пожаре длительностью, равной значению
        ///  предела огнестойкости по потере несущей способности R.</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotFourty(double Mn, double MultT);

        /// <summary>Формула (8.41)</summary>
        /// <param name="Mo">Нормативный момент от внешней нагрузки в опорном сечении (постоянной и временной длительной).</param>
        /// <param name="Mt">Температурный изгибающий момент, определяемый по формуле (8.38).</param>
        /// <param name="MultT">Несущая способность железобетонной конструкции при пожаре длительностью, равной значению
        ///  предела огнестойкости по потере несущей способности R.</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotFourtyOne(double Mo, double Mt, double MultT, out double partLeft);

        /// <summary>Формула (8.42)</summary>
        /// <param name="q">Интенсивность нормативной постоянной и временной длительной нагрузок, равномерно распределенных
        ///  по полосе на 1 пог. м с коэффициентом перегрузки yf = 1</param>
        /// <param name="lOne">Расстояния между рядами колонн в перпендикулярном направлении.</param>
        /// <param name="lTwo">Расстояния между рядами колонн вдоль рассматриваемой полосы.</param>
        /// <param name="c">Расстояние от крайних пластических шарниров до ближайших к ним рядов колонн.</param>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="AsLeft">Площади верхней растянутой арматуры в левом опорном пластическом шарнире</param>
        /// <param name="AsRight">Площади верхней растянутой арматуры в правом опорном пластическом шарнире</param>
        /// <param name="AsMiddle">Площадь нижней растянутой арматуры в среднем пролетном пластическом шарнире</param>
        /// <param name="zLeft">Плечо внутренней пары сил в левом пластическом шарнире</param>
        /// <param name="zRight">Плечо внутренней пары сил в правом пластическом шарнире</param>
        /// <param name="zMiddle">Плечо внутренней пары сил в среднем пластическом шарнире</param>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotFourtyTwo(double q, double lOne, double lTwo, double c, double Rsn, double AsLeft, double AsRight, double AsMiddle, double zLeft, double zRight, double zMiddle, double Rsnt, out double partLeft, out double partRight);

        /// <summary>Формула (8.43)</summary>
        /// <param name="h0">Рабочая высота сечения</param>
        /// <param name="xit">Высота сжатой зоны</param>
        /// <returns>Возвращаемый тип double. Значение плеча внутренней пары сил.</returns>
        public double GetZ(double h0, double xit);

        /// <summary>Формула (8.44)</summary>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="As">Площадь сечения арматуры</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="lTwo">Расстояния между рядами колонн вдоль рассматриваемой полосы.</param>
        /// <returns>Возвращаемый тип double. Высота сжатой зоны в левом или правом пластическом шарнире.</returns>
        public double GetXitEquationEightDotFourtyFour(double Rsn, double As, double Rbnt, double lTwo);

        /// <summary>Формула (8.45)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="As">Площадь сечения арматуры</param>
        /// <param name="Rbnt">Нормативное сопротивления бетона осевому сжатию с учетом увеличения температуры. Определяется по формуле (5.1)</param>
        /// <param name="lTwo">Расстояния между рядами колонн вдоль рассматриваемой полосы.</param>
        /// <returns>Возвращаемый тип double. Высота сжатой зоны в среднем пролетном пластическом шарнире.</returns>
        public double GetXitEquationEightDotFourtyFive(double Rsnt, double As, double Rbnt, double lTwo);

        /// <summary>Формула (8.46)</summary>
        /// <param name="q">Нормативная постоянная длительная и временная равномерно распределенная нагрузка на 1 м2 плиты.</param>
        /// <param name="lOne">Меньший пролет плиты.</param>
        /// <param name="lTwo">Больший пролет плиты.</param>
        /// <param name="MOne">Момент в проете плиты см. рис.8.13.</param>
        /// <param name="MTwo">Момент в проете плиты см. рис.8.13.</param>
        /// <param name="MILeft">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIRight">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIIDown">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIIUp">Момент на опоре плиты см. рис.8.13.</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotFourtySix(double q, double lOne, double lTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Формула (8.47)</summary>
        /// <param name="Rsnt">Нормативное сопротивления арматуры с учетом увеличения температуры. Определяется по формуле (5.5)</param>
        /// <param name="As">Площадь сечения арматуры</param>
        /// <param name="z">Плечо внутренней пары сил в пролетном пластическом шарнире. Вычесляется согласно пункту 8.46</param>
        /// <returns>Возвращаемый тип double. Значение изгибающего момента в пролете плиты.</returns>
        public double GetMEquationEightDotFourtySeven(double As, double Rsnt, double z);

        /// <summary>Формула (8.48)</summary>
        /// <param name="Rsn">Нормативное сопративление арматуры. Определяется на основании СП63</param>
        /// <param name="As">Площадь сечения арматуры</param>
        /// <param name="z">Плечо внутренней пары сил в опорном пластическом шарнире. Вычесляется согласно пункту 8.46</param>
        /// <returns>Возвращаемый тип double. Значение изгибающего момента на опоре плиты.</returns>
        public double GetMEquationEightDotFourtyEight(double As, double Rsn, double z);

        /// <summary>Формула (8.49)</summary>
        /// <param name="q">Нормативная постоянная длительная и временная равномерно распределенная нагрузка на 1 м2 плиты.</param>
        /// <param name="lOne">Меньший пролет плиты.</param>
        /// <param name="lTwo">Больший пролет плиты.</param>
        /// <param name="aOne">Расстояни обрыва(отгиба) арматуры от длинной стороны.</param>
        /// <param name="aTwo">Расстояни обрыва(отгиба) арматуры от короткой стороны.</param>
        /// <param name="MOne">Момент в проете плиты см. описание формулы (8.49) в СП468.</param>
        /// <param name="MTwo">Момент в проете плиты см. описание формулы (8.49) в СП468.</param>
        /// <param name="MILeft">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIRight">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIIDown">Момент на опоре плиты см. рис.8.13.</param>
        /// <param name="MIIUp">Момент на опоре плиты см. рис.8.13.</param>
        /// <returns>Возвращаемый тип bool. Если условие выполняется возвращается true если не выполняется false.</returns>
        public bool CheckEquationEightDotFourtyNine(double q, double lOne, double lTwo, double aOne, double aTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Формула (8.50)</summary>
        /// <param name="deltaTs">Разность между температурой нагрева арматуры при пожаре и температурой при натяжении.</param>
        /// <param name="sigmaSp">Предварительное напряжение в арматуре принимается с учетом всех потерь при нормальной температуре.</param>
        /// <returns>Возвращаемый тип double. Значение потерь предварительного напряжения в арматуре от релаксации напряжений за 1 - 3 часа нагрева.</returns>
        public double GetDeltaSigmaEquationEightDotFifty(double deltaTs, double sigmaSp);

        /// <summary>Формула (8.51)</summary>
        /// <param name="deltaTs">Разность между температурой нагрева арматуры при пожаре и температурой при натяжении.</param>
        /// <param name="alphaSt">Значение коэффициента определяется по таблице 5.7.</param>
        /// <param name="alphaBt">Значение коэффициента определяется по таблице 5.3.</param>
        /// <param name="Est">Модуль деформации арматуры при нагреве. Определяется по формуле 5.7 в зависимости от температуры нагрева арматуры</param>
        /// <returns>Возвращаемый тип double. Дополнительные потери предварительного напряжения от разности температурных деформаций бетона и арматуры учитываются только при нагреве.</returns>
        public double GetDeltaSigmaEquationEightDotFiftyOne(double alphaSt, double alphaBt, double deltaTs, double Est);

        /// <summary>Формула (8.52)</summary>
        /// <param name="ts">Температура арматуры при пожаре.</param>
        /// <returns>Возвращаемый тип double. Значение потерь предварительного напряжения в стержневой арматуре классов А500, А600.</returns>
        public double GetSigmaEquationEightDotFiftyTwo(double ts);

        /// <summary>Формула (8.53)</summary>
        /// <param name="ts">Температура арматуры при пожаре.</param>
        /// <returns>Возвращаемый тип double. Значение потерь предварительного напряжения в стержневой арматуре классов А800.</returns>
        public double GetSigmaEquationEightDotFiftyThree(double ts);

        /// <summary>Формула (8.54)</summary>
        /// <param name="ts">Температура арматуры при пожаре.</param>
        /// <returns>Возвращаемый тип double. Значение потерь предварительного напряжения в стержневой арматуре классов А1000.</returns>
        public double GetSigmaEquationEightDotFiftyFour(double ts);

        /// <summary>Формула (8.55)</summary>
        /// <param name="ts">Температура арматуры при пожаре.</param>
        /// <returns>Возвращаемый тип double. Значение потерь предварительного напряжения в проволочной арматуре классов Вр1200 - Вр1500, К1400, К1500.</returns>
        public double GetSigmaEquationEightDotFiftyFive(double ts);

        /// <summary>Формула из пункта 5.4, для колонн</summary>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны.</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры.</param>
        /// <param name="KsiR">Граничное значение относительной высоты сжатой зоны. Определется согласно СП63.</param>
        /// <returns>Возвращаемый тип double. Значение расстояния на котором следует определять среднюю температуру сжатой зоны бетона.</returns>
        public double GetDistanceFromBringToPointAverageTemperatureForColumn(double h0t, double at, double xt = 0, double KsiR = 0);

        /// <summary>Формула из пункта 5.4, для плит</summary>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны.</param>
        /// <param name="at">Глубина прогрева бетона до критической температуры.</param>
        /// <param name="KsiR">Граничное значение относительной высоты сжатой зоны. Определется согласно СП63.</param>
        /// <returns>Возвращаемый тип double. Значение расстояния на котором следует определять среднюю температуру сжатой зоны бетона.</returns>
        public double GetDistanceFromBringToPointAverageTemperatureForSlab(double h0t, double at, double xt = 0, double KsiR = 0);
        /// <summary>Уравнение из пункта 8.20 для определения относительной высоты сжатой зоны</summary>
        /// <param name="h0t">Рабочая высота сечения с учетом увеличения температуры.</param>
        /// <param name="xt">Высота сжатой зоны.</param>
        /// <returns>Возвращаемый тип double. Значение относительной высоты сжатой зоны.</returns>
        public double GetKsi(double xt, double h0t);
    }
}
