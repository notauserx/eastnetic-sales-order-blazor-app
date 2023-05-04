using SalesOrders.Core.Enums;

namespace SalesOrders.Contracts.Response;

public class SubElementItem
{
    public Guid Id { get; set; }
    public int Element { get; set; }
    public SubElementType Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

}
