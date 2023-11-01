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

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            /* Get Login Information */
            string usernameInput = txtUsername.Text;
            string passwordInput = txtPassword.Password;
            string confirmPasswordInput = txtConfirmPassword.Password;
            string emailInput = txtEmail.Text;

            if (string.IsNullOrEmpty(usernameInput))
            {
                txtUsername.BorderBrush = Brushes.Red;
                MessageBox.Show("Mas mas usernamenya mas");
                return;
            }
            txtUsername.BorderBrush = (Brush)FindResource("UGM-White");

            if (string.IsNullOrEmpty(emailInput))
            {
                txtEmail.BorderBrush = Brushes.Red;
                MessageBox.Show("Mas mas emailnya mas");
                return;
            }   
            txtEmail.BorderBrush = (Brush)FindResource("UGM-White");

            if (string.IsNullOrEmpty(passwordInput))
            {
                txtPassword.BorderBrush = Brushes.Red;
                MessageBox.Show("Mas mas passwordnya mas");
                return;
            }
            txtPassword.BorderBrush = (Brush)FindResource("UGM-White");

            if (string.IsNullOrEmpty(confirmPasswordInput))
            {
                txtConfirmPassword.BorderBrush = Brushes.Red;
                MessageBox.Show("Mas mas confirm passwordnya mas");
                return;
            }
            txtConfirmPassword.BorderBrush = (Brush)FindResource("UGM-White");

            if (passwordInput != confirmPasswordInput)
            {
                txtConfirmPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderBrush = Brushes.Red;
                MessageBox.Show("Password does not match! Please try again");
                return;
            }

            MessageBox.Show("Registered Successfully!");

            /* Navigate to Login Window */
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
