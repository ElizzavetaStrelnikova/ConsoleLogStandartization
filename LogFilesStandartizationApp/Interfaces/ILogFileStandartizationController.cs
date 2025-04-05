using LogFilesStandartizationApp.Models;
using System;
using System.Threading.Tasks;

namespace LogFilesStandartizationApp.Interfaces
{
    interface ILogFileStandartizationController
    {
        void GetLogFile();
        (string standardizedLog, bool isValid) ValidateLogFile(string line);
    }
}
