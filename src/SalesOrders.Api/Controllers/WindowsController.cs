using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrders.Data;

namespace SalesOrders.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WindowsController : ControllerBase
{
    private readonly SalesOrdersDbContext context;
    private readonly IMapper mapper;

    public WindowsController(
        SalesOrdersDbContext context,
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpDelete("{windowId}/subelements/{subelementId}")]
    public async Task<IActionResult> DeleteWindowSubElement(Guid windowId, Guid subelementId)
    {
        var subElement = await context.SubElements
            .FirstOrDefaultAsync(i => i.Id == subelementId && i.WindowId == windowId);

        if (subElement == null)
        {
            return NotFound();
        }

        context.SubElements.Remove(subElement);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
