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
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (var db = new AppDbContext())
            {
                var roles = db.Roles.ToList();
                RoleComboBox.ItemsSource = roles;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var name = UsernameTextBox.Text;
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageTextBlock.Text = "Username is required.";
                return;
            }

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

            if (RoleComboBox.SelectedItem == null)
            {
                MessageTextBlock.Text = "Select a role.";
                return;
            }

            var hashed = SecureHasher.Hash(password);

            var selectedRole = (Role)RoleComboBox.SelectedItem;

            using (var db = new AppDbContext())
            {
                bool emailExists = db.Users.Any(u => u.Email == email);

                if (emailExists)
                {
                    MessageTextBlock.Text = "Email already in use.";
                    return;
                }

                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = hashed
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

            MessageTextBlock.Text = "Account created successfully!";
        }
    }
}
