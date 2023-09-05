using Factory.Data;
using Factory.Data.Models;
using System;
using System.Windows;

namespace Factory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public DataLayer GetDb()
        {
            return DataLayer.Sql();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            var user = Validator.Auth(GetDb(), LoginTextBox.Text, PasswordTextBox.Text);
            if (user is not null)
            {
                Window window = null;
                switch (user.Level)
                {
                    case 1:
                        window = new AdminWindows.AdminWindow(user, GetDb());
                        break;
                    case 3:
                        window = new UserWindows.UserWindow(GetDb(), user);
                        break;
                    case 2:
                        window = new ManagerWindows.ManagerWindow(GetDb(), user);
                        break;
                    default:
                        return;
                }
                InvokeWindow(window);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new GuestWindows.GuestWindow(GetDb());
            InvokeWindow(window);
        }

        private void InvokeWindow(Window window)
        {
            window.Closed += Window_Closed;
            Hide();
            window.Show();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            PasswordTextBox.Text = "";
            LoginTextBox.Text = "";
            Show();
        }

        private void Statictic_Click(object sender, RoutedEventArgs e)
        {
            var window = new Statistics();
            InvokeWindow(window);
        }
    }
}
