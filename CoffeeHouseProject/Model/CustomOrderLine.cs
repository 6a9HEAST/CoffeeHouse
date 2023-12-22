using CoffeeHouseProject.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeHouseProject.ViewModel
{
    public class CustomOrderLine
    {
        public CustomOrderLine()
        {
            DecreaseQuantityCommand = new RelayCommand(DecreaseQuantity);
            IncreaseQuantityCommand = new RelayCommand(IncreaseQuantity);
            DeleteOrderLineCommand = new RelayCommand(DeleteOrderLine);
        }

        public string Name { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int? OrderLineId { get; set; }
        
        public ICommand DecreaseQuantityCommand { get; set; }
        public ICommand IncreaseQuantityCommand { get; set; }
        public ICommand DeleteOrderLineCommand { get; set; }

        public event EventHandler<CustomOrderLine> DecreaseQuantityRequested;
        public event EventHandler<CustomOrderLine> IncreaseQuantityRequested;
        public event EventHandler<CustomOrderLine> DeleteOrderLineRequested;

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
