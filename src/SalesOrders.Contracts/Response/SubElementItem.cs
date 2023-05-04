using System.ComponentModel.DataAnnotations;

namespace SalesOrders.Contracts.Response;

public class SubElementItem
{
    public static SubElementItem CreateForWindow(Guid windowId) =>
        new()
        {
            Id = Guid.NewGuid(),
            WindowId = windowId,
        };

    public SubElementItem()
    {
        
    }

    public SubElementItem(SubElementItem item)
    {
        Id = item.Id;
        WindowId = item.WindowId;
        Element = item.Element;
        Type = item.Type;
        Width = item.Width;
        Height = item.Height;
    }

    public Guid Id { get; set; }
    public Guid WindowId { get; set; }
    
    [Range(1, 100, ErrorMessage = "Element invalid (1-100).")]
    public int Element { get; set; }

    [Required]
    public string Type { get; set; }

    [Range(1, 10000, ErrorMessage = "Width invalid (1-10000).")]
    public int Width { get; set; }
    
    [Range(1, 10000, ErrorMessage = "Width invalid (1-10000).")]
    public int Height { get; set; }
}
