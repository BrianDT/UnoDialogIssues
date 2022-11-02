// <copyright file="AppStateHelper.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace DialogIssues.Shared
{
    using Microsoft.UI.Xaml;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Windows.Devices.Geolocation;
#if WINDOWS_UWP
    using WUI = Windows.UI.Xaml;
#else
    using WUI = Microsoft.UI.Xaml;
#endif

    /// <summary>
    /// Static holder for App level properties.
    /// </summary>
    public static class AppStateHelper
    {
        private static WUI.Window window;

        public static void SetMainWindow(WUI.Window window)
        {
            AppStateHelper.window = window;
        }

        public static WUI.Window GetMainWindow()
        {
            return AppStateHelper.window;
        }
    }
}
