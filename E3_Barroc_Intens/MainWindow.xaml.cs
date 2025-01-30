using E3_Barroc_Intens.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace E3_Barroc_Intens
{

    public sealed partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        private bool isCeo = false;
        public bool IsCeo {
            get
            {
                return isCeo;
            }
            set
            {
                isCeo = value;
                RefreshHeader();
            }
        }

        public MainWindow()
        {
            this.InitializeComponent();

            RootGrid.DataContext = this;

            Instance = this;
            Instance.Title = "Barroc Intens";
            Instance.AppWindow.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);

            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            contentFrame.Navigate(typeof(Login));
        }

        private void RefreshHeader()
        {
            RootGrid.DataContext = null;
            RootGrid.DataContext = this;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Login));
            User.LoggedInUser = null;
            IsCeo = false;

            RefreshHeader();
            SetLoginButtonText("Inloggen");
        }

        public void SetLoginButtonText(string text)
        {
            LoginButton.Content = text;
        }

        private void NavigateToFinance_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(FinanceDashboard));
        }

        private void NavigateToInkoop_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(InkoopDashboard));
        }

        private void NavigateToSales_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(SalesDashboard));
        }

        private void NavigateToMaintenance_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(MaintenanceDashboard));
        }

        private void NavigateToCEO_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(CEODashboard));
        }
    }
}
