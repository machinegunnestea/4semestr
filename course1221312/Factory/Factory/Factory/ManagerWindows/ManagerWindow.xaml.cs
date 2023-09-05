using Factory.Data;
using Factory.Data.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private readonly DataLayer data;

        public ManagerWindow(DataLayer data, User user)
        {
            this.data = data;
            InitializeComponent();

            Title = user.Login;

            UpdateData();
        }

        private void UpdateData()
        {
            ProductsDataGrid.ItemsSource = data.Products.GetAll();
            MaterialsDataGrid.ItemsSource = data.Materials.GetAll();
            RawDataGrid.ItemsSource = data.Raws.GetAll();

            ProductProductionDataGrid.ItemsSource = data.Products.GetAll();
            ProductPlanDataGrid.ItemsSource = data.Products.GetAll();
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is not null and Product product)
            {
                new ProductDetailWindow(data, product).ShowDialog();
            }
        }

        private void DeleteCatalogRawWindow_Click(object sender, RoutedEventArgs e)
        {
            if (RawDataGrid.SelectedItem is not null and Raw raw)
            {
                data.Raws.Remove(raw.Id);
                UpdateData();
            }
        }

        private void AddCatalogRawWindow_Click(object sender, RoutedEventArgs e)
        {
            var name = new InputStringWindow("Наименование");
            if (name.ShowDialog() == true)
            {
                Raw raw = new()
                {
                    Name = name.Result
                };

                var validRes = Validator.Valid(raw);
                if (validRes != null)
                {
                    MessageBox.Show(validRes);
                    return;
                }

                data.Raws.Add(raw);
                UpdateData();
            }
        }

        private void AddCatalogMaterialWindow_Click(object sender, RoutedEventArgs e)
        {
            var name = new InputStringWindow("Наименование");
            if (name.ShowDialog() == true)
            {
                Material raw = new()
                {
                    Name = name.Result
                };

                var validRes = Validator.Valid(raw);
                if (validRes != null)
                {
                    MessageBox.Show(validRes);
                    return;
                }

                data.Materials.Add(raw);
                UpdateData();
            }
        }

        private void DeleteCatalogMaterialWindow_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsDataGrid.SelectedItem is not null and Material raw)
            {
                data.Materials.Remove(raw.Id);
                UpdateData();
            }
        }

        private void AddCatalogProductWindow_Click(object sender, RoutedEventArgs e)
        {
            var name = new InputStringWindow("Наименование");
            if (name.ShowDialog() == true)
            {
                Product raw = new()
                {
                    Name = name.Result
                };

                var validRes = Validator.Valid(raw);
                if (validRes != null)
                {
                    MessageBox.Show(validRes);
                    return;
                }

                data.Products.Add(raw);
                UpdateData();
            }
        }

        private void DeleteCatalogProductWindow_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is not null and Product raw)
            {
                data.Products.Remove(raw.Id);
                UpdateData();
            }
        }

        private void ProductPlanDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductPlanDataGrid.SelectedItem is not null and Product product)
            {
                PlansDataGrid.ItemsSource = product.Plans;
            }
            else
            {
                PlansDataGrid.ItemsSource = null;
            }
        }

        private void AddPlanProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductPlanDataGrid.SelectedItem is not null and Product product)
            {
                var window = new AddPlanWindow(product);
                if (window.ShowDialog() == true)
                {
                    data.Products.Update(product);
                    PlansDataGrid.ItemsSource = null;
                    PlansDataGrid.ItemsSource = product.Plans;
                }
            }
        }

        private void ProductProductionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductProductionDataGrid.SelectedItem is not null and Product product)
            {
                ProductionDataGrid.ItemsSource = product.Plans;
            }
            else
            {
                ProductionDataGrid.ItemsSource = null;
            }
        }

        private void AddProductionProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductProductionDataGrid.SelectedItem is not null and Product product)
            {
                var window = new AddPlanWindow(product);
                if (window.ShowDialog() == true)
                {
                    data.Products.Update(product);
                    ProductionDataGrid.ItemsSource = null;
                    ProductionDataGrid.ItemsSource = product.Plans;
                }
            }
        }
    }
}
