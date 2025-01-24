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
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace E3_Barroc_Intens
{
  
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
                PasswordBox.IsEnabled = true;
                return;
            }

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageTextBlock.Text = "Email is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageTextBlock.Text = "Password is required.";
                return;
            }

            using (var connection = new AppDbContext())
            {
                User user = connection.Users
                    .FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    MessageTextBlock.Text = "No account found with this email.";
                    return;
                }

                if (SecureHasher.Verify(password, user.Password))
                {
                    User.LoggedInUser = user;
                    loggedInUserId = user.Id;
                    LoginButton.Content = "Logout";
                    password = PasswordBox.Password = "";
                    EmailTextBox.IsEnabled = false;
                    PasswordBox.IsEnabled = false;
                    isLoggedIn = true;

                    var roleUser = connection.RoleUsers.FirstOrDefault(ru => ru.UserId == user.Id);

                    if (roleUser != null)
                    {
                        var role = connection.Roles.FirstOrDefault(r => r.Id == roleUser.RoleId);
                        if (User.LoggedInUser != null)
                        {
                            MainWindow.Instance.IsCeo = User.LoggedInUser.RoleUsers.Any(roleUser => roleUser.RoleId == 1);
                        }
                        else
                        {
                            MainWindow.Instance.IsCeo = false;
                        }
                        if (role != null)
                        {
                            switch (role.Name)
                            {
                                case "CEO":
                                    this.Frame.Navigate(typeof(CEODashboard));
                                    break;
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
                else
                {
                    MessageTextBlock.Text = "Incorrect password.";
                    return;
                }
            }
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }
    }
}
