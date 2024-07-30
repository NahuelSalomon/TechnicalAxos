using TechnicalAxos_NahuelSalomon.Services;
using AndroidApplication = Android.App.Application;

namespace TechnicalAxos_NahuelSalomon.Platforms.Android.Services
{
    public class AppInfoService : IAppInfoService
    {
        public string GetAppIdentifier()
        {
            return AndroidApplication.Context.PackageName!;
        }
    }
}
