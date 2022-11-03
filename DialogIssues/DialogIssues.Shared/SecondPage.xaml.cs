// <copyright file="SecondPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace DialogIssues.Shared
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using DialogIssues.Shared.Views;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
#if WINDOWS_UWP
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
#else
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
#endif
    using Windows.UI.Popups;

    // The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondPage" /> class.
        /// </summary>
        public SecondPage()
        {
            this.InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.ShowYesNoDialog("Does god exist?", this.GoToPage1, this.GoToLastPage, "Display a message in a  content dialog");
            };
        }

        /// <summary>
        /// Display the Yes No dialog
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="yesAction">The action executed if the 'yes' button is tapped</param>
        /// <param name="noAction">The action executed if the 'no' button is tapped</param>
        /// <param name="title">The title used for the dialog</param>
        private async void ShowYesNoDialog(string message, Action yesAction, Action noAction, string title = null)
        {
            var dialog = new YesNoDialog()
            {
                Title = title,
                Message = message
            };
#if NET6_0 && WINDOWS
            dialog.XamlRoot = AppStateHelper.GetMainWindow().Content.XamlRoot;
#endif

            ContentDialogResult result = await dialog.ShowAsync(ContentDialogPlacement.Popup);
            if (result == ContentDialogResult.Primary)
            {
                yesAction();
            }
            else
            {
                noAction();
            }
        }

        /// <summary>
        /// Navigate to main page
        /// </summary>
        private void GoToPage1()
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Navigate to last page
        /// </summary>
        private void GoToLastPage()
        {
            this.Frame.Navigate(typeof(LastPage));
        }
    }
}
