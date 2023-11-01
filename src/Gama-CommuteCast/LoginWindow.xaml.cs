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
using Npgsql;
using System.Data;

namespace Gama_CommuteCast
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private NpgsqlConnection conn;
        string connString = "Host=20.231.106.166;Port=5432;Username=postgres;Password=kemong;Database=postgres";
        string query = "";
        NpgsqlCommand cmd;

        public LoginWindow()
        {
            conn = new NpgsqlConnection(connString);
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            // Change window to main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pbPassword.Text;

            try
            {
                conn.Open();
                query = $"select login_user('{username}', '{password}')";
                cmd = new NpgsqlCommand(query, conn);
                if((bool)cmd.ExecuteScalar() == false)
                {
                    throw new Exception("error logging in");
                }
                conn.Close();
                MessageBox.Show($"Login success, welcome {username}");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
