using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektSzkolnyGR6
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string dbPath;

        public Menu()
        {
            InitializeComponent();

            var dbName = "users.db";
            var userPath = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dbPath = System.IO.Path.Combine(userPath, dbName);

            showUsers();
        }
        private void showUsers()
        {
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            conn.CreateTable<User>();
            var users = conn.Table<User>().ToList();
            conn.Close();

            usersListView.ItemsSource = users;
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            var dbName = "users.db";
            var userPath = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dbPath = System.IO.Path.Combine(userPath, dbName);

            int age = 0;
            int.TryParse(ageTextBox.Text, out age);

            var user = new User()
            {
                Name = nameTextBox.Text,
                Age = age,
                Email = emailTextBox.Text
            };

            SQLiteConnection conn = new SQLiteConnection(dbPath);
            conn.CreateTable<User>();
            conn.Insert(user);
            conn.Close();

            showUsers();
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = usersListView.SelectedItem as User;
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<User>();
                conn.Delete(selectedUser);
            }

            showUsers();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow Back = new MainWindow();
            Back.Show();
        }
    }
}
