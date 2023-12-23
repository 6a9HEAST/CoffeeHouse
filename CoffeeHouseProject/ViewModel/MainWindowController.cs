using CoffeeHouseProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CoffeeHouseProject.Script
{
    public interface IMainWindowController: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void HandleAddToCart(object sender, CustomOrderLine orderLine);
        public void Pay(string CardNumber, string ExpiryDate, string CVV, int userid);
        public void ClearCart();

    }

    public class MainWindowController : IMainWindowController, INotifyPropertyChanged
    {
        private ObservableCollection<CustomOrderLine> customorderlines;
        public ObservableCollection<CustomOrderLine> CustomOrderLines {
            get { return customorderlines; }
            set
            {
                if (customorderlines != value)
                {
                    customorderlines = value;
                    OnPropertyChanged(nameof(CustomOrderLines));
                    OnPropertyChanged(nameof(IsButtonEnabled));
                }
            }
        }
        public bool IsButtonEnabled
        {
            get { return CustomOrderLines?.Count > 0; }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowController()
        {
            CustomOrderLines = new ObservableCollection<CustomOrderLine>();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void HandleAddToCart(object sender, CustomOrderLine orderLine)
        {

            CustomOrderLines.Add(orderLine);
            CustomOrderLines.Last().DecreaseQuantityRequested += HandleDecreaseQuantity;
            CustomOrderLines.Last().IncreaseQuantityRequested += HandleIncreaseQuantity;
            CustomOrderLines.Last().DeleteOrderLineRequested += HandleDeleteOrderLine;
            TotalPrice += orderLine.TotalPrice;
            //order.Value = TotalPrice;

        }

        public void HandleDeleteOrderLine(object sender, CustomOrderLine orderLine)
        {
            CustomOrderLines.Remove(orderLine);
            TotalPrice -= orderLine.TotalPrice;
            //order.Value = TotalPrice;
        }

        public void HandleDecreaseQuantity(object sender, CustomOrderLine orderLine)
        {
            if (orderLine.Quantity==1) CustomOrderLines.Remove(orderLine);
            else orderLine.Quantity--;
            TotalPrice -= orderLine.Price;
            orderLine.TotalPrice -=orderLine.Price;
        }

        public void HandleIncreaseQuantity(object sender, CustomOrderLine orderLine)
        {
            orderLine.Quantity++;
            TotalPrice += orderLine.Price;
            orderLine.TotalPrice += orderLine.Price;
        }

        public void Pay(string CardNumber, string ExpiryDate, string CVV, int userid)
        {
            CreateOrder(userid);
        }

        private void CreateOrder(int userid)
        {
            using (var context = new CoffeeHouseContext())
            {
                var orderlines= new List<OrderLineTable>();
                foreach (var item in CustomOrderLines)
                {
                    orderlines.Add(new OrderLineTable
                    {
                        Amount = item.Quantity,
                        ProductId = item.ProductId
                    });
                }

                var order = new OrderTable 
                    {
                        OrderTime = DateTime.Now,
                        Value = TotalPrice,
                        OrderStatus = "PAYED",
                        UserId = userid,
                        OrderLineTables=orderlines

                    };
                context.OrderTables.Add(order);
                context.SaveChanges();
            }
        }

        public void ClearCart()
        {
            CustomOrderLines.Clear();
            TotalPrice = 0;
        }


    }
}
