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
    /// Logika interakcji dla klasy Employers.xaml
    /// </summary>
    public partial class Employers : Window
    {
        public Employers()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow Back = new MainWindow();
            Back.Show();
        }
    }
}
