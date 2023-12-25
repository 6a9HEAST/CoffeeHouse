using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CoffeeHouseProject.View.DbAccess
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : UserControl
    {
        private DbAccessWindow _parent;
        private ObservableCollection<UserTable> users;
        public UsersPage(DbAccessWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            FillDataGrid();
            datagrid.CanUserAddRows = false;
        }

        public void FillDataGrid()
        {

            users = _parent._controller.GetUsersTable();
            datagrid.ItemsSource = users;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _parent._controller.SaveTableChanges(null,users);
            MessageBox.Show("Изменения сохранены");
        }

        private void datagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string[] list = { "BookingTables","OrderTables" };

            if (list.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
        }
    }
}
