using LogFilesStandartizationApp.Enums;
using LogFilesStandartizationApp.Interfaces;
using System;

namespace LogFilesStandartizationApp.Models
{
    class LogFile : ILogFile
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public LoggingLevel LoggingLevel { get; set; }
        public string CallingMethod { get; set; } = "DEFAULT";
        public string Message { get; set; }

        public bool IsAppropriate { get; set; } = true;

        public LogFile() { }

        public LogFile(DateTime date, 
            LoggingLevel loggingLevel, 
            string callingMethod, 
            string message) 
        { 
            Date = date;
            LoggingLevel = loggingLevel;
            CallingMethod = callingMethod;
            Message = message;
        }
    }
}
