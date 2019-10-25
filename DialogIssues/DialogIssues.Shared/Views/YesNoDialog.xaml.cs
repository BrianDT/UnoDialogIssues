// <copyright file="YesNoDialog.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace DialogIssues.Shared.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    // The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class YesNoDialog : ContentDialog
    {
        /// <summary>
        /// Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(YesNoDialog), new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="YesNoDialog" /> class.
        /// </summary>
        public YesNoDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the message text
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { this.SetValue(MessageProperty, value); }
        }
    }
}
