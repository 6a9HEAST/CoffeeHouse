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

namespace CoffeeHouseProject.View.DbAccess
{
    /// <summary>
    /// Логика взаимодействия для DbAccessWindow.xaml
    /// </summary>
    public partial class DbAccessWindow : Window
    {
        public IDbAccessController _controller { get; set; }
        public DbAccessWindow(IDbAccessController controller)
        {
            InitializeComponent();
            _controller = controller;

            Uri iconUri = new Uri("./Images/zerno.png", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
        }

        private void Treeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Treeview.SelectedItem is TreeViewItem selectedItem)
            {

                switch (selectedItem.Header.ToString())
                {
                    case "Меню":
                        OpenMenuPage();
                        break;
                    case "Пользователи":
                        OpenUsersPage();
                        break;

                }
            }
        }

        public void OpenMenuPage()
        {
            this.Width = 750;
            DbAccessFrame.Navigate(new DbMenuPage(this));
        }

        public void OpenUsersPage()
        {
            this.Width = 810;
            DbAccessFrame.Navigate(new UsersPage(this));
        }
    }
}
