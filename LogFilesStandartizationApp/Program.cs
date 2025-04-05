using LogFilesStandartizationApp.Controllers;
using System;

namespace LogFilesStandartizationApp
{
    class Program
    {
        private readonly LogFileStandartizationController logFileStandartizationController;
        static void Main(string[] args)
        {
            Console.WriteLine("THE LOG STANDARTIZATION IS RUNNING...");

            try
            {
                LogFileStandartizationController.GetLogFile();
                Console.WriteLine("Обработка завершена успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
