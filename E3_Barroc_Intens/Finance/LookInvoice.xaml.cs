using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using E3_Barroc_Intens.Data;

namespace E3_Barroc_Intens.Finance
{
    public sealed partial class LookInvoice : Page
    {
        public LookInvoice()
        {
            InitializeComponent();
            LoadInvoices();
        }
        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
        private void LoadInvoices()
        {
            using (var db = new AppDbContext())
            {
                var invoices = db.Invoices
                    .Include(i => i.Contract)
                    .ThenInclude(c => c.Customer)
                    .ToList();
                
                InvoicesList.ItemsSource = invoices;
            }
        }
    }
}
