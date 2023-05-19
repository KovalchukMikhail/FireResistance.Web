using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.Constructions.ConstructionBasic;
using FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab.interfaces;
using System.Text;


namespace FireResistance.Core.Infrastructure.Builder.ResultBuilderBasic.Slab
{
    internal class SlabWithRigidConnectionResultCreator : ISlabWithRigidConnectionResultCreator
    {
        public virtual void AddConstructionDataToResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, SlabFR slab)
        {
            result.AddItemDescription("FireResistanceVolume", slab.FireResistanceVolume);
            result.AddItemDescription("ClassNameOfConcrete", slab.ConcreteFromBelowFR.ClassName);
            result.AddItemDescription("TypeNameOfConcrete", slab.ConcreteFromBelowFR.TypeName);
            result.AddItemDescription("ClassNameOfArmature", slab.ArmatureFRFromAbove.ClassName);
            result.AddItemResult("l1", slab.Length);
            result.AddItemResult("h", slab.Height);
            result.AddItemResult("l2", slab.Width);
            result.AddItemResult("C", slab.DistanceFromEdgeOfColumnToHinge);
            result.AddItemResult("q", slab.DistributedLoad);
            result.AddItemResult("a", slab.ArmatureInstallationDepthFromBelow);
            result.AddItemResult("a'", slab.ArmatureInstallationDepthFromAbove);
            result.AddItemResult("h0", slab.WorkingHeightForBelowArmature);
            result.AddItemResult("h0'", slab.WorkingHeightForAboveArmature);
            result.AddItemResult("CriticalTemperature", slab.ConcreteFromBelowFR.CriticalTemperature);
            result.AddItemResult("at", slab.DeepConcreteWarming);
            result.AddItemResult("h0't", slab.WorkHeightProfileWithWarmingForAboveArmature);
            result.AddItemResult("DiameterOfArmatureFromBelow", slab.ArmatureFRFromBelow.Diameter);
            result.AddItemResult("DiameterOfArmatureFromAbove", slab.ArmatureFRFromAbove.Diameter);
            result.AddItemResult("CountOfArmatureFromBelow", slab.ArmatureFRFromBelow.Count);
            result.AddItemResult("CountOfArmatureFromAbove", slab.ArmatureFRFromAbove.Count);
            result.AddItemResult("As", slab.ArmatureFRFromBelow.Area);
            result.AddItemResult("A's", slab.ArmatureFRFromAbove.Area);
            result.AddItemResult("TemperaturOfArmatureFromBelow", slab.ArmatureFRFromBelow.Temperature);
            result.AddItemResult("TemperaturOfArmatureFromAbove", slab.ArmatureFRFromAbove.Temperature);
            result.AddItemResult("TemperaturOfConcreteFromBelow", slab.ConcreteFromBelowFR.Temperature);
            result.AddItemResult("TemperaturOfConcreteFromAbove", slab.ConcreteOnTopFR.Temperature);
            result.AddItemResult("RbntOfConcreteFromBelow", slab.ConcreteFromBelowFR.ResistWithTemperatureNormativeForSqueeze);
            result.AddItemResult("RbntOfConcreteFromAbove", slab.ConcreteOnTopFR.ResistWithTemperatureNormativeForSqueeze);
            result.AddItemResult("Rbn", slab.ConcreteFromBelowFR.ResistNormativeForSqueeze);
            result.AddItemResult("GammaBTOfConcreteFromBelow", slab.ConcreteFromBelowFR.GammaBT);
            result.AddItemResult("GammaBTOfConcreteFromAbove", slab.ConcreteOnTopFR.GammaBT);
            result.AddItemResult("BetaBOfConcreteFromBelow", slab.ConcreteFromBelowFR.BetaB);
            result.AddItemResult("BetaBOfConcreteFromAbove", slab.ConcreteOnTopFR.BetaB);
            result.AddItemResult("Rsn", slab.ArmatureFRFromAbove.ResistNormativeForStretch);
            result.AddItemResult("RsntOfArmatureFromBelow", slab.ArmatureFRFromBelow.ResistWithTemperatureNormative);
            result.AddItemResult("RsntOfArmatureFromAbove", slab.ArmatureFRFromAbove.ResistWithTemperatureNormative);
            result.AddItemResult("GammaSTOfArmatureFromBelow", slab.ArmatureFRFromBelow.GammaST);
            result.AddItemResult("BetaSOfArmatureFromBelow", slab.ArmatureFRFromBelow.BetaS);
            result.AddItemResult("GammaSTOfArmatureFromAbove", slab.ArmatureFRFromAbove.GammaST);
            result.AddItemResult("BetaSOfArmatureFromAbove", slab.ArmatureFRFromAbove.BetaS);
        }

        public virtual void AddResult(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, TempValuesForSlab values)
        {
            result.AddItemResult("XLiT", values.XLiT);
            result.AddItemResult("XRiT", values.XRiT);
            result.AddItemResult("X1T", values.X1T);
            result.AddItemResult("ZLI", values.ZLI);
            result.AddItemResult("ZRI", values.ZRI);
            result.AddItemResult("Z1", values.Z1);
            result.AddItemResult("LeftPartOfFinalEquation", values.LeftPartOfFinalEquation);
            result.AddItemResult("RightPartOfFinalEquation", values.RightPartOfFinalEquation);
            result.AddItemResult("FinalCoefficient", values.FinalСoefficient);

        }
        public virtual string BuildError(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"#Расчет выполнен некорректно. Список ошибок:\n");
            foreach (string str in result.ExeptionList) stringBuilder.Append($"{str}; \n");
            return stringBuilder.ToString();
        }

        public virtual string BuildString(CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result, bool isOnColumns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"#Проверка предела огнестойкости плиты толщиной {result.GetItemResult("h")}\n");
            if (isOnColumns ) BuildDataConstructionPartOneForSlabOnColumns(stringBuilder, result);
            else BuildDataConstructionPartOneForSlabOnWalls(stringBuilder, result);
            BuildDataConstructionPartTwo(stringBuilder, result);
            BuildResult(stringBuilder, result);
            return stringBuilder.ToString();
        }
        protected virtual void BuildDataConstructionPartOneForSlabOnColumns(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Требуемый предел огнестойкости\n")
                                .Append($"\t{result.GetItemDescription("FireResistanceVolume")}\n")
                            .Append("Высота сечения:\n")
                                .Append($"\th = {result.GetItemResult("h")} мм\n")
                            .Append("Расстояния между рядами колонн в перпендикулярном направлении (длина пролета):\n")
                                .Append($"\tl1 = {result.GetItemResult("l1")} мм\n")
                            .Append("Расстояния между рядами колонн вдоль рассматриваемой полосы (ширина рассматриваемого участка плиты):\n")
                                .Append($"\tl2 = {result.GetItemResult("l2")} мм\n")
                            .Append("Расстояние от крайних пластических шарниров до оси ближайших к ним рядов колонн:\n")
                                .Append($"\tС = {result.GetItemResult("C")} мм\n");
        }
        protected virtual void BuildDataConstructionPartOneForSlabOnWalls(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Требуемый предел огнестойкости\n")
                                .Append($"\t{result.GetItemDescription("FireResistanceVolume")}\n")
                            .Append("Высота сечения:\n")
                                .Append($"\th = {result.GetItemResult("h")} мм\n")
                            .Append("Расстояние между опорами (длина пролета):\n")
                                .Append($"\tl1 = {result.GetItemResult("l1")} мм\n")
                            .Append("Ширина рассматриваемого участка плиты:\n")
                                .Append($"\tl2 = {result.GetItemResult("l2")} мм\n")
                            .Append("Расстояние от крайних пластических шарниров до опоры:\n")
                                .Append($"\tС = {result.GetItemResult("C")} мм\n");
        }
        protected virtual void BuildDataConstructionPartTwo(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Интенсивность нормативной постоянной и временной длительной нагрузок, равномерно распределенных по полосе на 1 пог. м с коэф. перегруза γf = 1:\n")
                                .Append($"\tq = {result.GetItemResult("q") / 0.0098066501} т/м2 = {result.GetItemResult("q")} МПа\n")
                            .Append("Класс бетона по прочности:\n")
                                .Append($"\t{result.GetItemDescription("ClassNameOfConcrete")}\n")
                            .Append("Тип бетона:\n")
                                .Append($"\t{result.GetItemDescription("TypeNameOfConcrete")}\n")
                            .Append("Класс арматуры по прочности:\n")
                                .Append($"\t{result.GetItemDescription("ClassNameOfArmature")}\n")
                            .Append("Расстояние от нижней грани элемента до центра тяжести нижней арматуры:\n")
                                .Append($"\ta = {result.GetItemResult("a")} мм\n")
                            .Append("Расстояние от верхней грани элемента до центра тяжести верхней арматуры:\n")
                                .Append($"\ta' = {result.GetItemResult("a'")} мм\n")
                            .Append("Диаметр продольной нижней арматуры в середине пролета:\n")
                                .Append($"\t{result.GetItemResult("DiameterOfArmatureFromBelow")} мм\n")
                            .Append("Диаметр продольной верхней арматуры на опорах:\n")
                                .Append($"\t{result.GetItemResult("DiameterOfArmatureFromAbove")} мм\n")
                            .Append("Количество стержней нижней арматуры в пролете:\n")
                                .Append($"\t{result.GetItemResult("CountOfArmatureFromBelow")} шт.\n")
                            .Append("Количество стержней верхней арматуры над одной опорой:\n")
                                .Append($"\t{result.GetItemResult("CountOfArmatureFromAbove")} шт.\n")
                            .Append("Площадь нижней арматуры в пролете:\n")
                                .Append($"\tAs1 = {result.GetItemResult("As")} мм^2\n")
                            .Append("Площадь верхней арматуры над одной опорой:\n")
                                .Append($"\tAsI = A'sI = {result.GetItemResult("A's")} мм^2\n")
                            .Append("Критическая температура бетона:\n")
                                .Append($"\t{result.GetItemResult("CriticalTemperature")} °С\n")
                            .Append("Температура нижней арматуры определенная по приложению А СП468.1325800.2019:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfArmatureFromBelow")} °С\n")
                            .Append("Температура верхней арматуры определенная по приложению А СП468.1325800.2019:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfArmatureFromAbove")} °С\n")
                            .Append("Температура прогрева бетона в нижней зоны плиты определенная в соответствии с п. 5.4 по приложению А СП468.1325800.2019 для опорного сечения:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfConcreteFromBelow")} °С\n")
                            .Append("Температура прогрева бетона в верхней зоны плиты определенная в соответствии с п. 5.4 по приложению А СП468.1325800.2019 для сечения в середине пролета:\n")
                                .Append($"\t{result.GetItemResult("TemperaturOfConcreteFromAbove")} °С\n")
                            .Append("Коэффициент условий работы арматуры. Табл. 5.6, СП468.1325800.2019 для нижней арматуры:\n")
                                .Append($"\tγst = {result.GetItemResult("GammaSTOfArmatureFromBelow")}\n")
                            .Append("Коэффициент условий работы арматуры. Табл. 5.6, СП468.1325800.2019 для верхней арматуры:\n")
                                .Append($"\tγ'st = {result.GetItemResult("GammaSTOfArmatureFromAbove")}\n")
                            .Append("Коэффициент условий работы бетона в соответствии с п. 8.7 СП468.1325800.2019 (для бетона нижней зоны):\n")
                                .Append($"\tγbt = {result.GetItemResult("GammaBTOfConcreteFromBelow")}\n")
                            .Append("Коэффициент условий работы бетона в соответствии с п. 8.7 СП468.1325800.2019 (для бетона верхней зоны):\n")
                                .Append($"\tγ'bt = {result.GetItemResult("GammaBTOfConcreteFromAbove")}\n")
                            .Append("Глубина прогрева бетона нижней зоны до критической температуры:\n")
                                .Append($"\tat = {result.GetItemResult("at")} мм\n")
                            .Append("Рабочая высота сечения для нижней арматуры:\n")
                                .Append($"\tho = h-a = {result.GetItemResult("h0")} мм\n")
                            .Append("Рабочая высота сечения для верхней арматуры:\n")
                                .Append($"\tho' = h-a' = {result.GetItemResult("h0'")} мм\n")
                            .Append("Рабочая высота сечения для верхней арматуры за вычетом слоя бетона достигшего критической температуры:\n")
                                .Append($"\tho't = h-a'-at = {result.GetItemResult("h0't")} мм\n")
                            .Append("Нормативное сопротивление бетона сжатию. Табл. 6.7, СП63.13330.2018:\n")
                                .Append($"\tRbn = {result.GetItemResult("Rbn")} МПа\n")
                            .Append("Нормативное сопротивление бетона осевому сжатию с учетом изменения температуры ф.(5.1) СП468.1325800.2019 (для бетона нижней зоны):\n")
                                .Append($"\tRbnt = Rbn*γbt = {result.GetItemResult("RbntOfConcreteFromBelow")} МПа\n")
                            .Append("Нормативное сопротивление бетона осевому сжатию с учетом изменения температуры ф.(5.1) СП468.1325800.2019 (для бетона верхней зоны):\n")
                                .Append($"\tRbnt' = Rbn*γ'bt = {result.GetItemResult("RbntOfConcreteFromAbove")} МПа\n")
                            .Append("Нормативное сопротивление арматуры растяжению. Табл. 6.13, СП63.13330.2018:\n")
                                .Append($"\tRsn = {result.GetItemResult("Rsn")} МПа\n")
                            .Append("Нормативное сопротивление арматуры растяжению при высокой температуре. Ф.(5.5) СП468.1325800.2019 (для нижней арматуры):\n")
                                .Append($"\tRsnt = Rsn*γst = {result.GetItemResult("RsntOfArmatureFromBelow")} МПа\n")
                            .Append("Нормативное сопротивление арматуры растяжению при высокой температуре. Ф.(5.5) СП468.1325800.2019 (для верхней арматуры):\n")
                                .Append($"\tRsnt' = Rsn*γ'st = {result.GetItemResult("RsntOfArmatureFromBelow")} МПа\n");
        }
        protected void BuildResult(StringBuilder stringBuilder, CalculationResult<Dictionary<string, double>, Dictionary<string, string>> result)
        {
            stringBuilder.Append("Высота сжатой зоны в левом опорном пластическом шарнире:\n")
                                    .Append($"\tXi,t = (Rsnt' * AsI)/(Rbnt * l2) = {result.GetItemResult("XLiT")}\n")
                                .Append("Высота сжатой зоны в среднем опорном пластическом шарнире:\n")
                                    .Append($"\tX1,t = (Rsnt * As1)/(Rbnt' * l2) = {result.GetItemResult("X1T")}\n")
                                .Append("Высота сжатой зоны в правом опорном пластическом шарнире:\n")
                                    .Append($"\tX'i,t = (Rsnt' * AsI)/(Rbnt * l2) = {result.GetItemResult("XRiT")}\n")
                                .Append("Плечо внутренней пары сил в левом пластическом шарнире. Ф. (8.43) СП468.1325800.2019:\n")
                                    .Append($"\tZI = ho't - 0,5 * Xi,t = {result.GetItemResult("ZLI")}\n")
                                .Append("Плечо внутренней пары сил в среднем пластическом шарнире. Ф. (8.43) СП468.1325800.2019:\n")
                                    .Append($"\tZ1 = h0 - 0,5 * X1,t = {result.GetItemResult("Z1")} мм\n")
                                .Append("Плечо внутренней пары сил в правом пластическом шарнире. Ф. (8.43) СП468.1325800.2019:\n")
                                    .Append($"\tZ'I = ho't - 0,5 * X'i,t = {result.GetItemResult("ZRI")}\n")
                                .Append("Проверка условия обеспечения предела огнестойкости (формула 8.42 СП468.1325800.2019):\n")
                                    .Append($"\t(q*l2*(l1-2*C)^2)/8 ≤ 0,5*Rsnt'*AsI*ZI+Rsnt*As1*Z1+0,5*Rsnt'*A'sI*Z'I\n");

            if (result.Status) stringBuilder.Append($"\t{Math.Round(result.GetItemResult("LeftPartOfFinalEquation"), 1)} ≤ {Math.Round(result.GetItemResult("RightPartOfFinalEquation"), 1)}\n")
                                .Append($"Условие выполнено\n");
            else stringBuilder.Append($"\t{Math.Round(result.GetItemResult("LeftPartOfFinalEquation"), 1)} > {Math.Round(result.GetItemResult("RightPartOfFinalEquation"), 1)}\n")
                                .Append($"Условие не выполнено\n");
            stringBuilder.Append($"\tКоэффициент использования = {result.GetItemResult("FinalCoefficient")}\n");
        }
    }
}
