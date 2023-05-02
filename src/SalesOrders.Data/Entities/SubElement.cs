using SalesOrders.Data.Enums;

namespace SalesOrders.Data.Entities;

public class SubElement
{
    public Guid Id { get; set; }
    public int Element { get; set; }
    public SubElementType Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

}
