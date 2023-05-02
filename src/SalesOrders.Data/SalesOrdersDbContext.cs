using Microsoft.EntityFrameworkCore;
using SalesOrders.Data.Entities;

namespace SalesOrders.Data;

public class SalesOrdersDbContext : DbContext
{
    public SalesOrdersDbContext(DbContextOptions<SalesOrdersDbContext> options)
    : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Window> Windows { get; set; }
    public DbSet<SubElement> SubElements { get; set; }
}
