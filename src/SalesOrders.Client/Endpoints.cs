namespace SalesOrders.Client;

public class Endpoints
{
    private static string baseAddress = "https://localhost:7080";
    public static string GetOrders => $"{baseAddress}/api/orders";
    public static string NewOrder => $"{baseAddress}/api/orders";
}
