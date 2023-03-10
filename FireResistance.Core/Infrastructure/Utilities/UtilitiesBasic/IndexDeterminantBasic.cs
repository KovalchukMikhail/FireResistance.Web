using FireResistance.Core.Infrastructure.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Infrastructure.Utilities.UtilitiesBasic
{
    internal class IndexDeterminantBasic : IIndexDeterminant
    {
        public double GetIndex(string value, List<string> list)
        {    
            return list.IndexOf(value);
        }

        public double GetIndex(double value, List<double> list)
        {
            double indexValue = list.IndexOf(value);
            
            if(indexValue == -1)
            {
                int preIndex = 0;
                int nextIndex = 0;
                double preValue = 0;
                double nextValue = 0;
                for(int i = 0; i < list.Count - 1; i++)
                {
                    preValue = list[i];
                    nextValue = list[i + 1];

                    if (preValue < value && nextValue > value) 
                    {
                        preIndex = i;
                        nextIndex = i + 1;
                        double appendix = (value - preValue)/(nextValue - preValue);
                        indexValue = appendix + preIndex;
                        break;
                    } 
                }
            }
            return indexValue;
        }

    }
}

