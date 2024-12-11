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

