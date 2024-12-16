using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using E3_Barroc_Intens.Data;
using System;
using System.Linq;

namespace E3_Barroc_Intens.Sales
{
    public sealed partial class EditAppointmentPage : Page
    {
        private int AppointmentId;

        public EditAppointmentPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is int id)
            {
                AppointmentId = id;
                LoadAppointmentDetails();
            }
        }

        private void LoadAppointmentDetails()
        {
            using (var db = new AppDbContext())
            {
                var appointment = db.Appointments.FirstOrDefault(a => a.Id == AppointmentId);
                if (appointment != null)
                {
                    LoadCustomers();

                    CustomerComboBox.SelectedValue = appointment.ClientId;
                    DatePicker.Date = appointment.DateTime.Date;
                    TimePicker.Time = appointment.DateTime.TimeOfDay;
                    NoteBox.Text = appointment.Notes;
                }
            }
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

        private void UpdateAppointment_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

            if (CustomerComboBox.SelectedValue is int customerId)
            {
                if (DatePicker.Date == null)
                {
                    ShowErrorMessage("Please select a date.");
                    return;
                }

                if (TimePicker.Time == null)
                {
                    ShowErrorMessage("Please select a time.");
                    return;
                }

                var date = DatePicker.Date.DateTime;
                var time = TimePicker.Time;
                var dateTime = date.Add(time);

                if (dateTime <= DateTime.Now)
                {
                    ShowErrorMessage("The date and time cannot be in the past or be empty.");
                    return;
                }

                using (var db = new AppDbContext())
                {
                    var appointment = db.Appointments.FirstOrDefault(a => a.Id == AppointmentId);
                    if (appointment != null)
                    {
                        appointment.ClientId = customerId;
                        appointment.DateTime = dateTime;
                        appointment.Notes = NoteBox.Text;

                        db.SaveChanges();
                    }
                }

                Frame.GoBack();
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

        private void BackButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
