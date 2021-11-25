using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Providers;
using Module2HW5.Providers.Abstractions;
using Module2HW5.Services;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Starter
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                           .AddSingleton<IConfigProvider, ConfigProvider>()
                           .AddSingleton<ILoggerService, LoggerService>()
                           .AddTransient<IActionService, ActionService>()
                           .AddSingleton<IFileService, FileService>()
                           .AddTransient<IDirectoryService, DirectoryService>()
                           .AddTransient<Application>()
                           .BuildServiceProvider();
            var appStart = serviceProvider.GetService<Application>();
            appStart.Run();
        }
    }
}
