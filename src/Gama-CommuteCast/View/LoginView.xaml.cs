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

namespace Gama_CommuteCast.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private NpgsqlConnection conn;
        string connString = "Host=20.231.106.166;Port=5432;Username=postgres;Password=kemong;Database=postgres";
        string query = "";
        NpgsqlCommand cmd;

        public LoginView()
        {
            conn = new NpgsqlConnection(connString);
            InitializeComponent();
        }

        // Window Drag
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            /*Minimize the window*/
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            /*Close the Application*/
            Application.Current.Shutdown();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            /* Get Login Information */
            string usernameInput = tbUsername.Text;
            string passwordInput = tbPassword.Password;
            if (string.IsNullOrEmpty(usernameInput))
            {
                MessageBox.Show("Mas mas usernamenya mas");
                return;
            }

            if (string.IsNullOrEmpty(passwordInput))
            {
                MessageBox.Show("Mas mas passwordnya mas");
                return;
            }

            /* Check Login Information */
            if (usernameInput == "admin" && passwordInput == "admin")
            {
                /* Navigate to Main Window */
                RealMainWindow window = new RealMainWindow();
                window.Show();
                this.Close();
            }
            else
            { 
                try
                {
                    conn.Open();
                    query = $"select login_user('{usernameInput}', '{passwordInput}')";
                    cmd = new NpgsqlCommand(query, conn);
                    if ((int)cmd.ExecuteScalar() == 500)
                    {
                        throw new Exception("[500] An internal server error occured.");
                    }
                    if((int)cmd.ExecuteScalar() == 401)
                    {
                        throw new Exception("[401] Wrong password.");
                    }
                    if((int)cmd.ExecuteScalar() == 404)
                    {
                        throw new Exception("[404] User doesn't exist.");
                    }
                    conn.Close();
                    MessageBox.Show("Success");
                    /* Navigate to Main Window */
                    RealMainWindow window = new RealMainWindow();
                    window.Show();
                    this.Close();
                } 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
        }

        private void LinkRegister_OnClick(object sender, RoutedEventArgs e)
        {
            /*Show Register View*/
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Close();
        }

        private void LinkReset_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hubungi Zakong - +62420691234");
        }
    }
}
