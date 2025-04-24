using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace PRG_MAUI_todo_app
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
    .UseMauiApp<App>()
    .ConfigureFonts(fonts =>
    {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    })
#if WINDOWS
    .ConfigureLifecycleEvents(events =>
    {
        events.AddWindows(windows =>
        {
            windows.OnWindowCreated(window =>
            {
                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                var appWindow = AppWindow.GetFromWindowId(windowId);

                appWindow.Resize(new SizeInt32(390, 844));
            });
        });
    })
#endif
;

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
