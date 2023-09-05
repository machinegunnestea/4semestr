using Factory.Data;
using Factory.Data.Models;
using System.Windows;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        private readonly Product product;
        private DataLayer data;

        public ProductDetailWindow(DataLayer data, Product product)
        {
            this.data = data;
            this.product = product;

            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            MaterialsDataGrid.ItemsSource = null;
            NormsDataGrid.ItemsSource = null;

            MaterialsDataGrid.ItemsSource = product.Materials;
            NormsDataGrid.ItemsSource = product.Norms;
        }

        private void AddMaterialWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddProductMaterialWindow(product, data);
            if (window.ShowDialog() == true)
            {
                data.Products.Update(product);
                UpdateData();
            }
        }

        private void AddNormButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNormWindow(data, product);
            if (window.ShowDialog() == true)
            {
                data.Products.Update(product);
                UpdateData();
            }
        }
    }
}
