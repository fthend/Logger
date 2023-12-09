namespace LoggerLib
{
    public enum LogLevel
    {
        TRACE,
        DEBUG,
        INFO,
        WARNING,
        ERROR
    }

    public enum LogOutput
    {
        CONSOLE,
        FILE,
        BOTH
    }

    public sealed class Logger
    {
        private static Logger instance = null;
        private static readonly object padlock = new object();

        private string logFileName = $"log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";
        private LogLevel logLevel = LogLevel.INFO;
        private LogOutput logOutput = LogOutput.CONSOLE;

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        public void SetLogLevel(LogLevel level)
        {
            logLevel = level;
        }

        public void SetLogOutput(LogOutput output)
        {
            logOutput = output;
        }

        public void SetLogFileName(string fileName)
        {
            logFileName = fileName;
        }

        public void Log(LogLevel level, string message)
        {
            if (level >= logLevel)
            {
                string logMessage = $"{DateTime.Now} | {level.ToString()} -> {message}";

                if (logOutput == LogOutput.FILE || logOutput == LogOutput.BOTH)
                {
                    using (StreamWriter writer = File.AppendText(logFileName))
                    {
                        writer.WriteLine(logMessage);
                    }
                }

                if (logOutput == LogOutput.CONSOLE || logOutput == LogOutput.BOTH)
                {
                    Console.WriteLine(logMessage);
                }
            }
        }

        public void LOGE(string message)
        {
            Log(LogLevel.ERROR, message);
        }

        public void LOGW(string message)
        {
            Log(LogLevel.WARNING, message);
        }

        public void LOGI(string message)
        {
            Log(LogLevel.INFO, message);
        }

        public void LOGD(string message)
        {
            Log(LogLevel.DEBUG, message);
        }

        public void LOGT(string message)
        {
            Log(LogLevel.TRACE, message);
        }
    }

}
