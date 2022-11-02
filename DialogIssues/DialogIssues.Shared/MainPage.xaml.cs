// <copyright file="MainPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019 All rights reserved</copyright>

namespace DialogIssues
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DialogIssues.Shared;
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
    using Vssl.Samples.Framework;

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.DisplayMessage();
            };
        }

        /// <summary>
        /// Display a message dialog with a sample message
        /// </summary>
        private void DisplayMessage()
        {
            this.ShowMessageDialog("Oh my god, continue to 2nd page?", this.GoToPage2, this.GoToLastPage, "Display a message");
        }

        /// <summary>
        /// Display a message dialog
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="yesAction">The action executed if the 'yes' button is tapped</param>
        /// <param name="noAction">The action executed if the 'no' button is tapped</param>
        /// <param name="title">The title used for the dialog</param>
        /// <returns>An awaitable task</returns>
        private void ShowMessageDialog(string message, Action yesAction, Action noAction, string title = null)
        {
            DispatchHelper.Dispatcher.Invoke(async () =>
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog(message);
#if NET6_0 && WINDOWS
                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(AppStateHelper.GetMainWindow());
                WinRT.Interop.InitializeWithWindow.Initialize(messageDialog, hwnd);
#endif

                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
                var yesUICommand = new UICommand("Yes", new UICommandInvokedHandler(this.InvokedHandler), yesAction);
                var noUICommand = new UICommand("No", new UICommandInvokedHandler(this.InvokedHandler), noAction);
                messageDialog.Commands.Add(yesUICommand);
                messageDialog.Commands.Add(noUICommand);

                messageDialog.Title = title;

                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                await messageDialog.ShowAsync();
            });
        }

        /// <summary>
        /// Handler called when a button is pressed
        /// </summary>
        /// <param name="command">The UI command</param>
        private void InvokedHandler(IUICommand command)
        {
            if (command.Id != null)
            {
                ICommand embeddedCommand = command.Id as ICommand;
                if (embeddedCommand != null)
                {
                    if (embeddedCommand.CanExecute(null))
                    {
                        embeddedCommand.Execute(null);
                    }
                }
                else
                {
                    Action embeddedAction = command.Id as Action;
                    if (embeddedAction != null)
                    {
                        embeddedAction();
                    }
                }
            }
        }

        /// <summary>
        /// Navigate to page 2
        /// </summary>
        private void GoToPage2()
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        /// <summary>
        /// Navigate to last page
        /// </summary>
        private void GoToLastPage()
        {
            this.Frame.Navigate(typeof(LastPage));
        }

        /// <summary>
        /// A button click event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DisplayMessage();
        }
    }
}
