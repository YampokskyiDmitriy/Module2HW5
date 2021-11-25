using System;
using System.Reflection;
using Module2HW5.Helpers;
using Module2HW5.Services.Abstractions;

namespace Module2HW5.Services
{
    public class ActionService : IActionService
    {
        private readonly ILoggerService _loggerService;
        public ActionService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool MethodInfo()
        {
            _loggerService.LogInfo($"Start method: {MethodBase.GetCurrentMethod().Name}.");
            return true;
        }

        public bool MethodWarning()
        {
            throw new BusinessException("Skipped logic in method.");
        }

        public bool MethodError()
        {
            throw new Exception("I broke a logic.");
        }
    }
}