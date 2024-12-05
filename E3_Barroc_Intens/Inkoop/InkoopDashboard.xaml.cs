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
        public ObservableCollection<Brand> Brands { get; set; }


        public InkoopDashboard()
        {
            this.InitializeComponent();
            Products = new ObservableCollection<Product>();
            Brands = new ObservableCollection<Brand>(); 
            LoadBrands();
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
                            BrandId = reader.GetInt32("BrandId"),
                            Type = reader.GetString("Type"),
                            Description = reader.GetString("Description")
                        });
                    }
                }
            }
            ProductListView.ItemsSource = Products;
        }

        private void LoadBrands()
        {
            Brands.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM brands", connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brands.Add(new Brand
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name")
                        });
                    }
                }
            }

            BrandComboBox.ItemsSource = Brands;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductNameTextBox.Text;
            string type = ProductTypeTextBox.Text;
            string description = ProductDescriptionTextBox.Text;

            if (decimal.TryParse(ProductPriceTextBox.Text, out decimal price) &&
                decimal.TryParse(InstallationCostTextBox.Text, out decimal installationCost))
            {
                int brandId = (BrandComboBox.SelectedItem as Brand)?.Id ?? 0;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO products (name, price, installationCost, brandId, type, description) VALUES (@name, @price, @installationCost, @brandId, @type, @description)",
                        connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@installationCost", installationCost);
                    cmd.Parameters.AddWithValue("@brandId", brandId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.ExecuteNonQuery();
                }

                Products.Add(new Product
                {
                    Name = name,
                    Price = price,
                    InstallationCost = installationCost,
                    BrandId = brandId,
                    Type = type,
                    Description = description
                });

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
                string type = ProductTypeTextBox.Text;
                string description = ProductDescriptionTextBox.Text;

                if (decimal.TryParse(ProductPriceTextBox.Text, out decimal price) &&
                    decimal.TryParse(InstallationCostTextBox.Text, out decimal installationCost))
                {
                    int brandId = (BrandComboBox.SelectedItem as Brand)?.Id ?? 0;


                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(
                            "UPDATE products SET name=@name, price=@price, installationCost=@installationCost, brandId=@brandId, type=@type, description=@description WHERE name=@oldName AND price=@oldPrice AND installationCost=@oldInstallationCost AND brandId=@oldBrandId",
                            connection);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@installationCost", installationCost);
                        cmd.Parameters.AddWithValue("@brandId", brandId);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@description", description);
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
                    selectedProduct.Type = type;
                    selectedProduct.Description = description;

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

                    // Verwijder afhankelijke rijen in CustomerOrders
                    MySqlCommand deleteOrdersCmd = new MySqlCommand(
                        "DELETE FROM customerorders WHERE ProductId=@productId",
                        connection);
                    deleteOrdersCmd.Parameters.AddWithValue("@productId", selectedProduct.BrandId); // Zorg dat je de juiste kolom verwijst
                    deleteOrdersCmd.ExecuteNonQuery();

                    // Verwijder het product
                    MySqlCommand deleteProductCmd = new MySqlCommand(
                        "DELETE FROM products WHERE name=@name AND price=@price AND installationCost=@installationCost AND brandId=@brandId",
                        connection);
                    deleteProductCmd.Parameters.AddWithValue("@name", selectedProduct.Name);
                    deleteProductCmd.Parameters.AddWithValue("@price", selectedProduct.Price);
                    deleteProductCmd.Parameters.AddWithValue("@installationCost", selectedProduct.InstallationCost);
                    deleteProductCmd.Parameters.AddWithValue("@brandId", selectedProduct.BrandId);
                    deleteProductCmd.ExecuteNonQuery();
                }

                Products.Remove(selectedProduct);
            }
        }


        private void DeselectProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductListView.SelectedItem = null;
            ClearInputFields();
        }

        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                ProductNameTextBox.Text = selectedProduct.Name;
                ProductPriceTextBox.Text = selectedProduct.Price.ToString();
                InstallationCostTextBox.Text = selectedProduct.InstallationCost.ToString();
                ProductTypeTextBox.Text = selectedProduct.Type;
                ProductDescriptionTextBox.Text = selectedProduct.Description;
            }
        }

        private void ClearInputFields()
        {
            ProductNameTextBox.Text = "";
            ProductPriceTextBox.Text = "";
            InstallationCostTextBox.Text = "";
            ProductTypeTextBox.Text = "";
            ProductDescriptionTextBox.Text = "";
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
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
