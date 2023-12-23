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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeeHouseProject.ViewModel;

namespace CoffeeHouseProject.View.Account
{
    /// <summary>
    /// Логика взаимодействия для UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : UserControl
    {
        public AccountWindow _parent { get; set; }
        public UserDataPage(AccountWindow parent)
        {
            InitializeComponent();
            DataContext = this;
            _parent = parent;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            TextProcessor textProcessor= new TextProcessor();
            string newname = null;
            string newphonenumber = null;
            //if (NameBox.Text!=_parent._user.Name)  newname= textProcessor.DeleteSpaces(NameBox.Text);
            //if (PhoneNumberBox.Text != _parent._user.Phonenumber) newphonenumber = textProcessor.DeleteSpaces(PhoneNumberBox.Text);
            _parent._controller.UpdateUserData(_parent._user, textProcessor.DeleteSpaces(NameBox.Text), textProcessor.DeleteSpaces(PhoneNumberBox.Text));
            MessageBox.Show("Данные успешно изменены");
        }
    }
}
