
using System.ComponentModel.DataAnnotations;

namespace CoffeeHouseProject;

public partial class OrderTable
{
    public int OrderId { get; set; }
    [Display(Name = "Время заказа")]
    public DateTime? OrderTime { get; set; }
    [Display(Name = "Цена")]
    public decimal Value { get; set; }
    [Display(Name = "Статус")]
    public string OrderStatus { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<OrderLineTable> OrderLineTables { get; set; } = new List<OrderLineTable>();

    public virtual UserTable User { get; set; } = null!;
}
