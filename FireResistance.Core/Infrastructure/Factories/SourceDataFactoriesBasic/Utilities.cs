using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Factories.SourceDataFactoriesBasic
{
    internal class Utilities
    {
        public bool CheckCountValue(Dictionary<string, string> stringValues, Dictionary<string, double> doubleValues, string[] keys)
        {
            foreach (var key in keys)
            {
                if(!(stringValues.ContainsKey(key) || doubleValues.ContainsKey(key))) return false;
            }
            return true;
        }
    }
}
