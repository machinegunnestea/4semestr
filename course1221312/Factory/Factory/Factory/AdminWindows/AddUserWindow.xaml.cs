using Factory.Data;
using Factory.Data.Models;
using System.Windows;

namespace Factory.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public User Result { get; set; }

        private readonly DataLayer data;

        public AddUserWindow(int access, DataLayer data)
        {
            this.data = data;

            InitializeComponent();
            Result = new()
            {
                Level = access
            };
            LevelTextBox.Text = User.Accesses[access];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Login = LoginTextBox.Text;
            Result.Password = PasswordTextBox.Text;

            var validRes = Validator.Valid(Result, data.Users);
            if (validRes != null)
            {
                MessageBox.Show(validRes);
                return;
            }
            DialogResult = true;
        }
    }
}
