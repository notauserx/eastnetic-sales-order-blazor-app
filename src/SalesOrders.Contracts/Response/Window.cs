namespace SalesOrders.Contracts.Response;

public class WindowItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    public List<SubElementItem>? SubElements { get; set; }
}
