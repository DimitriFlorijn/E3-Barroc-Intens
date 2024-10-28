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

namespace E3_Barroc_Intens.Auth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private Role selectedRole;
        public RegisterPage()
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {
                var roles = db.Roles.ToList();
                roleComboBox.ItemsSource = roles;
                roleComboBox.DisplayMemberPath = "Name";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void roleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            comboBoxStackPanel.Visibility = Visibility.Visible;
        }

        private void roleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBoxStackPanel.Visibility = Visibility.Collapsed;
        }

        private void roleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = roleComboBox.SelectedItem as Role;
            selectedRole = selectedItem;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var username  = usernameTextBox.Text;
            var password = passwordPasswordBox.Password;
            var repeatPassword = repeatPasswordPasswordBox.Password;
            using (var db = new AppDbContext())
            {
                if (roleCheckBox.IsChecked == true && password == repeatPassword && selectedRole != null)
                {
                    var user = new User
                    {
                        Name = username,
                        Password = password,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();

                    var roleUser = new RoleUser
                    {
                        UserId = user.Id,
                        RoleId = selectedRole.Id
                    };

                    db.RoleUsers.Add(roleUser);
                    db.SaveChanges();
                }
                else if (roleCheckBox.IsChecked == false && password == repeatPassword)
                {
                    var user = new User
                    {
                        Name = username,
                        Password = password,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
