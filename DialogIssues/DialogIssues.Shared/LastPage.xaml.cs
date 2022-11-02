// <copyright file="LastPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace DialogIssues.Shared
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
#if WINDOWS_UWP
    using Windows.UI.Xaml.Controls;
#else
    using Microsoft.UI.Xaml.Controls;
#endif

    // The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LastPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LastPage" /> class.
        /// </summary>
        public LastPage()
        {
            this.InitializeComponent();
        }
    }
}
