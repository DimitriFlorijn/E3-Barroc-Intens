using System;
using E3_Barroc_Intens.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace E3_Barroc_Intens.Sales
{
    public sealed partial class ClientDetails : Page
    {
        private Customer thisCustomer;
        public ClientDetails()
        {
            this.InitializeComponent();
           
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is int clientId)
            {
                using (var db = new AppDbContext())
                {
                    var client = db.Customers.Find(clientId);

                    thisCustomer = client;

                    if (client != null)
                    {
                        NameTextBox.Text = client.Name;
                        EmailTextBox.Text = client.Email;
                        NumberTextBox.Text = client.Number;
                        LocationTextBox.Text = client.Location;
                        NotesTextBox.Text = client.Notes;
                        BkrRegisteredTextBox.IsChecked = client.BkrRegistered;
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext()) 
            {
                var client = db.Customers.Find(thisCustomer.Id);

                if (client != null)
                {
                    client.Name = NameTextBox.Text;
                    client.Email = EmailTextBox.Text;
                    client.Number = NumberTextBox.Text;
                    client.Location = LocationTextBox.Text;
                    client.BkrRegistered = BkrRegisteredTextBox.IsChecked.Value;

                }
                db.Customers.Update(client);
                db.SaveChanges();

                Frame.Navigate(typeof(SalesDashboard));

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewClients));
        }
    }
}
