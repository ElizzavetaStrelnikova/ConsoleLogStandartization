using LogFilesStandartizationApp.Extensions;
using LogFilesStandartizationApp.Interfaces;
using LogFilesStandartizationApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LogFilesStandartizationApp.Controllers
{
    class LogFileStandartizationController : ILogFileStandartizationController
    {
        private readonly DateTimeValidation dateTimeValidation;
        private readonly TextValidation textValidation;
        private readonly LogFile logFile;

        private readonly IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public void GetLogFile()
        {
            string logFilePath = config["Logging:LogFilePath"];
            string fullPath = Path.GetFullPath(logFilePath);

            string rightlogFilePath = config["Logging:RightLogFilePath"];
            string rightfullPath = Path.GetFullPath(rightlogFilePath);

            string problemlogFilePath = config["Logging:ProblemLogFilePath"];
            string problemfullPath = Path.GetFullPath(problemlogFilePath);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("The log file was not found.");
            }

            string[] data = File.ReadAllLines(fullPath);

            foreach (string line in data)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("The log file is empty.");
                    continue;
                }

                (string standardizedLog, bool isValid) = ValidateLogFile(line);

                if (isValid)
                {
                    File.AppendAllText(rightfullPath, standardizedLog + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(problemfullPath, line + Environment.NewLine);
                }
            }
        }

        public (string standardizedLog, bool isValid) ValidateLogFile(string line)
        {
            var logLine = new LogFile();
            
            var dateTime = logLine.Date;
            dateTime = dateTimeValidation.DateTimeValidate(dateTime);

            var loggingLevel = logLine.LoggingLevel;
            loggingLevel = textValidation.TextValidate(loggingLevel.ToString);


        }
    }
}
