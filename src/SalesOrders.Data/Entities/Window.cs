namespace SalesOrders.Data.Entities;

public class Window
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int QuantityOfWindows { get;set; }
    public List<SubElement>? SubElements { get; set; }
}
