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
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

namespace E3_Barroc_Intens.Finance
{
    public sealed partial class AddInvoice : Page
    {
        public AddInvoice()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            using (var db = new AppDbContext())
            {
                Contract.ItemsSource = db.Contracts
                    .Include(c => c.Product)
                    .Include(c => c.Bean)
                    .Include(c => c.Customer)
                    .ToList();
            }
        }

        private void Contract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Contract.SelectedItem is Contract selectedContract)
            {
                using (var db = new AppDbContext())
                {
                    var contract = db.Contracts
                        .Include(c => c.Product)
                        .Include(c => c.Bean)
                        .FirstOrDefault(c => c.Id == selectedContract.Id);

                    if (contract != null)
                    {
                        Product.Text = contract.Product?.Name ?? "Geen product";
                        Bean.Text = contract.Bean?.Name ?? "Geen boon";

                        decimal totalAmount = contract.Product?.Price ?? 0;
                        if (contract.Bean != null)
                        {
                            totalAmount += contract.Bean.PricePerKg;
                        }

                        TotalAmount.Text = totalAmount.ToString("C");
                    }
                }
            }
        }

        private void AddInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (Contract.SelectedItem == null)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Fout",
                    Content = "Selecteer een contract voordat je een factuur toevoegt.",
                    CloseButtonText = "OK"
                };
                _ = errorDialog.ShowAsync();
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    var selectedContract = (Contract)Contract.SelectedItem;

                    var invoice = new Invoice
                    {
                        ContractId = selectedContract.Id,
                        DateIssued = DateTime.Now,
                        DueDate = DateTime.Now.AddMonths(1),
                        TotalAmount = decimal.Parse(TotalAmount.Text, System.Globalization.NumberStyles.Currency),
                        IsPaid = false
                    };

                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                }

                Frame.Navigate(typeof(FinanceDashboard));
            }
            catch (Exception ex)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Fout",
                    Content = $"Er is een fout opgetreden: {ex.Message}",
                    CloseButtonText = "OK"
                };
                _ = errorDialog.ShowAsync();
            }
        }

        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
    }
};
