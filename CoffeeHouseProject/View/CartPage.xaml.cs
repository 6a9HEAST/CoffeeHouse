using System.Windows;
using System.Windows.Controls;


namespace CoffeeHouseProject.ViewModel
{
    
    public partial class CartPage : UserControl
    {
        public MainWindow _mainwindow { get; set; }
        public CartPage(MainWindow mainwindow)
        {
            InitializeComponent();
            DataContext = this;
            _mainwindow = mainwindow;
            
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            _mainwindow.OpenMenu();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
           _mainwindow.OpenPayment();
        }
    }
}
