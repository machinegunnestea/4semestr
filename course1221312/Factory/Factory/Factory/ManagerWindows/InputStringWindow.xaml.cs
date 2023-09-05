using System.Windows;

namespace Factory.ManagerWindows
{
    /// <summary>
    /// Логика взаимодействия для InputStringWindow.xaml
    /// </summary>
    public partial class InputStringWindow : Window
    {
        public string Result { get; set; }

        public InputStringWindow(string fieldName)
        {
            InitializeComponent();

            NameLabel.Content = ((string)NameLabel.Content) + fieldName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result = ValueTextBox.Text;
            DialogResult = true;
        }
    }
}
