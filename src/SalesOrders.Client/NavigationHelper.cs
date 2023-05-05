using Microsoft.AspNetCore.Components;

namespace SalesOrders.Client;

public class NavigationHelper
{
    public static void NavigateToGetOrders(NavigationManager navigationManager)
    {
        navigationManager.NavigateTo("/get-orders");
    }
}
