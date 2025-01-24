using System;
using E3_Barroc_Intens.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace E3_Barroc_Intens.Sales
{
 
    public sealed partial class AddClient : Page
    {
        public AddClient()
        {
            this.InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {

                
                if (NameTextBox.Text == "" || EmailTextBox.Text == "" || PhoneNumberTextBox.Text == "" || AddressTextBox.Text == "" || NotesTextBox.Text == "")
                {
                    ShowErrorMessage("Please fill in all fields.");
                    return;
                }
                var client = new Customer
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Number = PhoneNumberTextBox.Text,
                    Location = AddressTextBox.Text,
                    Notes = NotesTextBox.Text,
                    BkrRegistered = BKRCheckBox.IsChecked.Value
                };

                db.Customers.Add(client);
                db.SaveChanges();
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
            Frame.Navigate(typeof(SalesDashboard));
        }
    }
}
