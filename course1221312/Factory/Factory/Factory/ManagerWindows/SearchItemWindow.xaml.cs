using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для SearchItemWindow.xaml
    /// </summary>
    public partial class SearchItemWindow : Window
    {
        public object Result { get; set; }

        public SearchItemWindow(IEnumerable<object> values)
        {
            InitializeComponent();

            ItemsDataGrid.ItemsSource = values;
        }

        private void ItemsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ItemsDataGrid.SelectedItem is not null)
            {
                Result = ItemsDataGrid.SelectedItem;
                DialogResult = true;
            }
        }
    }
}
