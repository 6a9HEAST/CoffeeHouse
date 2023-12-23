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

namespace CoffeeHouseProject.View.Account
{
    /// <summary>
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public IAccountController _controller { get; set; }
        public UserTable _user { get; set; }
        public AccountWindow(IAccountController controller,UserTable user)
        {
            InitializeComponent();
            _controller = controller;
            _user = user;
            //OpenOrdersPage();
        }

        public void OpenOrdersPage()
        {
            AccountPageFrame.Navigate(new OrdersPage(this));
        }

        public void OpenUserDataPage()
        {
            AccountPageFrame.Navigate(new UserDataPage(this));
        }

        private void Treeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            if (Treeview.SelectedItem is TreeViewItem selectedItem)
            {
                
                switch (selectedItem.Header.ToString())
                {
                    case "Информация о заказах":
                        OpenOrdersPage();
                        break;
                    case "Данные аккаунта":
                        OpenUserDataPage();
                        break;
                }
            }
        }
    }
}
