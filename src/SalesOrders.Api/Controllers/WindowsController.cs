using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesOrders.Contracts.Response;
using SalesOrders.Data;
using SalesOrders.Data.Entities;

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

    [HttpPost("{windowId}/subelements")]
    public async Task<ActionResult<SubElementItem>> CreateSubElementAsync(SubElementItem item)
    {
        var window = await context.Windows.FirstOrDefaultAsync(i => i.Id == item.WindowId);

        if(window == null)
        {
            return BadRequest();
        }
        var subElement = mapper.Map<SubElement>(item);
        context.SubElements.Add(subElement);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(item), item);
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
