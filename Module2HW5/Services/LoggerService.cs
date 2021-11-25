using System;
using Module2HW5.Models;
using Module2HW5.Models.Enums;
using Module2HW5.Providers.Abstractions;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly LoggerConfig _configProvider;
        private IDisposable _fileWriter;

        public LoggerService(IFileService fileService, IConfigProvider configProvider)
        {
            _fileService = fileService;
            _configProvider = configProvider.GetConfig().LoggerConfig;
        }

        ~LoggerService()
        {
            _fileService.Close(_fileWriter);
        }

        public void LogInfo(string message)
        {
            Log(message, LoggerType.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LoggerType.Warning);
        }

        public void LogError(string message)
        {
            Log(message, LoggerType.Error);
        }

        public void SetOutput(string filePath)
        {
            _fileWriter = _fileService.Create(filePath);
        }

        private void Log(string message, LoggerType logType)
        {
            var logItem = $"{DateTime.UtcNow.ToString(_configProvider.TimeFormat)}: {logType}: {message}";
            Console.WriteLine(logItem);
            _fileService.Write(_fileWriter, logItem);
        }
    }
}
