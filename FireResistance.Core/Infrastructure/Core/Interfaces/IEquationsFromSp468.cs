
namespace FireResistance.Core.Infrastructure.Core.Interfaces
{
    internal interface IEquationsFromSp468
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
        /// <returns>Возвращаемый тип double. Предельное значение изгибающего момента плоского изгибаемого элемента в состоянии пределеного равновесия в сильно армированных плитах при ξ < ξR.</returns>
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
        public double GetGammaSCr(double Mn, double A, double B, double Rsn, double AsStretch, double h0, double xt);

        /// <summary>Формула (8.21)</summary>
        public double GetA(double Rbnt, double bt, double xt, double h0, double hft);

        /// <summary>Формула (8.22)</summary>
        public double GetB(double Rsct, double AsStretch, double h0, double a);

        /// <summary>Формула (8.23)</summary>
        public bool CheckEquationEightDotTwentyThree(double fi, double Nn, double Rbnt, double Ared, double Rsct, double Astot, out double partRight);

        /// <summary>Формула (8.24)</summary>
        public double GetAred(double d, double at);

        /// <summary>Формула (8.25)</summary>
        public bool CheckEquationEightDotTwentyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.26)</summary>
        public double GetXtEquationEightDotTwentySix(double Nn, double Rsnl, double AsStretch, double Rsct, double Rbnt, double bt);

        /// <summary>Формула (8.27)</summary>
        public double GetXtEquationEightDotTwentySeven(double Nn, double Rsnt, double AsStretch, double Er, double Rsct, double AsSqueeze, double Rbnt, double bt, double h0t);

        /// <summary>Формула (8.28)</summary>
        public double GetEEquationEightDotTwentyEight(double e0, double n, double h0, double a, double et);

        /// <summary>Формула (8.29)</summary>
        public double GetEt(double a, double alphaSt, double ts, double alphaBt, double tb, double lo, double h0t);

        /// <summary>Формула (8.30)</summary>
        public double GetEEquationEightDotThirty(double e0, double Eb1, double Jred, double Nn, double l0);

        /// <summary>Формула (8.31)</summary>
        public bool CheckEquationEightDotThirtyOne(double Nn, double NultT);

        /// <summary>Формула (8.32)</summary>
        public double GetNultT(double Rsnt, double Astot);

        /// <summary>Формула (8.33)</summary>
        public bool CheckEquationEightDotThirtyThree(double Nn, double e, double Rsnt, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.34)</summary>
        public bool CheckEquationEightDotThirtyFour(double Nn, double e, double Rsnt, double AsStretch, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.35)</summary>
        public bool CheckEquationEightDotThirtyFive(double Nn, double e, double Rbnt, double bt, double xt, double h0t, double Rsct, double AsSqueeze, double h0, double a, out double partLeft, out double partRight);

        /// <summary>Формула (8.36)</summary>
        public double GetXtEquationEightDotThirtySix(double Rsnt, double AsStretch, double Rsct, double AsSqueeze, double Nn, double Rbnt, double bt);

        /// <summary>Формула (8.38)</summary>
        public double GetMt(double temperatureCurvature, double D);

        /// <summary>Формула (8.39)</summary>
        public double GetMosh(double Mo, double Mt);

        /// <summary>Формула (8.40)</summary>
        public bool CheckEquationEightDotFourty(double Mn, double MultT);

        /// <summary>Формула (8.41)</summary>
        public bool CheckEquationEightDotFourtyOne(double Mo, double Mt, double MultT, out double partLeft);

        /// <summary>Формула (8.42)</summary>
        public bool CheckEquationEightDotFourtyTwo(double q, double lOne, double lTwo, double c, double Rsn, double AsLeft, double AsRight, double AsMiddle, double zLeft, double zRight, double zMiddle, double Rsnt, out double partLeft, out double partRight);

        /// <summary>Формула (8.43)</summary>
        public double GetZ(double h0, double xit);

        /// <summary>Формула (8.44)</summary>
        public double GetXitEquationEightDotFourtyFour(double Rsn, double As, double Rbnt, double lTwo);

        /// <summary>Формула (8.45)</summary>
        public double GetXitEquationEightDotFourtyFive(double Rsnt, double As, double Rbnt, double lTwo);

        /// <summary>Формула (8.46)</summary>
        public bool CheckEquationEightDotFourtySix(double q, double lOne, double lTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Формула (8.47)</summary>
        public double GetMEquationEightDotFourtySeven(double As, double Rsnt, double z);

        /// <summary>Формула (8.48)</summary>
        public double GetMEquationEightDotFourtyEight(double As, double Rsn, double z);

        /// <summary>Формула (8.49)</summary>
        public bool CheckEquationEightDotFourtyNine(double q, double lOne, double lTwo, double aOne, double aTwo, double MOne, double MTwo, double MILeft, double MIRight, double MIIDown, double MIIUp, out double partLeft, out double partRight);

        /// <summary>Формула (8.50)</summary>
        public double GetDeltaSigmaEquationEightDotFifty(double deltaTs, double sigmaSp);

        /// <summary>Формула (8.51)</summary>
        public double GetDeltaSigmaEquationEightDotFiftyOne(double alphaSt, double alphaBt, double deltaTs, double Est);

        /// <summary>Формула (8.52)</summary>
        public double GetSigmaEquationEightDotFiftyTwo(double ts);

        /// <summary>Формула (8.53)</summary>
        public double GetSigmaEquationEightDotFiftyThree(double ts);

        /// <summary>Формула (8.54)</summary>
        public double GetSigmaEquationEightDotFiftyFour(double ts);

        /// <summary>Формула (8.55)</summary>
        public double GetSigmaEquationEightDotFiftyFive(double ts);

        /// <summary>Equation from item 5.4 for Column</summary>
        public double GetDistanceFromBringToPointAverageTemperatureForColumn(double h0t, double at, double xt = 0, double KsiR = 0);

        /// <summary>Equation from item 5.4 for slab</summary>
        public double GetDistanceFromBringToPointAverageTemperatureForSlab(double h0t, double at, double xt = 0, double KsiR = 0);
        /// <summary>Equation from item 8.20 for Ksi</summary>
        public double GetKsi(double xt, double h0t);
    }
}
