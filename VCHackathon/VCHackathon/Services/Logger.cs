using log4net;
using System;

namespace VCHackathon.Services
{
    public static class Logger
    {
        private static readonly ILog loggerLe = LogManager.GetLogger(typeof(Logger));

        public static void LogInfo(string message)
        {
            loggerLe.Info(message);
        }

        public static void LogError(string message, Exception ex)
        {
            var logMessage = $"{message} : {ex.ToString()}";
            loggerLe.Error(logMessage);
        }
    }
}