using SalesOrders.Core.Enums;

namespace SalesOrders.Contracts.Response;

public class OrderItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string State { get; set; }
    public List<WindowItem>? Windows { get; set; }
}
