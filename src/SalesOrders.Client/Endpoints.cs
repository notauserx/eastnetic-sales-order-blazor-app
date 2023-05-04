namespace SalesOrders.Client;

public class Endpoints
{
    private static string baseAddress = "https://localhost:7080/api";
    public static string GetOrders => $"{baseAddress}/orders";
    public static string NewOrder => $"{baseAddress}/orders";

    public static Uri DeleteWindowUri(Guid orderId, Guid windowId) =>
        new Uri($"{baseAddress}/orders/{orderId}/windows/{windowId}");
    
}
