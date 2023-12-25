using System.Windows;
using System.Windows.Media.Imaging;
using CoffeeHouseProject.Script;
using Ninject;


namespace CoffeeHouseProject
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private readonly ILoginController _loginController;
        public LoginWindow(ILoginController logincontroller)
        {
            InitializeComponent();
            _loginController = logincontroller;
            Uri iconUri = new Uri("./Images/zerno.png", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
        }

        private void HyperLink_Click(object sender, RoutedEventArgs e)
        {
            IKernel kernel = new StandardKernel(new DependencyModule());    
            RegistrationWindow registrationWindow = kernel.Get<RegistrationWindow>();
            registrationWindow.Show();
        }

        private void Login_button_click(object sender, RoutedEventArgs e)
        {
            bool remember = RememberMeCheckBox.IsChecked.GetValueOrDefault();
            if (_loginController.TryLogin(login_textbox.Text, password_textbox.Password, this,remember)) ;
            else MessageBox.Show("Error");
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Tuple<string, string> tuple = _loginController.CheckForFile();
            if (tuple != null) _loginController.TryLogin(tuple.Item1, tuple.Item2, this);
        }
    }

}
