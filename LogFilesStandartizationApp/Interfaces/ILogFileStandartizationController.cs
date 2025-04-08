using LogFilesStandartizationApp.Models;

namespace LogFilesStandartizationApp.Interfaces
{
    interface ILogFileStandartizationController
    {
        void GetLogFile();
        (string standardizedLog, bool isValid) ValidateLogFile(LogFile logEntry);
    }
}
