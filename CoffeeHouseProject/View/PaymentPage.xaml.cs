using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CoffeeHouseProject.View
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : UserControl
    {
        public MainWindow _mainWindow { get; set; }

       

        public PaymentPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = this;
            
        }

        private void PayButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.TryPay(CardNumber.Text, ExpirationDate.Text, CVV.Text);
            _mainWindow.OpenMenu(true);
        }
    }
}
