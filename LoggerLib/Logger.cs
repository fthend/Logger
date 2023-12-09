using System;
using System.IO;

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

        private string logFileName;
        private LogLevel logLevel;
        private LogOutput logOutput;
        private Logger() { }



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