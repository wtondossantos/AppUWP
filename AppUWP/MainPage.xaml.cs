using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            this.mainFrame.Navigated += MainFrame_Navigated;

            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled && mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
                e.Handled = true;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            btnFwd.IsEnabled = mainFrame.CanGoForward;
            btnBack.IsEnabled = mainFrame.CanGoBack;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                mainFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnPg1_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(MainPage), "Olá!");
        }
        private void btnPg2_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Pages.ItemView));
        }
        private void btnPg3_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Pages.ConfigurationView));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
                mainFrame.GoBack();
        }

        private void btnFwd_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoForward)
                mainFrame.GoForward();
        }
    }
}
