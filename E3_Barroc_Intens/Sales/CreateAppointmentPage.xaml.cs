using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using E3_Barroc_Intens.Data;
using System;
using System.Linq;
using Microsoft.UI.Xaml;

namespace E3_Barroc_Intens.Sales
{
    public sealed partial class CreateAppointmentPage : Page
    {
        public CreateAppointmentPage()
        {
            this.InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var db = new AppDbContext())
            {
                var customers = db.Customers.ToList();
                CustomerComboBox.ItemsSource = customers;
                CustomerComboBox.DisplayMemberPath = "Name";
                CustomerComboBox.SelectedValuePath = "Id";
            }
        }

        private void SaveAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue == null)
            {
                ShowErrorMessage("Please select a customer.");
                return;
            }

            if (DatePicker.Date != null)
            {
                if (TimePicker.SelectedTime == null)
                {
                    ShowErrorMessage("Please select a time.");
                    return;
                }

                int customerId = (int)CustomerComboBox.SelectedValue;
                var date = DatePicker.Date.DateTime;
                var time = TimePicker.SelectedTime.Value;

                var dateTime = date.Add(time);
                if (dateTime <= DateTime.Now)
                {
                    ShowErrorMessage("The date and time cannot be in the past or be empty.");
                    return;
                }

                var notes = NoteBox.Text;

                using (var db = new AppDbContext())
                {
                    var appointment = new Appointment
                    {
                        ClientId = customerId,
                        DateTime = dateTime,
                        Notes = notes
                    };

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                }

                Frame.GoBack();
            }
            else
            {
                ShowErrorMessage("Please select a date.");
                return;
            }
        }

        private void ShowErrorMessage(string message)
        {
            var dialog = new ContentDialog
            {
                Title = "Error",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot 
            };

            _ = dialog.ShowAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}