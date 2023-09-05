using Factory.Data;
using Factory.Data.Models;
using System.Windows;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductMaterialWindow : Window
    {
        private readonly DataLayer data;
        public Product Product { get; set; }
        private Material material;

        public AddProductMaterialWindow(Product product, DataLayer data)
        {
            this.data = data;
            Product = product;
            InitializeComponent();
        }

        private void SearchMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchItemWindow(data.Materials.GetAll());
            if (window.ShowDialog() == true)
            {
                material = window.Result as Material;
                MaterialTextBox.Text = material.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(QuantityTextBox.Text, out double res))
            {
                MessageBox.Show("В строке количество должно быть число");
                return;
            }

            ProductMaterial productMaterial = new()
            {
                Material = material,
                Quantity = res,
            };

            var validRes = Validator.Valid(productMaterial);
            if (validRes is not null)
            {
                MessageBox.Show(validRes);
                return;
            }

            Product.Materials.Add(productMaterial);
            DialogResult = true;
        }
    }
}
