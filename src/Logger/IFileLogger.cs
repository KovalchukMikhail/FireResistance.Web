namespace FireResistance.Logger
{
    public interface IFileLogger
    {
        /// <summary>Метод добавляет информацию о событии</summary>
        public void AddLog(string log);
    }
}
