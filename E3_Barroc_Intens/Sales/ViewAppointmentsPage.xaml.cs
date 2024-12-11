using Microsoft.UI.Xaml.Controls;
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
    }

    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }

        public string FormattedDateTime => DateTime.ToString("MMMM dd, yyyy HH:mm");
    }

}
