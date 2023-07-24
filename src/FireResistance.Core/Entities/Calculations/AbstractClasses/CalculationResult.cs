using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Entities.Calculations.AbstractClasses
{
    public abstract class CalculationResult <T, K>
    {
        public SourceData SourceData { get; set; }
        public bool Status { get; set; } = false;
        public string ResultAsString { get; set; } = "";
        public string[] FinalEquations { get; set; }
        public List<string> ExeptionList { get; set; } = new List<string>();

        public abstract double GetItemResult(string key);
        public abstract void AddItemResult(string key, double value);
        public abstract T GetResult();

        public abstract string GetItemDescription(string key);
        public abstract void AddItemDescription(string key, string value);
        public abstract K GetDescription();
        public override string ToString()
        {
            return ResultAsString;
        }
    }
}
