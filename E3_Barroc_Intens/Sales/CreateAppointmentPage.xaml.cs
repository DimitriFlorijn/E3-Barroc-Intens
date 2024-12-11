using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using E3_Barroc_Intens.Data;
using System;
using System.Linq;

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

        private void SaveAppointment_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue is int customerId)
            {
                var date = DatePicker.Date.DateTime;
                var time = TimePicker.Time;
                var dateTime = date.Add(time);

                using (var db = new AppDbContext())
                {
                    var appointment = new Appointment
                    {
                        ClientId = customerId,
                        DateTime = dateTime
                    };

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                }

                Frame.GoBack();
            }
            else
            {
                // Handle case where no customer is selected
            }
        }
    }
}
