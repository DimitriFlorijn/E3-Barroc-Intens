using E3_Barroc_Intens.Data;
using Microsoft.EntityFrameworkCore;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintenanceDashboard : Page
    {
        public MaintenanceDashboard()
        {
            this.InitializeComponent();
            GetIncedentReports();
        }

        private void GetIncedentReports()
        {
            using (var db = new AppDbContext())
            {
                MaintenanceListView.ItemsSource = db.IncendentReports.Include(c => c.Customer).ToList();
            }
        }

        private void MaintenanceListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedIncendent = e.ClickedItem as IncendentReport;

            if (selectedIncendent != null)
            {
                using (var db = new AppDbContext())
                {
                    var incedentReports = db.IncendentReports.Include(c => c.Customer).Where(i => i.Id == selectedIncendent.Id).ToList();
                    if (incedentReports != null && incedentReports.Count > 0)
                    {
                        MaintenanceListViewStackPanel.Visibility = Visibility.Collapsed;
                        MaintenanceIncedentReportStackPanel.Visibility = Visibility.Visible;

                        foreach (var incendentReport in incedentReports)
                        {
                            IncedentReportCustomerNameTextBlock.Text = incendentReport.Customer.Name;
                            IncedentReportCustomerLocationTextBlock.Text = incendentReport.Customer.Location;
                            IncedentReportDateReportedTextBlock.Text = incendentReport.DateReported.ToString();
                            IncedentReportInitialMessageTextBlock.Text = incendentReport.InitialMessage;
                            IncedentReportCoffeeMachineTypeTextBlock.Text = incendentReport.CoffeeMachineType;
                            IncendenReportFaultCodeTextBlock.Text = incendentReport.FaultCode;
                        }
                    }
                }
            }
        }

        private void IncedentReportButton_Click(object sender, RoutedEventArgs e)
        {
            MaintenanceListViewStackPanel.Visibility = Visibility.Visible;
            MaintenanceIncedentReportStackPanel.Visibility = Visibility.Collapsed;
            GetIncedentReports();
        }
    }
}
