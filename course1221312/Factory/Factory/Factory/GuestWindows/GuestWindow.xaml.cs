using Factory.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Factory.GuestWindows
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        private readonly IEnumerable<ProductItem> products;

        private class ProductItem
        {
            public string Name { get; set; }
            public string Materials { get; set; }
        }

        public GuestWindow(DataLayer data)
        {
            products = data.Products.GetAll().Select(x => new ProductItem()
            {
                Name = x.Name,
                Materials = string.Join(", ", x.Materials.Select(m => m.Material.Name))
            });
            InitializeComponent();
            RefreshSearch();
        }

        private void RefreshSearch(string name = null)
        {
            if (name != null)
            {
                ProductDataGrid.ItemsSource = products.Where(x => (x.Name == name) || x.Name.ToLower().Contains(name.Trim().ToLower()));
            }
            else
            {
                ProductDataGrid.ItemsSource = products;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshSearch(SearchTextBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshSearch();
        }
    }
}
