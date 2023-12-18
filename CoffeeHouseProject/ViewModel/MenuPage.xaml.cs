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

namespace CoffeeHouseProject.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : UserControl
    {

        public ObservableCollection<ProductTable> _products { get; set; }
        
        public MainWindow _mainwindow { get; set; }

        public MenuPage(MainWindow mainwindow)
        {
            InitializeComponent();
            DataContext = this;
            _mainwindow = mainwindow;

            
            var context = new CoffeeHouseContext();
            _products = new ObservableCollection<ProductTable>(context.ProductTables);
            foreach (var product in _products)
            {
                product.AddToCartRequested+=mainwindow.HandleAddToCart;
            }
        }

        private void CartButton_onclick(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenCart();
        }
        
    }
}

