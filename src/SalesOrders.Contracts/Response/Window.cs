namespace SalesOrders.Contracts.Response;

public class WindowItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    public int NumberOfSubElements => SubElements?.Count ?? 0;
    public List<SubElementItem>? SubElements { get; set; }
}
