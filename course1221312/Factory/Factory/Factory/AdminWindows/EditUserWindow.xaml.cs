using Factory.Data;
using Factory.Data.Models;
using System.Collections.Generic;
using System.Windows;

namespace Factory.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User Result { get; set; }

        private readonly DataLayer data;

        private readonly Dictionary<string, int> accesses = new()
        {
            ["Администратор"] = 1,
            ["Пользователь"] = 3,
            ["Менеджер"] = 2,
        };

        public EditUserWindow(User user, DataLayer data)
        {
            this.data = data;

            InitializeComponent();

            LevelTextBox.ItemsSource = new List<string>()
            {
                "Администратор",
                "Пользователь",
                "Менеджер"
            };

            LevelTextBox.Text = user.Access;
            LoginTextBox.Text = user.Login;
            PasswordTextBox.Text = user.Password;

            Result = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Password = PasswordTextBox.Text;
            Result.Level = accesses[LevelTextBox.Text];

            var validRes = Validator.Valid(Result, data.Users, true);
            if (validRes != null)
            {
                MessageBox.Show(validRes);
                return;
            }
            DialogResult = true;
        }
    }
}
