using CoffeeHouseProject.Script;
using System.ComponentModel;
using System.Windows.Input;

namespace CoffeeHouseProject.ViewModel
{
    public class CustomOrderLine:INotifyPropertyChanged
    {
        public CustomOrderLine()
        {
            DecreaseQuantityCommand = new RelayCommand(DecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity);
            DeleteOrderLineCommand = new RelayCommand(DeleteOrderLine);
        }

        public string Name { get; set; }
        public string? Image { get; set; }
        public int _quantity;
        public int Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public decimal Price { get; set; }
        public decimal _totalPrice;
        public decimal TotalPrice {
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
        public int? OrderLineId { get; set; }
        public int ProductId { get; set; }

        public ICommand DecreaseQuantityCommand { get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DeleteOrderLineCommand { get; set; }

        public event EventHandler<CustomOrderLine> DecreaseQuantityRequested;
        public event EventHandler<CustomOrderLine> IncreaseQuantityRequested;
        public event EventHandler<CustomOrderLine> DeleteOrderLineRequested;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void DecreaseQuantity(object parameter)
        {
            DecreaseQuantityRequested?.Invoke(this, this);
        }

        void IncreaseQuantity(object parameter)
        {
            IncreaseQuantityRequested?.Invoke(this, this);
        }

        void DeleteOrderLine(object parameter)
        {
            DeleteOrderLineRequested?.Invoke(this, this);
        }
    }
}
