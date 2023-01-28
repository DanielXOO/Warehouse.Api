using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("/api/")]
public class OrdersController : Controller
{
    public OrdersController()
    {
        
    }


    [HttpGet("[controller]/{id:long}")]
    public async Task<IActionResult> GetOrderById(long id)
    {
        return Ok();
    }
}