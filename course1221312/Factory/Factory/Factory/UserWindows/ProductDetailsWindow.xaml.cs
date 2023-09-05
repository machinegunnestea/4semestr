using Factory.Data.Models;
using System.Windows;

namespace Factory.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        public ProductDetailsWindow(Product product)
        {
            InitializeComponent();
            Title = product.Name;

            MaterialsDataGrid.ItemsSource = product.Materials;
            NormsDataGrid.ItemsSource = product.Norms;
        }
    }
}
