using LogFilesStandartizationApp.Enums;
using System;

namespace LogFilesStandartizationApp.Interfaces
{
    interface ILogFile
    {
        DateTime Date { get; set; }
        LoggingLevel LoggingLevel { get; set; }
        
        string CallingMethod { get; set; }
        string Message { get; set; }

    }
}
