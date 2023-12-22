using Microsoft.EntityFrameworkCore;

namespace CoffeeHouseProject;

public partial class CoffeeHouseContext : DbContext
{
    public CoffeeHouseContext()
    {
    }

    public CoffeeHouseContext(DbContextOptions<CoffeeHouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingTable> BookingTables { get; set; }

    public virtual DbSet<OrderLineTable> OrderLineTables { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    public virtual DbSet<TablesTable> TablesTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CoffeeHouse;Integrated Security=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingTable>(entity =>
        {
            entity.HasKey(e => e.BookingId);

            entity.ToTable("BookingTable");

            entity.Property(e => e.ReservationTime)
                .HasColumnType("datetime")
                .HasColumnName("reservation_time");

            entity.HasOne(d => d.Table).WithMany(p => p.BookingTables)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingTable_TablesTable");

            entity.HasOne(d => d.User).WithMany(p => p.BookingTables)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingTable_UserTable");
        });

        modelBuilder.Entity<OrderLineTable>(entity =>
        {
            entity.HasKey(e => e.OrderLineId);

            entity.ToTable("OrderLineTable");

            entity.Property(e => e.Amount)
                .HasDefaultValue(1)
                .HasColumnName("amount");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLineTables)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLineTable_OrderTable");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderLineTables)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderLineTable_ProductTable");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrderTable");

            entity.Property(e => e.OrderStatus)
                .HasMaxLength(6)
                .HasColumnName("order_status");
            entity.Property(e => e.OrderTime)
                .HasColumnType("datetime")
                .HasColumnName("order_time");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");

            entity.HasOne(d => d.User).WithMany(p => p.OrderTables)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderTable_UserTable");
        });

        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductTable");

            entity.Property(e => e.AmountInStorage).HasColumnName("amount_in_storage");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<TablesTable>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("TablesTable");

            entity.Property(e => e.Number).HasColumnName("number");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserTable");

            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("phonenumber");
            entity.Property(e => e.Usertype)
                .HasMaxLength(6)
                .HasColumnName("usertype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
