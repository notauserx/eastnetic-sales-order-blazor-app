using System.ComponentModel.DataAnnotations;

namespace SalesOrders.Contracts.Response;

public class SubElementItem
{
    public Guid Id { get; set; }
    public int Element { get; set; }

    [Required]
    public string Type { get; set; }

    [Range(1, 10000, ErrorMessage = "Width invalid (1-10000).")]
    public int Width { get; set; }
    
    [Range(1, 10000, ErrorMessage = "Width invalid (1-10000).")]
    public int Height { get; set; }

}
