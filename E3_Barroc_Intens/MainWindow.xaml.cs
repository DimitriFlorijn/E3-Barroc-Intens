using E3_Barroc_Intens.Auth;
using E3_Barroc_Intens.Data;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            this.InitializeComponent();
            Instance = this;

            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Register));
        }

        public void SetVisibilityLogInSellectorBarItemOnCollapsed()
        {
            loginSelectorBarItem.Visibility = Visibility.Collapsed;
        }

        public void SetVisibilityLogInSellectorBarItemOnVisible()
        {
            loginSelectorBarItem.Visibility = Visibility.Visible;
        }
    }
}
