using System.Windows;
using SelectAid.Services;

namespace SelectAid;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        LoggingService.Initialize();
        LoggingService.LogInfo("Application started.");
    }

    protected override void OnExit(ExitEventArgs e)
    {
        LoggingService.LogInfo("Application exiting.");
        base.OnExit(e);
    }
}
