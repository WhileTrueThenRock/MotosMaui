using CommunityToolkit.Maui;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
namespace MauiMotos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
           
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .UseMaterialComponents(new List<string>
            {
                "OpenSans-Regular.ttf",
                "OpenSans-Semibold.ttf",
            })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.ConfigureSyncfusionCore();
            return builder.Build();
        }
    }
}