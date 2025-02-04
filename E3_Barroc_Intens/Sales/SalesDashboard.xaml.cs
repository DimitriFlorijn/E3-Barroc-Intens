using E3_Barroc_Intens.Sales;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using E3_Barroc_Intens.Data;
using Windows.ApplicationModel.Appointments;

namespace E3_Barroc_Intens
{
    public sealed partial class SalesDashboard : Page
    {
        public ObservableCollection<Data.Appointment> Appointments { get; set; } = new ObservableCollection<Data.Appointment>();
        public ObservableCollection<Data.Customer> Customers { get; set; } = new ObservableCollection<Data.Customer>();

        public SalesDashboard()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var appointments = db.Appointments
                                     .Select(a => new Data.Appointment
                                     {
                                         Id = a.Id,
                                         ClientId = a.ClientId,
                                         Client = a.Client,
                                         DateTime = a.DateTime,
                                         Notes = a.Notes
                                     })
                                     .ToList();

                foreach (var appointment in appointments)
                {
                    Appointments.Add(appointment);
                }

                var clients = db.Customers
                                .Select(c => new Data.Customer
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Location = c.Location,
                                    Email = c.Email,
                                    Number = c.Number,
                                    BkrRegistered = c.BkrRegistered
                                })
                                .ToList();

                foreach (var client in clients)
                {
                    Customers.Add(client);
                }
            }

            AppointmentListView.ItemsSource = Appointments;
            ClientListView.ItemsSource = Customers;
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sales.AddClient));
        }

        private void CreateNewAppointment_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateAppointmentPage));
        }

        private void AppointmentListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Data.Appointment selectedAppointment)
            {
                Frame.Navigate(typeof(EditAppointmentPage), selectedAppointment.Id);
            }
        }

        private void ClientListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Data.Customer selecterClient)
            {
                Frame.Navigate(typeof(ClientDetails), selecterClient.Id);
            }
        }
    }
}
