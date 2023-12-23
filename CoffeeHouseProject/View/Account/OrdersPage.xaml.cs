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

namespace CoffeeHouseProject.View.Account
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        AccountWindow _parent;
        private ObservableCollection<OrderTable> orders;
        private ObservableCollection<OrderLineTable> orderLines;
        public OrdersPage(AccountWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            datagrid.IsReadOnly = true;
            orders= _parent._controller.GetOrders(_parent._user.UserId);
            SaveOneOrderButton.IsEnabled = false;
            FillDataGridWithOrders();
        }

        public void FillDataGridWithOrders()
        {

            datagrid.ItemsSource = orders;
            datagrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            }

        public void FillDataGridWithOrderLines(int orderid)
        {
            orderLines = _parent._controller.GetOrderLines(orderid);
            datagrid.ItemsSource = orderLines;
            datagrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            //datagrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new System.Windows.Data.Binding("names") });

        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string[] list = {"UserId","OrderLineTables","User","Order","Product"};
         
            if (list.Contains(e.PropertyName))
            {
                e.Cancel = true; 
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                // Взаимодействие с выбранной строкой, например, отображение данных в других элементах управления
                var selectedOrder = (dynamic)datagrid.SelectedItem;
                FillDataGridWithOrderLines(selectedOrder.OrderId);
                SaveOneOrderButton.IsEnabled = true;

            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SaveOneOrderButton.IsEnabled = false;
            orderLines = null;
            FillDataGridWithOrders();
        }

        private void SaveOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            _parent._controller.ExportOrdersToCsv(orders);
        }

        private void SaveOneOrderButton_Click(object sender, RoutedEventArgs e)
        {
            _parent._controller.ExportLinesToCsv(orderLines);
        }
    }
}
