using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController : Controller
{
    public OrdersController()
    {
        
    }


    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetOrderById(long id)
    {
        return Ok();
    }
}