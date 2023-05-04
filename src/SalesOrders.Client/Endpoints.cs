namespace SalesOrders.Client;

public class Endpoints
{
    private static string baseAddress = "https://localhost:7080/api";
    public static Uri GetOrdersUri => new($"{baseAddress}/orders");
    public static Uri NewOrderUri => new ($"{baseAddress}/orders");
    public static Uri NewWindowUri(Guid orderId) =>
        new($"{baseAddress}/orders/{orderId}/windows");

    public static Uri NewSubElementUri(Guid windowId) =>
        new($"{baseAddress}/windows/{windowId}/subelements");

    public static Uri DeleteOrderUri(Guid id) =>
        new($"{baseAddress}/orders/{id}");

    public static Uri DeleteWindowUri(Guid orderId, Guid windowId) =>
        new($"{baseAddress}/orders/{orderId}/windows/{windowId}");

    public static Uri DeleteSubElementUri(Guid windowId, Guid subElementId) =>
        new($"{baseAddress}/windows/{windowId}/subelements/{subElementId}");
}
