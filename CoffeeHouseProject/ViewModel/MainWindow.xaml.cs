using CoffeeHouseProject.Script;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CoffeeHouseProject.ViewModel
{

    

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private UserTable _user;
        public OrderTable order { get; set; }
        public ObservableCollection<OrderLineTable> OrderLines { get; set; }
        public ObservableCollection<CustomOrderLine> CustomOrderLines { get; set; }

        public decimal _totalPrice;
        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }


        public MainWindow(UserTable user)
        {
            InitializeComponent();
            OpenMenu();
            DataContext = this;
            _user = user;
            order = new OrderTable();
            order.Value = 0;
            TotalPrice = 0; 
            OrderLines = new ObservableCollection<OrderLineTable>();
            CustomOrderLines= new ObservableCollection<CustomOrderLine>();
            WindowState= WindowState.Maximized;


        }

        public void OpenCart()
        {
            mainFrame.Navigate(new CartPage(this));
        }

        public void OpenMenu()
        {
            mainFrame.Navigate(new MenuPage(this));
        }
        public void HandleAddToCart(object sender, CustomOrderLine orderLine)
        {
            CustomOrderLines.Add(orderLine);
            CustomOrderLines.Last().DecreaseQuantityRequested += HandleDecreaseQuantity;
            CustomOrderLines.Last().IncreaseQuantityRequested += HandleIncreaseQuantity;
            CustomOrderLines.Last().DeleteOrderLineRequested += HandleDeleteOrderLine;
            TotalPrice += orderLine.TotalPrice;
            order.Value = TotalPrice;   

        }

        public void HandleDeleteOrderLine(object sender, CustomOrderLine orderLine)
        {
            CustomOrderLines.Remove(orderLine);
            TotalPrice -= orderLine.TotalPrice;
            order.Value = TotalPrice;
        }

        public void HandleDecreaseQuantity(object sender, CustomOrderLine orderLine)
        {
            MessageBox.Show("Товар был удален из корзины");
        }

        public void HandleIncreaseQuantity(object sender, CustomOrderLine orderLine)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
