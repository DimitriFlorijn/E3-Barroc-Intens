using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace E3_Barroc_Intens.Finance
{
    public sealed partial class LookInvoice : Page
    {
        public LookInvoice()
        {
            this.InitializeComponent();
        }
        private void FinanceDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FinanceDashboard));
        }
    }
}
