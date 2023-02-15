using FireResistance.Core.Entities.Calculations.AbstractClasses;
using FireResistance.Core.Entities.SourceDataForCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Calculations
{
    public class ResultAsDictionary : CalculationResult <Dictionary<string, double>, Dictionary<string, string>>
    {
        private Dictionary<string, double> result;
        private Dictionary<string, string> description;

        public ResultAsDictionary(SourceData sourceData) : base(sourceData)
        {
            result = new Dictionary<string, double>();
            description = new Dictionary<string, string>();
        }

        public override double GetItemResult(string key) => result[key];

        public override void AddItemResult(string key, double value) => result.Add(key, value);

        public override Dictionary<string, double> GetResult()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            return dict = result.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public override string GetItemDescription(string key) => description[key];
        public override void AddItemDescription(string key, string value) => description.Add(key, value);

        public override Dictionary<string, string> GetDescription()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            return dict = description.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}
