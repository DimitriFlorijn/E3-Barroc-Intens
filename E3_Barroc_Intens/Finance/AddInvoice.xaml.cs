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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            }
            
        }
        //private void SaveButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Create a new order with values from the form
        //        var order = new Invoice
        //        {
        //            Customer = Customer,
        //            DueDate = DateTime.Now,
        //            Contract = Customer,
        //          //product = Product
        //          //beans = beanTextBox.Text,
        //            IsPaid = HasPaidCheckBox.Checked,
        //            TotalAmount = Amount
        //        };

        //        // Add the new order to the database and save changes
        //        _context.Orders.Add(order);
        //        _context.SaveChanges();

        //        // Optional: Inform the user
        //        MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any errors
        //        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        




        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
    }
}
