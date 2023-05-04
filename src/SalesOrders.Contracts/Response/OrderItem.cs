using System.ComponentModel.DataAnnotations;

namespace SalesOrders.Contracts.Response;

public class OrderItem
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(20, ErrorMessage = "Order name cannot be more than 20 characters")]
    public string? Name { get; set; }
    
    [Required]
    public string State { get; set; }
    public List<WindowItem>? Windows { get; set; }
}
