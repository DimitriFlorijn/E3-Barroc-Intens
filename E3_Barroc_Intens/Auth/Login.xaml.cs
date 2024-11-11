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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private bool isLoggedIn = false;
        private int loggedInUserId = -1;

        public Login()
        {
            this.InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (loggedInUserId > -1)
            {
                loggedInUserId = -1;
                LoginButton.Content = "Login";
                EmailTextBox.IsEnabled = true;
                PasswordTextBox.IsEnabled = true;
                return;
            }

            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            using (var connection = new AppDbContext())
            {
                User user = connection.Users
                    .FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    loggedInUserId = user.Id;
                    LoginButton.Content = "Logout";
                    EmailTextBox.IsEnabled = false;
                    PasswordTextBox.IsEnabled = false;
                    password = PasswordTextBox.Text = "";
                    isLoggedIn = true;

                    var roleUser = connection.RoleUsers.FirstOrDefault(ru => ru.UserId == user.Id);

                    if (roleUser != null)
                    {
                        var role = connection.Roles.FirstOrDefault(r => r.Id == roleUser.RoleId);

                        if (role != null)
                        {
                            switch (role.Name)
                            {
                                case "Finance":
                                    this.Frame.Navigate(typeof(FinanceDashboard));
                                    break;

                                case "Sales":
                                    this.Frame.Navigate(typeof(SalesDashboard));
                                    break;

                                case "Inkoop":
                                    this.Frame.Navigate(typeof(InkoopDashboard));
                                    break;

                                case "Maintenance":
                                    this.Frame.Navigate(typeof(MaintenanceDashboard));
                                    break;

                                default:
                                    MessageTextBlock.Text = "Role not assigned.";
                                    break;
                            }
                        }
                    }

                    MainWindow.Instance?.SetLoginButtonText("Uitloggen");
                }
            }
        }
    }
}
