namespace SalesOrders.Client;

public class Endpoints
{
    private static string baseAddress = "https://localhost:7080/api";
    public static string GetOrders => $"{baseAddress}/orders";
    public static string NewOrder => $"{baseAddress}/orders";

    public static Uri DeleteOrderUri(Guid id) =>
        new($"{baseAddress}/orders/{id}");

    public static Uri DeleteWindowUri(Guid orderId, Guid windowId) =>
        new($"{baseAddress}/orders/{orderId}/windows/{windowId}");
    
}
