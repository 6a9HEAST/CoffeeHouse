using System.ComponentModel.DataAnnotations;

namespace CoffeeHouseProject;

public partial class OrderLineTable
{
    public int OrderLineId { get; set; }
    [Display(Name = "Количество")]
    public int Amount { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public virtual OrderTable Order { get; set; } = null!;

    public virtual ProductTable Product { get; set; } = null!;
}
