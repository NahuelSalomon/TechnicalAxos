using Microsoft.Extensions.Logging;
using TechnicalAxos_NahuelSalomon.Services;
using TechnicalAxos_NahuelSalomon.ViewModels;
using TechnicalAxos_NahuelSalomon.Views;

namespace TechnicalAxos_NahuelSalomon
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped<ICountryService, CountryService>();
            return builder.Build();
        }
    }
}
