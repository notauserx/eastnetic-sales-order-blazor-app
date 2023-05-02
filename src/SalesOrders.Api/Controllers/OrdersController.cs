using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesOrders.Api.Services;
using SalesOrders.Contracts.Response;

namespace SalesOrders.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMapper mapper;

    public OrdersController(IMapper mapper)
    {
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromServices] IOrderListService orderListService) 
    {
        var orders = await orderListService.GetOrderItemsAsync();

        return Ok(mapper.Map<List<OrderItem>>(orders));
    }
}
