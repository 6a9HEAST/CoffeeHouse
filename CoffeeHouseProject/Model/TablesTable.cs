using System;
using System.Collections.Generic;

namespace CoffeeHouseProject;

public partial class TablesTable
{
    public int TableId { get; set; }

    public int Number { get; set; }

    public virtual ICollection<BookingTable> BookingTables { get; set; } = new List<BookingTable>();
}
