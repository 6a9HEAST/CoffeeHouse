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

    public class CustomOrderLine
    {
        public CustomOrderLine()
        {
            DecreaseQuantityCommand=new RelayCommand(DecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity);
            DeleteOrderLine = new RelayCommand(Delete);            
        }

        public string Name { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int? OrderLineId { get; set; }

        public ICommand DecreaseQuantityCommand{ get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DeleteOrderLine { get; set; }

        public event EventHandler<CustomOrderLine> QuantityChanged;

        void DecreaseQuantity(object parameter)
        {
            QuantityChanged?.Invoke(this, this);
        }

        void IncreaseQuantity(object parameter)
        {

        }

        void Delete(object parameter)
        {

        }
    }

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
            TotalPrice+= orderLine.TotalPrice;
            order.Value = TotalPrice;   

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
