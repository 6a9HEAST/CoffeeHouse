using System.Windows;




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
            
            if (_loginController.TryLogin(login_textbox.Text, password_textbox.Password, this)) ;
            else MessageBox.Show("Error");
        }
    }

}
