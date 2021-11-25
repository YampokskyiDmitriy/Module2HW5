using System;
using Module2HW5.Helpers;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Application
    {
        private readonly IActionService _actionsService;
        private readonly ILoggerService _loggerService;
        private readonly IDirectoryService _directoryService;
        public Application(IActionService actionsService, ILoggerService loggerService, IDirectoryService directoryService)
        {
            _actionsService = actionsService;
            _loggerService = loggerService;
            _directoryService = directoryService;
        }

        public void Run()
        {
            _directoryService.IsDirecoryExist();
            _directoryService.DeleteOldFiles();

            for (var i = 0; i < 100; i++)
            {
                var method = new Random().Next(1, 4);
                try
                {
                    switch (method)
                    {
                        case 1:
                            _actionsService.MethodInfo();
                            break;
                        case 2:
                            _actionsService.MethodWarning();
                            break;
                        case 3:
                            _actionsService.MethodError();
                            break;
                    }
                }
                catch (BusinessException e)
                {
                    _loggerService.LogWarning($"Action got this custom Exception: {e.Message}");
                }
                catch (Exception e)
                {
                    _loggerService.LogError($"Action failed by reason: {e}");
                }
            }
        }
    }
}
