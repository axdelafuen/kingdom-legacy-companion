using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Services;

namespace KingdomLegacyCompanion
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
                    fonts.AddFont("LibreBaskerville-Regular.ttf", "LibreBaskervilleRegular");
                    fonts.AddFont("SegoeFluentIcons.ttf", "FluentIcons");
                })
                .UseMauiApp<App>().ConfigureEssentials(essentials =>
                {
                    essentials.UseVersionTracking();
                })
                .UseMauiCommunityToolkit();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
