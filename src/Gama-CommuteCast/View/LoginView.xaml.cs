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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
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
            string id = txtUsername.Text;
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Mas mas ID-nya mas");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mas mas passwordnya mas");
                return;
            }

            /* Check Login Information */
            if (id == "admin" && password == "admin")
            {
                /* Navigate to Main Window */
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Apcb");
            }
            MessageBox.Show("Zakong Login");
        }
    }
}
