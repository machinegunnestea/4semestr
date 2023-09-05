using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
            CreatingData.MakeEmptyFields();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text=="" ||Convert.ToDouble(textBox2.Text) <= 0 || Convert.ToDouble(textBox3.Text) <= 0 || textBox4.Text == "" || textBox5.Text == "")
                {
                    throw new Exception();
                }
                CreatingData.Country = textBox1.Text.Trim();
                CreatingData.Square = Convert.ToDouble(textBox2.Text.Trim());
                CreatingData.Population = Convert.ToDouble(textBox3.Text.Trim());
                CreatingData.Continent = textBox4.Text.Trim();
                CreatingData.Capital = textBox5.Text.Trim();

                this.DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно.");
                this.DialogResult = false;
            }
        }
    }
}
