using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using E3_Barroc_Intens.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewClients : Page
    {
        public ViewClients()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var clients = db.Customers.ToList();

                foreach (var client in clients)
                {
                    var item = new ListViewItem
                    {
                        Content = client.Name,
                        Tag = client.Id
                    };

                    item.Tapped += (sender, e) =>
                    {
                        Frame.Navigate(typeof(ClientDetails), client.Id);
                    };

                    ClientListView.Items.Add(item);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SalesDashboard));
        }

    }
}
