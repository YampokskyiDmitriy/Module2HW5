using System;
using System.IO;
using Module2HW5.Helpers;
using Module2HW5.Models;
using Module2HW5.Providers.Abstractions;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IConfigProvider _configProvider;
        private readonly ILoggerService _loggerService;
        private readonly LoggerConfig _config;
        public DirectoryService(IConfigProvider configProvider, ILoggerService loggerService)
        {
            _configProvider = configProvider;
            _loggerService = loggerService;
            _config = _configProvider.GetConfig().LoggerConfig;
            Init();
        }

        public void IsDirecoryExist()
        {
            if (!Directory.Exists(_config.DirectoryPath))
            {
                Directory.CreateDirectory(_config.DirectoryPath);
            }
        }

        public void DeleteOldFiles()
        {
            var files = Directory.GetFiles(_config.DirectoryPath);
            var filesLimit = _config.FilesLimit;
            while (files.Length > filesLimit)
            {
                Array.Sort(files, new FileComparer());
                var fileInfo = new FileInfo(files[0]);

                fileInfo.Delete();
                files = Directory.GetFiles(_config.DirectoryPath);
            }
        }

        private void Init()
        {
            var loggerConfig = _configProvider.GetConfig().LoggerConfig;
            var dirPath = loggerConfig.DirectoryPath;
            var fileTitle = DateTime.UtcNow.ToString(loggerConfig.FileNameFormat);
            var extension = loggerConfig.FileExtension;
            var filePath = $"{dirPath}{fileTitle}{extension}";
            _loggerService.SetOutput(filePath);
        }
    }
}