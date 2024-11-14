using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinanceDashboard : Page
    {
        public FinanceDashboard()
        {
            this.InitializeComponent();
        }
        private void AddInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Finance.AddInvoice));
        }
        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
        private void LookInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Finance.LookInvoice));
        }
    }
}
