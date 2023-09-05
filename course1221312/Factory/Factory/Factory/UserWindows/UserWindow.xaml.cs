using Factory.Data;
using Factory.Data.Models;
using System.Windows;
using System.Windows.Input;

namespace Factory.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow(DataLayer data, User user)
        {
            InitializeComponent();

            Title = user.Login;

            ProductsDataGrid.ItemsSource = data.Products.GetAll();
            MaterialsDataGrid.ItemsSource = data.Materials.GetAll();
            RawDataGrid.ItemsSource = data.Raws.GetAll();
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is not null and Product product)
            {
                new ProductDetailsWindow(product).ShowDialog();
            }
        }
    }
}
