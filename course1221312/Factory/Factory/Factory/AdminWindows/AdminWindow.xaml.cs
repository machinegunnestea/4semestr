using Factory.Data;
using Factory.Data.Models;
using System.Linq;
using System.Windows;

namespace Factory.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly User user;
        private readonly DataLayer data;

        public AdminWindow(User user, DataLayer data)
        {
            this.data = data;
            this.user = user;
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            var users = data.Users.GetAll();
            AdminDataGrid.ItemsSource = users.Where(x => x.Level == 1);
            ManagerDataGrid.ItemsSource = users.Where(x => x.Level == 2);
            UsersDataGrid.ItemsSource = users.Where(x => x.Level == 3);
        }

        private void AddAdminButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow(1, data);
            if (window.ShowDialog() == true)
            {
                data.Users.Add(window.Result);
                UpdateData();
            }
        }

        private void EditAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете изменить себя");
                }
                else
                {
                    var window = new EditUserWindow(user, data);
                    if (window.ShowDialog() == true)
                    {
                        data.Users.Update(user);
                        UpdateData();
                    }
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }

        private void DeleteAdminButton_Click(object sender, RoutedEventArgs e)
        {

            if (AdminDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете удалить себя");
                }
                else
                {
                    data.Users.Remove(user.Id);
                    UpdateData();
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }

        private void AddManagerButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow(2, data);
            if (window.ShowDialog() == true)
            {
                data.Users.Add(window.Result);
                UpdateData();
            }
        }

        private void EditManagerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ManagerDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете изменить себя");
                }
                else
                {
                    var window = new EditUserWindow(user, data);
                    if (window.ShowDialog() == true)
                    {
                        data.Users.Update(user);
                        UpdateData();
                    }
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }

        private void DeleteManagerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ManagerDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете удалить себя");
                }
                else
                {
                    data.Users.Remove(user.Id);
                    UpdateData();
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow(3, data);
            if (window.ShowDialog() == true)
            {
                data.Users.Add(window.Result);
                UpdateData();
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете изменить себя");
                }
                else
                {
                    var window = new EditUserWindow(user, data);
                    if (window.ShowDialog() == true)
                    {
                        data.Users.Update(user);
                        UpdateData();
                    }
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is not null and User user)
            {
                if (user.Login == this.user.Login)
                {
                    MessageBox.Show("Вы не можете удалить себя");
                }
                else
                {
                    data.Users.Remove(user.Id);
                    UpdateData();
                }

            }
            else
            {
                MessageBox.Show("Сначала сделайте выбор");
            }
        }
    }
}
