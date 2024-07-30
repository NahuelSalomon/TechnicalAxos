using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_NahuelSalomon.Helpers
{
    public static class MainThreadHelper
    {
        public static void BeginInvokeOnMainThread(Action action)
        {
            //This for supporting Unit Tests.
            if (DeviceInfo.Platform == DevicePlatform.Unknown)
            {
                Task.Run(action);
                return;
            }

            MainThread.BeginInvokeOnMainThread(action);
        }
        public static bool IsMainThread
        {
            get
            {
                //This for supporting Unit Tests.
                if (DeviceInfo.Platform == DevicePlatform.Unknown)
                {
                    return true;
                }

                return MainThread.IsMainThread;
            }
        }
    }
}
