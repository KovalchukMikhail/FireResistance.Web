namespace FireResistance.Logger
{
    public interface IFileLoggerException
    {
        /// <summary>Метод добавляет информацию об исключении</summary>
        public void AddLogException(string log);
    }
}
