using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class InventorySystemDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../../../inventory.sqlite");
    }
}

public class Order
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public string OrderLines { get; set; }
    public string Time { get; set; }
    public string Status { get; set; }
}