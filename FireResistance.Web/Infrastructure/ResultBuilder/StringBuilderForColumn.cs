using FireResistance.Core.Entities.Calculations.AbstractClasses;
using System.Text;

namespace FireResistance.Web.Infrastructure.ResultBuilder
{
    public class StringBuilderForColumn
    {
        public virtual string BuildString(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"_Проверка предела огнестойкости пилона {result.GetItemResult("h")} x {result.GetItemResult("b")}\n");
            BuildDataConstruction(stringBuilder, result);
            BuildPartOneResult(stringBuilder, result);
            if (result.GetItemDescription("FinalEquation") == result.FinalEquations[0]) BuildIfLastIsEightDotTwentyThree(stringBuilder, result);
            else if (result.GetItemDescription("FinalEquation") == result.FinalEquations[1]) BuildIfLastIsEightDotFifteen(stringBuilder, result);
            else if (result.GetItemDescription("FinalEquation") == result.FinalEquations[2]) BuildIfLastIsEightDotTwentyFive(stringBuilder, result);
            return stringBuilder.ToString();
        }

        protected virtual void BuildDataConstruction(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Требуемый предел огнестойкости\n")
                                .Append($"\t{result.GetItemDescription("FireResistanceVolume")}\n")
                            .Append("Длина элемента:\n")
                                .Append($"\tL = {result.GetItemResult("L")} мм\n")
                            .Append("Высота сечения:\n")
                                .Append($"\th = {result.GetItemResult("h")} мм\n")
                            .Append("Ширина сечения:\n")
                                .Append($"\tb = {result.GetItemResult("b")} мм\n")
                            .Append("Закрепление по концам элемента:\n")
                                .Append($"\t{result.GetItemDescription("FixationElement")}\n")
                            .Append("Коэффициент расчетной длинны:\n")
                                .Append($"\t{result.GetItemResult("СoefficientFixationElement")}\n")
                            .Append("Класс бетона по прочности:\n")
                                .Append($"\t{result.GetItemDescription("ClassNameOfConcrete")}\n")
                            .Append("Тип бетона:\n")
                                .Append($"\t{result.GetItemDescription("TypeNameOfConcrete")}\n")
                            .Append("Класс арматуры по прочности:\n")
                                .Append($"\t{result.GetItemDescription("ClassNameOfArmature")}\n")
                            .Append("Расстояние от грани элемента до центра тяжести арматуры:\n")
                                .Append($"\ta = a' = {result.GetItemResult("a")} мм\n")
                            .Append("Диаметр продольной растянутой арматуры:\n")
                                .Append($"\t{result.GetItemResult("DiameterOfArmature")} мм\n")
                            .Append("Количество арматурных стержней:\n")
                                .Append($"\t{result.GetItemResult("CountOfArmature")} шт.\n")
                            .Append("Площадь арматуры:\n")
                                .Append($"\tAs = A's = {result.GetItemResult("As")} мм^2\n")
                            .Append("Температура арматуры определенная по приложению Б СП468.1325800.2019 для угловых стержней:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfArmature")} °С\n")
                            .Append("Температура прогрева бетона определенная в соответствии с п. 5.4 по приложению Б СП468.1325800.2019:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfConcrete")} шт.\n")
                            .Append("Изгибающий момент от постоянной и длительной нормативной нагрузки::\n")
                                .Append($"\tMn = {Math.Round(result.GetItemResult("Mn"), 2)} Н * мм = {result.GetItemResult("Mn") * 0.00000010197162123} т * м\n")
                            .Append("Нормальная сила от постоянной и длительной нормативной нагрузки:\n")
                                .Append($"\tNn = {Math.Round(result.GetItemResult("Nn"), 2)} Н = {result.GetItemResult("Nn") * 0.00010197162123} т\n")
                            .Append("Нормативное сопротивление бетона сжатию. Табл. 6.7, СП63.13330.2018:\n")
                                .Append($"\tRbn = {result.GetItemResult("Rbn")} МПа\n")
                            .Append("Коэффициент условий работы бетона в соответствии с п. 8.7 СП468.1325800.2019:\n")
                                .Append($"\tγbt = {result.GetItemResult("GammaBT")}\n")
                            .Append("Коэффициент βb Табл. 5.1, СП468.1325800.2019:\n")
                                .Append($"\tβb = {result.GetItemResult("BetaB")}\n")
                            .Append("Нормативное сопротивление бетона осевому сжатию с учетом изменения температуры ф.(5.1) СП468.1325800.2019:\n")
                                .Append($"\tRbnt = Rbn*γbt = {result.GetItemResult("Rbnt")} МПа\n")
                            .Append("Нормативное сопротивление арматуры растяжению. Табл. 6.13, СП63.13330.2018:\n")
                                .Append($"\tRsn = {result.GetItemResult("Rsn")} МПа\n")
                            .Append("Нормативное сопротивление арматуры растяжению при высокой температуре. Ф.(5.5) СП468.1325800.2019:\n")
                                .Append($"\tRsnt = Rsn*γst = {result.GetItemResult("Rsnt")} МПа\n")
                            .Append("Коэффициент условий работы арматуры. Табл. 5.6, СП468.1325800.2019:\n")
                                .Append($"\tγst = {result.GetItemResult("GammaST")}\n")
                            .Append("Коэффициент βs. Табл. 5.6, СП468.1325800.2019:\n")
                                .Append($"\tβs = {result.GetItemResult("BetaS")}\n")
                            .Append("Расчетное сопротивление арматуры сжатию. Табл. 6.14, СП63.13330.2018:\n")
                                .Append($"\tRsc = {result.GetItemResult("Rsc")} МПа\n")
                            .Append("Расчетное сопротивление арматуры сжатию при высокой температуре. Ф.(5.6) СП468.1325800.2019:\n")
                                .Append($"\tRsct = Rsc*γst = {result.GetItemResult("Rsct")} МПа\n")
                            .Append("Расчетное сопротивление арматуры растяжению. Табл. 6.14, СП63.13330.2018:\n")
                                .Append($"\tRs = {result.GetItemResult("Rs")} МПа\n")
                            .Append("Расчетное сопротивление арматуры растяжению при высокой температуре. Ф.(5.6) СП468.1325800.2019:\n")
                                .Append($"\tRst = Rsc*γst = {result.GetItemResult("Rst")} МПа\n")
                            .Append("Модуль упругости арматуры. п. 6.2.12 СП63.13330.2018:\n")
                                .Append($"\tEs = {result.GetItemResult("Es")} МПа\n")
                            .Append("Начальный модуль упругости бетона. Табл. 6.11 СП63.13330.2018:\n")
                                .Append($"\tEb = {result.GetItemResult("Eb")} МПа\n")
                            .Append("Глубина прогрева бетона до критической температуры. рис. 8.2 СП468.1325800.2019:\n")
                                .Append($"\tat = {result.GetItemResult("at")} мм\n")
                            .Append("Рабочая высота сечения:\n")
                                .Append($"\tho = h-a = {result.GetItemResult("h0")} мм\n")
                            .Append("Расчетная высота сечения при нагреве:\n")
                                .Append($"\tht = h-2*at = {result.GetItemResult("ht")} мм\n")
                            .Append("Расчетная ширина сечения при нагреве:\n")
                                .Append($"\tbt = b-2*at = {result.GetItemResult("bt")} мм\n")
                            .Append("Площадь приведенного поперечного сечения. Ф.(8.8) СП468.1325800.2019:\n")
                                .Append($"\tAred = 0,9*(b-2*at)*(h-2*at) = {result.GetItemResult("Ared")} мм^2\n")
                            .Append("Расчетная рабочая высота сечения при нагреве:\n")
                                .Append($"\th0t = h0-at = {result.GetItemResult("h0t")} мм\n");
        }

        protected void BuildIfLastIsEightDotTwentyThree(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Так как выполняются условия:\n")
                                .Append($"\te0 = {result.GetItemResult("e0")} ≤ h/30 = {result.GetItemResult("h") / 30}\n")
                                .Append($"\tl0/ht = {result.GetItemResult("lambda")} ≤ 20\n")
                            .Append("Проверка прочности выполняется по формуле 8.23 СП468.1325800.2019:\n")
                                .Append($"\tNn ≤ 𝛗*(Rbnt*Ared+Rsct*As,tot)\n")
                            .Append("𝛗 определяется по таблице 8.1 СП468.1325800.2019:\n")
                                .Append($"\t𝛗 = {result.GetItemResult("fi")}\n")
                            .Append("As,tot площадь всей продольной арматуры в сечении:\n")
                                .Append($"\tAs,tot = {result.GetItemResult("Astot")}\n")
                            .Append("Проврка условия 8.23 СП468.1325800.2019:\n");

            if (result.Status) stringBuilder.Append($"{result.GetItemResult("Nn")} ≤ {result.GetItemResult("RightPartOfFinalEquation")}\n")
                                            .Append($"#Условие выполнено");
            else stringBuilder.Append($"{result.GetItemResult("Nn")} > {result.GetItemResult("RightPartOfFinalEquation")}\n")
                                            .Append($"#Условие не выполнено\n");
        }

        protected void BuildIfLastIsEightDotFifteen(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            BuildPartTwoResult(stringBuilder, result);
            stringBuilder.Append($"\t{result.GetItemResult("Nn")} > {result.GetItemResult("Ncr")}\n")
                                    .Append($"#Условие не выполнено\n");
        }

        protected void BuildIfLastIsEightDotTwentyFive(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            BuildPartTwoResult(stringBuilder, result);
            BuildPartThreeResult(stringBuilder, result);
            BuildPartFourResult(stringBuilder, result);
        }

        protected void BuildPartOneResult(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Эксцентриситет продольной силы относительно центра тяжести приведенного сечения с учетом п. 8.1.7 СП63.13330.2018:\n")
                                .Append($"\te0 = {result.GetItemResult("e0")}\n");
        }

        protected void BuildPartTwoResult(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Относительное значение эксцентриситета продольной силы. п. 8.1.15 СП63.13330.2018:\n")
                                    .Append($"\tδe = {result.GetItemResult("deltaE")}\n")
                                .Append("Расчетная длина элемента:\n")
                                    .Append($"\tL0 = {result.GetItemResult("l0")} мм\n")
                                .Append("Коэф, учитывающий влияние длительности действия нагрузки. п. 8.1.15 СП63.13330.2018:\n")
                                    .Append($"\tφl = {result.GetItemResult("fiL")}\n")
                                .Append("Момент инерции бетонного сечения относительно центра тяжести приведенного сечения:\n")
                                    .Append($"\tI = bt*ht^3/12 = {result.GetItemResult("I")} мм^4\n")
                                .Append("Момент инерции арматуры относительно центра тяжести сечения элемента:\n")
                                    .Append($"\tIs = (As*(h-2*a)^2)/2 = {result.GetItemResult("Is")} мм^4\n")
                                .Append("Модуль упругости арматуры при нагреве:\n")
                                    .Append($"\tEst = Es*βs = {result.GetItemResult("Est")} МПа\n")
                                .Append("Модуль упругости бетона при нагреве:\n")
                                    .Append($"\tEbt = Eb*βb = {result.GetItemResult("Ebt")} МПа\n")
                                .Append("Изгибная жесткость:\n")
                                    .Append($"\tD = 0,15*Ebt*I/(φl*(0,3+δe))+0,7*Est*Is = {result.GetItemResult("D")} мм\n")
                                .Append("Критическая сила:\n")
                                    .Append($"\tNcr = π^2 * D/L0^2 = {result.GetItemResult("Ncr")} Н\n")
                                .Append("Проверка условия:\n")
                                    .Append($"\tNn ≤ Ncr\n");
        }

        protected void BuildPartThreeResult(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Коэффициент учитывающий влияние прогиба п. 8.1.15 СП63.13330.2018:\n")
                        .Append($"\tη = 1/(1-N/Ncr) = {result.GetItemResult("n")}\n")
                    .Append("Расстояние от точки приложения силы N до центра тяжести сечения арматуры:\n")
                        .Append($"\te = e0*η + 0,5 * (h0t - a') + et = {result.GetItemResult("e")} мм\n")
                    .Append("Относительная деформация растянутой арматуры:\n")
                        .Append($"\tεs,el = Rst/Est = {result.GetItemResult("eSel")}\n")
                    .Append("Относительная деформация сжатого бетона. п. 6.1.20 СП63.13330.2018:\n")
                        .Append($"\tεb2 = {result.GetItemResult("ebTwo")}\n")
                    .Append("Граничная относительная высота сжатой зоны:\n")
                        .Append($"\tξR = 0,8/(1+εs,el/εb2) = {result.GetItemResult("KsiR")}\n")
                    .Append("Высота сжатой зоны при  ξ ≤ ξR:\n")
                        .Append($"\txt = (N+Rsnt*As-Rsct*As)/Rbnt*bt = {result.GetItemResult("xtFirst")} мм\n")
                    .Append("Относительная высота сжатой зоны:\n")
                        .Append($"\tξ = xt/h0t = {result.GetItemResult("Ksi")}\n");

            if (result.GetItemResult("Ksi") <= result.GetItemResult("KsiR")) stringBuilder.Append("Условие ξ ≤ ξR выполняется:\n");
            else stringBuilder.Append("Условие ξ ≤ ξR не выполняется:\n")
                               .Append("Высота сжатой зоны при  ξ > ξR:\n")
                                    .Append($"\txt = (N+Rsnt*As*(1+ξR)/(1-ξR)-Rsct*A's)/(Rbnt*bt+2*Rsnt*As/(h0t*(1-ξR)) = {result.GetItemResult("xtSecond")} мм\n");
        }

        protected void BuildPartFourResult(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Проверка условия обеспечения предела огнестойкости (формула 8.25 СП468.1325800.2019):\n")
                                .Append($"\tN*e ≤ Rbnt*bt*xt*(h0t-0,5*xt)+Rsct*A's*(h0-a')\n");

            if (result.Status) stringBuilder.Append($"\t{Math.Round(result.GetItemResult("LeftPartOfFinalEquation"), 1)} ≤ {Math.Round(result.GetItemResult("RightPartOfFinalEquation"), 1)}\n")
                                .Append($"#Условие выполнено\n");
            else stringBuilder.Append($"\t{Math.Round(result.GetItemResult("LeftPartOfFinalEquation"), 1)} > {Math.Round(result.GetItemResult("RightPartOfFinalEquation"), 1)}\n")
                                .Append($"#Условие не выполнено\n");

        }
    }
}
