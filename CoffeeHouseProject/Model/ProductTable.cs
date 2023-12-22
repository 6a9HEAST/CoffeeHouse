using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;
using CoffeeHouseProject.Script;
using CoffeeHouseProject.ViewModel;

namespace CoffeeHouseProject;

public partial class ProductTable
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int AmountInStorage { get; set; }

    public string? Image { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<OrderLineTable> OrderLineTables { get; set; } = new List<OrderLineTable>();
    [NotMapped]
    public ICommand AddToCartCommand { get; set; }

    public ProductTable()
    {
        AddToCartCommand = new RelayCommand(AddToCart);
    }
    public event EventHandler<CustomOrderLine> AddToCartRequested;
    void AddToCart(object parameter)
    {
       AddToCartRequested?.Invoke(this, new CustomOrderLine { Name = this.Name, Image=this.Image, Quantity=1,Price=this.Price,TotalPrice=this.Price, ProductId = this.ProductId});
    }

    
}


