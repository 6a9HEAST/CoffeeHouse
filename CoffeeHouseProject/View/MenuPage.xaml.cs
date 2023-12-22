using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CoffeeHouseProject.ViewModel
{

    public partial class MenuPage : UserControl
    {

        public ObservableCollection<ProductTable> _products { get; set; }
        
        public MainWindow _mainwindow { get; set; }

        public MenuPage(MainWindow mainwindow)
        {
            InitializeComponent();
            _mainwindow = mainwindow;
            DataContext = this;
            

            
            var context = new CoffeeHouseContext();
            _products = new ObservableCollection<ProductTable>(context.ProductTables);


            foreach (var product in _products)
            {
                product.AddToCartRequested+=mainwindow._controller.HandleAddToCart;
            }
        }

        private void CartButton_onclick(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenCart();
        }
        
    }
}

