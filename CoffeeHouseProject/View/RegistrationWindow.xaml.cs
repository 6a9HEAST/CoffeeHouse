    using CoffeeHouseProject;
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

namespace CoffeeHouseProject
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        IRegistrationController _registrationController; 
        public RegistrationWindow(IRegistrationController registrationController)
        {
            InitializeComponent();
            // _registrationController = registrationController;
            _registrationController = registrationController;
            Uri iconUri = new Uri("./Images/zerno.png", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
        }

        private void register_button_click(object sender, RoutedEventArgs e)
        {
            if (password_textbox.Password == repeat_password_textbox.Password)
            {
               // if (login_textbox.Text!="") MessageBox.Show("<<"+login_textbox.Text+">>");
                string login = login_textbox.Text;
                string password = password_textbox.Password;
                string name = name_textbox.Text;
                if (login != "" && password != "" && name !="")
                {
                    _registrationController.RegisterUser(login, name, password);
                    MessageBox.Show("Регистрация успешна!");
                    this.Close();
                }

            }
        }
    }
}
