using SalesOrders.Data.Enums;

namespace SalesOrders.Data.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public USState State { get; set; }
    public List<Window>? Windows { get; set; }
}
