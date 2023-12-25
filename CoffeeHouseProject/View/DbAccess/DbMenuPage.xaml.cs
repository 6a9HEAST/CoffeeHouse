using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Логика взаимодействия для DbMenuPage.xaml
    /// </summary>
    public partial class DbMenuPage : UserControl
    {
        public DbAccessWindow _parent { get; set; }
        public ObservableCollection<ProductTable> products { get; set; }
        public DbMenuPage(DbAccessWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            FillDataGrid();
            datagrid.CanUserAddRows= false;
            datagrid.AutoGeneratingColumn += datagrid_AutoGeneratingColumn;
        }

        public void FillDataGrid()
        {
            
            products = _parent._controller.GetProductTable();
            datagrid.ItemsSource = products;
        }

        private void datagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string[] list = { "AddToCartCommand","OrderLineTables","ProductId","Description","AmountInStorage" };

            if (list.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow addWindow= new ProductAddWindow(_parent);
            
            addWindow.ShowDialog();
            FillDataGrid();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //((DataTable)datagrid.ItemsSource).AcceptChanges();
            _parent._controller.SaveTableChanges(products);
            MessageBox.Show("Изменения сохранены");
        }
    }
}
