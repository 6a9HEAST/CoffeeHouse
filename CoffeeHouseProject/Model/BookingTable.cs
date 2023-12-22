namespace CoffeeHouseProject;

public partial class BookingTable
{
    public int BookingId { get; set; }

    public DateTime ReservationTime { get; set; }

    public int TableId { get; set; }

    public int UserId { get; set; }

    public virtual TablesTable Table { get; set; } = null!;

    public virtual UserTable User { get; set; } = null!;
}
