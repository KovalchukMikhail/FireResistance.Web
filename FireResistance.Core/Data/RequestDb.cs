using FireResistance.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data
{
    internal class RequestDb
    {
        public virtual IArmatureAreaRequestDb ArmatureAreaDb { get; set; }
        public virtual IDataSP468RequestDb DataSP468Db { get; set; }
        public virtual IDataSP63RequestDb DataSP63Db { get; set; }
        public virtual IDataTemperatureСolumnRequestDb TemperatureDb { get; set; }

        public RequestDb(IArmatureAreaRequestDb armatureAreaDb, IDataSP468RequestDb dataSP468Db, IDataSP63RequestDb dataSP63Db, IDataTemperatureСolumnRequestDb temperatureDb)
        {
            ArmatureAreaDb = armatureAreaDb;
            DataSP468Db = dataSP468Db;
            DataSP63Db = dataSP63Db;
            TemperatureDb = temperatureDb;
        }
    }
}
