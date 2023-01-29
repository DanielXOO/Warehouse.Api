using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Product;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    
    
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductCommand addProductCommand)
    {
        if (addProductCommand == null)
        {
            //TODO: throw exception
            return BadRequest();
        }

        var product = await _mediator.Send(addProductCommand);

        return Ok();
    }
}