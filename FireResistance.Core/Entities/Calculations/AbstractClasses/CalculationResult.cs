using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireResistance.Core.Entities.SourceDataForCalculation;
using FireResistance.Core.Entities.SourceDataForCalculation.AbstractClasses;

namespace FireResistance.Core.Entities.Calculations.AbstractClasses
{
    public abstract class CalculationResult <T, K>
    {
        public SourceData<K> SourceData { get; set; }
        public bool Status { get; set; } = false;
        public string ResultAsString { get; set; } = "";
        public string[] FinalEquations { get; set; }

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
