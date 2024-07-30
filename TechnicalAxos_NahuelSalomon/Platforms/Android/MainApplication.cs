using Android.App;
using Android.Runtime;
using TechnicalAxos_NahuelSalomon.Services;

namespace TechnicalAxos_NahuelSalomon
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
