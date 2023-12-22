
namespace CoffeeHouseProject;

public partial class OrderTable
{
    public int OrderId { get; set; }

    public DateTime? OrderTime { get; set; }

    public decimal Value { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<OrderLineTable> OrderLineTables { get; set; } = new List<OrderLineTable>();

    public virtual UserTable User { get; set; } = null!;
}
