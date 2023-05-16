namespace FireResistance.Logger
{
    public class FileLogger : IFileLogger, IFileLoggerException
    {
        public virtual void AddLog(string log)
        {
            WriteLog(WC.PathOfLogger, log);
        }

        public virtual void AddLogException(string log)
        {
            WriteLog(WC.PathOfLoggerException, log);
        }

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