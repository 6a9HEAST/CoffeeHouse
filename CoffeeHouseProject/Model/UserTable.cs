using System;
using System.Collections.Generic;

namespace CoffeeHouseProject;

public partial class UserTable
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Usertype { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public virtual ICollection<BookingTable> BookingTables { get; set; } = new List<BookingTable>();

    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();
}
