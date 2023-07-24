namespace FireResistance.Logger
{
    /// <summary>Класс описывает методы для логирования</summary>
    public class FileLogger : IFileLogger, IFileLoggerException
    {
        /// <summary>Метод добавляет информацию о событии</summary>
        public virtual void AddLog(string log)
        {
            WriteLog(WC.PathOfLogger, log);
        }
        /// <summary>Метод добавляет информацию об исключении</summary>
        public virtual void AddLogException(string log)
        {
            WriteLog(WC.PathOfLoggerException, log);
        }
        /// <summary>Метод записывает текст в файл</summary>
        private async void WriteLog(string path, string log)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    await writer.WriteLineAsync(log);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}