using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using E3_Barroc_Intens.Data;
using System.Linq;
using System;

namespace E3_Barroc_Intens.Sales
{
    public sealed partial class ViewAppointmentsPage : Page
    {
        public ObservableCollection<AppointmentViewModel> Appointments { get; set; } = new ObservableCollection<AppointmentViewModel>();

        public ViewAppointmentsPage()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var appointments = db.Appointments
                                     .Select(a => new AppointmentViewModel
                                     {
                                         Id = a.Id,
                                         ClientName = a.Client.Name, // Assuming `Client` navigation property exists
                                         DateTime = a.DateTime
                                     })
                                     .ToList();

                foreach (var appointment in appointments)
                {
                    Appointments.Add(appointment);
                }
            }

            AppointmentListView.ItemsSource = Appointments;
        }

        private void CreateNewAppointment_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateAppointmentPage));
        }

        private void AppointmentListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is AppointmentViewModel selectedAppointment)
            {
                Frame.Navigate(typeof(EditAppointmentPage), selectedAppointment.Id);
            }
        }

        private void BackButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SalesDashboard));

        }
    }

    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }

        public string FormattedDateTime => DateTime.ToString("MMMM dd, yyyy HH:mm");
    }
}
