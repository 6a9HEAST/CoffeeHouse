using CoffeeHouseProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CoffeeHouseProject.Script
{
    public interface IMainWindowController: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void HandleAddToCart(object sender, CustomOrderLine orderLine);

    }

    public class MainWindowController : IMainWindowController, INotifyPropertyChanged
    {
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
    }
}
