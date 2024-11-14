using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace E3_Barroc_Intens
{
    public sealed partial class InkoopDashboard : Page
    {
        private string connectionString = "Server=localhost;Database=e3-barroc-intens-database;Uid=root;Pwd=;";

        public ObservableCollection<Product> Products { get; set; }

        public InkoopDashboard()
        {
            this.InitializeComponent();
            Products = new ObservableCollection<Product>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products.Add(new Product
                        {
                            Name = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            InstallationCost = reader.GetDecimal("InstallationCost"),
                            BrandId = reader.GetInt32("BrandId")
                        });
                    }
                }
            }
            ProductListView.ItemsSource = Products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductNameTextBox.Text;
            if (decimal.TryParse(ProductPriceTextBox.Text, out decimal price) &&
                decimal.TryParse(InstallationCostTextBox.Text, out decimal installationCost))
            {
                int brandId = 1;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO products (name, price, installationCost, brandId) VALUES (@name, @price, @installationCost, @brandId)",
                        connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@installationCost", installationCost);
                    cmd.Parameters.AddWithValue("@brandId", brandId);
                    cmd.ExecuteNonQuery();
                }

                Products.Add(new Product { Name = name, Price = price, InstallationCost = installationCost, BrandId = brandId });
                ClearInputFields();
            }
            else
            {
                ShowErrorDialog("Voer geldige waarden in voor prijs en installatiekosten.");
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                string name = ProductNameTextBox.Text;
                if (decimal.TryParse(ProductPriceTextBox.Text, out decimal price) &&
                    decimal.TryParse(InstallationCostTextBox.Text, out decimal installationCost))
                {
                    int brandId = 1;

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(
                            "UPDATE products SET name=@name, price=@price, installationCost=@installationCost, brandId=@brandId WHERE name=@oldName AND price=@oldPrice AND installationCost=@oldInstallationCost AND brandId=@oldBrandId",
                            connection);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@installationCost", installationCost);
                        cmd.Parameters.AddWithValue("@brandId", brandId);
                        cmd.Parameters.AddWithValue("@oldName", selectedProduct.Name);
                        cmd.Parameters.AddWithValue("@oldPrice", selectedProduct.Price);
                        cmd.Parameters.AddWithValue("@oldInstallationCost", selectedProduct.InstallationCost);
                        cmd.Parameters.AddWithValue("@oldBrandId", selectedProduct.BrandId);
                        cmd.ExecuteNonQuery();
                    }

                    selectedProduct.Name = name;
                    selectedProduct.Price = price;
                    selectedProduct.InstallationCost = installationCost;
                    selectedProduct.BrandId = brandId;
                    RefreshProductList();
                    ClearInputFields();
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM products WHERE name=@name AND price=@price AND installationCost=@installationCost AND brandId=@brandId",
                        connection);
                    cmd.Parameters.AddWithValue("@name", selectedProduct.Name);
                    cmd.Parameters.AddWithValue("@price", selectedProduct.Price);
                    cmd.Parameters.AddWithValue("@installationCost", selectedProduct.InstallationCost);
                    cmd.Parameters.AddWithValue("@brandId", selectedProduct.BrandId);
                    cmd.ExecuteNonQuery();
                }

                Products.Remove(selectedProduct);
            }
        }

        private void ClearInputFields()
        {
            ProductNameTextBox.Text = "";
            ProductPriceTextBox.Text = "";
            InstallationCostTextBox.Text = "";
        }

        private void ShowErrorDialog(string message)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Foutmelding",
                Content = message,
                CloseButtonText = "Ok"
            };
            _ = errorDialog.ShowAsync();
        }

        private void RefreshProductList()
        {
            ProductListView.ItemsSource = null;
            ProductListView.ItemsSource = Products;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal InstallationCost { get; set; }
        public int BrandId { get; set; }
    }
}
