using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesOrders.Contracts.Response;

public class WindowItem
{
    public WindowItem()
    {
        
    }
    private WindowItem(Guid orderiD) 
    {
        Id = Guid.NewGuid();
        OrderId = orderiD;
        SubElements = new();
    }
    public static WindowItem CreateForOrder(Guid orderId) => new (orderId);
    
    public WindowItem(WindowItem item)
    {
        Id = item.Id;
        OrderId = item.OrderId;
        Name = item.Name;
        QuantityOfWindows = item.QuantityOfWindows;
        SubElements = new(item?.SubElements ?? Enumerable.Empty<SubElementItem>());
    }
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Name cannot be more than 20 characters")]
    public string? Name { get; set; }
    public int QuantityOfWindows { get; set; }
    
    [JsonIgnore]
    public int NumberOfSubElements => SubElements?.Count ?? 0;
    public List<SubElementItem>? SubElements { get; set; }
}
