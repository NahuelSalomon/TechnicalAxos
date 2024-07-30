using TechnicalAxos_NahuelSalomon.Platforms.iOS.Services;
using TechnicalAxos_NahuelSalomon.Services;
using Foundation;

[assembly: Dependency(typeof(AppInfoService))]

namespace TechnicalAxos_NahuelSalomon.Platforms.iOS.Services
{
    public class AppInfoService : IAppInfoService
    {
        public string GetAppIdentifier()
        {
            return NSBundle.MainBundle.BundleIdentifier;
        }
    }
}
