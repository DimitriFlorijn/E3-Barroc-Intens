using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using E3_Barroc_Intens.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E3_Barroc_Intens
{
    public sealed partial class InkoopDashboard : Page
    {
        private List<Product> products;
        private List<Brand> brands;

        public InkoopDashboard()
        {
            this.InitializeComponent();

            LoadBrands();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var db = new AppDbContext())
            {
                products = db.Products.Include(p => p.Brand).ToList();
            }

            ProductListView.ItemsSource = products;
        }

        private void LoadBrands()
        {
            using (var db = new AppDbContext())
            {
                brands = db.Brands.ToList();
            }

            BrandComboBox.ItemsSource = brands;
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

                var newProduct = new Product
                {
                    Name = name,
                    Price = price,
                    InstallationCost = installationCost,
                    BrandId = brandId,
                    Type = type,
                    Description = description
                };

                using (var db = new AppDbContext())
                {
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                }

                products.Add(newProduct);
                RefreshProductList();
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

                    using (var db = new AppDbContext())
                    {
                        var productToUpdate = db.Products.FirstOrDefault(p => p.Id == selectedProduct.Id);
                        if (productToUpdate != null)
                        {
                            productToUpdate.Name = name;
                            productToUpdate.Price = price;
                            productToUpdate.InstallationCost = installationCost;
                            productToUpdate.BrandId = brandId;
                            productToUpdate.Type = type;
                            productToUpdate.Description = description;

                            db.SaveChanges();
                        }
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
                else
                {
                    ShowErrorDialog("Voer geldige waarden in voor prijs en installatiekosten.");
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                using (var db = new AppDbContext())
                {
                    var productToDelete = db.Products.FirstOrDefault(p => p.Id == selectedProduct.Id);
                    var customerOrders = db.CustomerOrders.Where(co => co.ProductId == selectedProduct.Id).ToList();
                    var storages = db.Storages.Where(s => s.ProductId == selectedProduct.Id).ToList();
                    if (productToDelete != null)
                    {
                        db.Products.Remove(productToDelete);
                        db.CustomerOrders.RemoveRange(customerOrders);
                        db.Storages.RemoveRange(storages);
                        db.SaveChanges();
                    }
                }

                products.Remove(selectedProduct);
                RefreshProductList();
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
            ProductListView.ItemsSource = products;
        }
    }
}
