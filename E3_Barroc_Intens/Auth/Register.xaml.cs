using E3_Barroc_Intens.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            // email validatie met de minimum
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            // Wachtwoordcriteria: minstens 8 tekens, één hoofdletter, één kleine letter, één cijfer.
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var name = UsernameTextBox.Text;
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;
            var passwordCheck = PasswordCheckBox.Password;

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

            if (!IsValidEmail(email))
            {
                MessageTextBlock.Text = "Invalid email format. Please enter a valid email.";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageTextBlock.Text = "Password is required.";
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageTextBlock.Text = "Password must be at least 8 characters, include a number, a lowercase, and an uppercase letter.";
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordCheck))
            {
                MessageTextBlock.Text = "Password confirmation is required.";
                return;
            }

            if (passwordCheck != password)
            {
                MessageTextBlock.Text = "Passwords do not match.";
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
                if (db.Users.Any(u => u.Email == email))
                {
                    MessageTextBlock.Text = "Email is already in use.";
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
