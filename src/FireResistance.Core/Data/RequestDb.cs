using FireResistance.Core.Data.Interfaces;

namespace FireResistance.Core.Data
{
    internal class RequestDb
    {
        public virtual IArmatureAreaRequestDb ArmatureAreaDb { get; set; }
        public virtual IDataSP468RequestDb DataSP468Db { get; set; }
        public virtual IDataSP63RequestDb DataSP63Db { get; set; }
        public virtual IDataTemperatureOfСolumnRequestDb TemperatureOfColumnDb { get; set; }
        public virtual IDataTemperatureOfSlabRequestDb TemperatureOfSlabDb { get; set; }

        public RequestDb(IArmatureAreaRequestDb armatureAreaDb, IDataSP468RequestDb dataSP468Db, IDataSP63RequestDb dataSP63Db, IDataTemperatureOfСolumnRequestDb temperatureOfColumnDb, IDataTemperatureOfSlabRequestDb temperatureOfSlabDb)
        {
            ArmatureAreaDb = armatureAreaDb;
            DataSP468Db = dataSP468Db;
            DataSP63Db = dataSP63Db;
            TemperatureOfColumnDb = temperatureOfColumnDb;
            TemperatureOfSlabDb = temperatureOfSlabDb;
        }
    }
}
