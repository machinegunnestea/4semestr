using Factory.Data.Models;
using System;
using System.Linq;
using System.Windows;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для AddProductionWindow.xaml
    /// </summary>
    public partial class AddProductionWindow : Window
    {
        private readonly Product product;

        public AddProductionWindow(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        private static DateTime? Parse(string str)
        {
            string[] values = str.Split('.');
            if (values.Length != 3)
            {
                return null;
            }
            try
            {
                var ints = values.Select(x => int.Parse(x)).ToArray();
                var date = new DateTime(ints[2], ints[1], ints[0]);
                return date;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var date = Parse(DateTextBox.Text);
            if (date == null)
            {
                MessageBox.Show("Дата была в неверном формате");
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int res))
            {
                MessageBox.Show("Неверный формат количества");
                return;
            }

            ProductProduction plan = new()
            {
                Date = (DateTime)date,
                Count = res
            };

            var validRes = Validator.Valid(plan, product);
            if (validRes is not null)
            {
                MessageBox.Show(validRes);
                return;
            }

            product.Productions.Add(plan);
            DialogResult = true;
        }
    }
}
