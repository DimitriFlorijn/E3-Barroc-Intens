using E3_Barroc_Intens.Data;
using E3_Barroc_Intens.Finance.Financial_Administration;
using E3_Barroc_Intens.Finance.Head_Finance;
using E3_Barroc_Intens.Maintenance.Head_Maintenance;
using E3_Barroc_Intens.Maintenance.Planner;
using E3_Barroc_Intens.Maintenance.Technical_Service;
using E3_Barroc_Intens.Purchasing.Head_Purchasing;
using E3_Barroc_Intens.Purchasing.Purchaser;
using E3_Barroc_Intens.Purchasing.Warehouse_Staff;
using E3_Barroc_Intens.Sales.Consultant;
using E3_Barroc_Intens.Sales.Head_Sales;
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace E3_Barroc_Intens.Auth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : Page
    { 
        public LogInPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //var username = usernameTextBox.Text;
            //var password = passwordPasswordBox.Password;

            //if (username != null && username != "" && password != null && password != "")
            //{
            //    using (var db = new AppDbContext())
            //    {
            //        var userIsInDb = db.Users.Any(u => u.Name == username && u.Password == password);
            //        if (userIsInDb)
            //        {
            //            var user = db.Users.Where(u => u.Name == username && u.Password == password).Include(u => u.RoleUsers).FirstOrDefault();
            //            if (user != null)
            //            {
            //                var roleIds = user.RoleUsers.Select(user => user.RoleId).ToList();
            //                foreach (var roleId in roleIds)
            //                {
            //                    if (roleId == 2)
            //                    {
            //                        this.Frame.Navigate(typeof(HeadFinancePage));
            //                        break;
            //                    }
            //                    else if (roleId == 3)
            //                    {
            //                        this.Frame.Navigate(typeof(FinancialAdministrationPage));
            //                        break;
            //                    }
            //                    else if (roleId == 4)
            //                    {
            //                        this.Frame.Navigate(typeof(HeadSalesPage));
            //                        break;
            //                    }
            //                    else if (roleId == 5)
            //                    {
            //                        this.Frame.Navigate(typeof(ConsultantPage));
            //                        break;
            //                    }
            //                    else if (roleId == 6)
            //                    {
            //                        this.Frame.Navigate(typeof(HeadPurchasingPage));
            //                        break;
            //                    }
            //                    else if (roleId == 7)
            //                    {
            //                        this.Frame.Navigate(typeof(PurchaserPage));
            //                        break;
            //                    }
            //                    else if (roleId == 8)
            //                    {
            //                        this.Frame.Navigate(typeof(WarehouseStaffPage));
            //                        break;
            //                    }
            //                    else if (roleId == 9)
            //                    {
            //                        this.Frame.Navigate(typeof(HeadMaintenancePage));
            //                        break;
            //                    }
            //                    else if (roleId == 10)
            //                    {
            //                        this.Frame.Navigate(typeof(TechnicalServicePage));
            //                        break;
            //                    }
            //                    else if (roleId == 11)
            //                    {
            //                        this.Frame.Navigate(typeof(PlannerPage));
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
