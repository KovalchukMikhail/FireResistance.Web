using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Logger
{
    public interface IFileLogger
    {
        public void AddLog(string path, string log);
    }
}
