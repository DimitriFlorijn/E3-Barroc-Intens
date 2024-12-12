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
                Product.ItemsSource = db.Products.Include(p => p.Brand).ToList();
                Bean.ItemsSource = db.Bean.ToList();
                Customer.ItemsSource = db.Customers.ToList();
                IsPaid.ItemsSource = db.Invoices.ToList();
            }
        }
        private void AddInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                    var invoice = new Invoice
                    {
                        CustomerId = ((Customer)Customer.SelectedItem).Id,
                        ContractId = ((Contract)Product.SelectedItem).Id,
                        DateIssued = DateTime.Now,
                        DueDate = DateTime.Now.AddMonths(1),
                        TotalAmount = decimal.Parse(TotalAmount.Text),
                        IsPaid = false
                    };
                    db.Invoices.Add(invoice);
                    db.SaveChanges();      
            }
            Frame.Navigate(typeof(FinanceDashboard));
        }        
        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
    }
};
