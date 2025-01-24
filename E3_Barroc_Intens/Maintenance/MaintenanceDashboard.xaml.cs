using E3_Barroc_Intens.Data;
using E3_Barroc_Intens.Maintenance;
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


namespace E3_Barroc_Intens
{

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

        private void CreateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton repeatInterval = null;
            if (CreateAppointmentDiscriptionTextBox.Text == null || CreateAppointmentDiscriptionTextBox.Text == "")
            {
                return;
            }
            if (CreateAppointmentFromDateCalendarDatePicker.Date == null)
            {
                return;
            }
            if (CreateAppointmentSelectUserComboBox.SelectedItem == null)
            {
                return;
            }
            if (CreateAppointmentSelectCustomerComboBox.SelectedItem == null)
            {
                return;
            }
            if (CreateAppointmentRoutineCheckBox.IsChecked == true)
            {
                if (CreateAppointmentWeeklyRadioButton.IsChecked == true)
                {
                    repeatInterval = CreateAppointmentWeeklyRadioButton as RadioButton;
                }
                if (CreateAppointmentMonthlyRadioButton.IsChecked == true)
                {
                    repeatInterval = CreateAppointmentMonthlyRadioButton as RadioButton;
                }
                if (CreateAppointmentToDateCalenderDatePicker.Date == null)
                {
                    return;
                }
                else
                {
                    return;
                }
            }

            var description = CreateAppointmentDiscriptionTextBox.Text;
            var date = CreateAppointmentFromDateCalendarDatePicker.Date.Value.Date;
            var user = CreateAppointmentSelectUserComboBox.SelectedItem as User;
            var customer = CreateAppointmentSelectCustomerComboBox.SelectedItem as Customer;

            using (var db = new AppDbContext())
            {
                user = db.Users.Where(u => u.Name == user.Name).First();
                customer = db.Customers.Where(c => c.Name == customer.Name).First();

                while (date < CreateAppointmentToDateCalenderDatePicker.Date.Value.Date)
                {
                    var appointment = new Data.Maintenance
                    {
                        UserId = user.Id,
                        CostumerId = customer.Id,
                        Description = description,
                        AppointmentDate = date,
                    };

                    db.Maintenances.Add(appointment);

                    if (repeatInterval.ToString() == "Weekly")
                    {
                        date = date.AddDays(7);
                    }
                    else if (repeatInterval.ToString() == "Monthly")
                    {
                        date = date.AddMonths(1);
                    }
                }

                db.SaveChanges();
            }
        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAppointment));
        }
    }
}
