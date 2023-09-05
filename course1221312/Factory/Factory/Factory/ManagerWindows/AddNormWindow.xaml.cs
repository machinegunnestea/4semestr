using Factory.Data;
using Factory.Data.Models;
using System.Windows;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для AddNormWindow.xaml
    /// </summary>
    public partial class AddNormWindow : Window
    {
        private readonly DataLayer data;
        public Product Product { get; set; }
        private Raw norm;

        public AddNormWindow(DataLayer data, Product product)
        {
            this.data = data;
            Product = product;
            InitializeComponent();
        }
        private void SearchMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchItemWindow(data.Raws.GetAll());
            if (window.ShowDialog() == true)
            {
                norm = window.Result as Raw;
                MaterialTextBox.Text = norm.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(QuantityTextBox.Text, out double res))
            {
                MessageBox.Show("В строке количество должно быть число");
                return;
            }

            Norm productMaterial = new()
            {
                Raw = norm,
                Quantity = res
            };

            var validRes = Validator.Valid(productMaterial);
            if (validRes is not null)
            {
                MessageBox.Show(validRes);
                return;
            }

            Product.Norms.Add(productMaterial);
            DialogResult = true;
        }
    }
}
