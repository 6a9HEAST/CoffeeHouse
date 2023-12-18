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
using CoffeeHouseProject.ViewModel;

namespace CoffeeHouseProject
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ILoginController _loginController;
        private readonly IRegistrationController _registrationController;
        public LoginWindow(ILoginController logincontroller, IRegistrationController registrationController)
        {
            InitializeComponent();
            _loginController = logincontroller;
            _registrationController = registrationController;
        }


        private void HyperLink_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_registrationController);
            registrationWindow.Show();
        }

        private void Login_button_click(object sender, RoutedEventArgs e)
        {
            UserTable user;
            var login = login_textbox.Text;
            var password = password_textbox.Password;
            if (login != "" && password != "")
            {
                user = _loginController.TryLogin(login, password);
                if (user != null)
                {
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                }
                else MessageBox.Show("Error");
            }
        }
    }

}
