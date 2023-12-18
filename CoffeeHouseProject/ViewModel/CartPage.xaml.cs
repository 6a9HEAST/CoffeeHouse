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

        }
    }
}
