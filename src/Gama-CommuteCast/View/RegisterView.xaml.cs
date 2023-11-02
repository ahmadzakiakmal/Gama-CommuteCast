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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
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

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            /* Get Login Information */
            string usernameInput = txtUsername.Text;
            string passwordInput = txtPassword.Password;
            string confirmPasswordInput = txtConfirmPassword.Password;
            string emailInput = txtEmail.Text;

            if (string.IsNullOrEmpty(usernameInput))
            {
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(0, 0, 0, 3);
                MessageBox.Show("Mas mas usernamenya mas");
                return;
            }
            //txtUsername.BorderBrush = (Brush)FindResource("UGM-White");
            //txtUsername.BorderThickness = new Thickness(0, 0, 0, 1);

            if (string.IsNullOrEmpty(emailInput))
            {
                txtEmail.BorderBrush = Brushes.Red;
                txtEmail.BorderThickness = new Thickness(0, 0, 0, 3);
                MessageBox.Show("Mas mas emailnya mas");
                return;
            }   
            txtEmail.BorderBrush = (Brush)FindResource("UGM-White");
            if (string.IsNullOrEmpty(confirmPasswordInput))

            if (string.IsNullOrEmpty(passwordInput))
            {
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(0, 0, 0, 3);
                    MessageBox.Show("Mas mas passwordnya mas");
                return;
            }
            txtPassword.BorderBrush = (Brush)FindResource("UGM-White");
            txtPassword.BorderThickness = new Thickness(0, 0, 0, 1);

            if (string.IsNullOrEmpty(confirmPasswordInput))
            {
                txtConfirmPassword.BorderBrush = Brushes.Red;
                txtConfirmPassword.BorderThickness = new Thickness(0, 0, 0, 3);
                MessageBox.Show("Mas mas confirm passwordnya mas");
                return;
            }
            txtConfirmPassword.BorderBrush = (Brush)FindResource("UGM-White");
            txtConfirmPassword.BorderThickness = new Thickness(0, 0, 0, 1);

            if (passwordInput != confirmPasswordInput)
            {
                txtConfirmPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(0, 0, 0, 3);
                txtConfirmPassword.BorderThickness = new Thickness(0 ,0,0, 3);
                MessageBox.Show("Password does not match! Please try again");
                return;
            }
            txtPassword.BorderThickness = new Thickness(0, 0, 0, 1);
            txtConfirmPassword.BorderThickness = new Thickness(0, 0, 0, 1);

            // Register Logic
            // Connection string to your PostgreSQL database
            string connectionString = "Host=20.231.106.166;Port=5432;Username=postgres;Password=kemong;Database=postgres";

            // SQL query for user registration
            string sqlQuery = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)";

            // Create a new NpgsqlConnection and open it
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Create a new NpgsqlCommand with the SQL query and the connection
                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@username", usernameInput);
                    command.Parameters.AddWithValue("@password", passwordInput);
                    command.Parameters.AddWithValue("@email", emailInput);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful.");
                        /* Navigate to Login Window */
                        LoginView loginView = new LoginView();
                        loginView.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed.");
                    }
                }
            }
        }

        private void TxtUsername_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the current username from the TextBox
            string usernameInput = txtUsername.Text;

            // Perform the unique username check
            bool isUsernameUnique = this.isUsernameUnique(usernameInput);

            // Provide feedback to the user based on the uniqueness check
            if (isUsernameUnique)
            {
                // Username is unique
                // You can update a label or change the TextBox border color to indicate this
                txtUsername.BorderBrush = Brushes.Green;
                txtUsername.BorderThickness = new Thickness(0, 0, 0, 2);
            }
            else
            {
                // Username is not unique
                // You can update a label or change the TextBox border color to indicate this
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        /*Check if Username is Unique everytime user changes the username*/
        private bool isUsernameUnique(string usernameInput)
        {
            /*
            string query = "SELECT * FROM users WHERE username = '" + usernameInput + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();*/
            return true;
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            /*Navigate to Login Window*/
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
