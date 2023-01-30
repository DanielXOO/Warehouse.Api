using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Domain.Category;
using Warehouse.Domain.Product;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;
    
    
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpPost]
    public async Task<IActionResult> AddProduct(AddCategoryCommand addCategoryCommand)
    {
        if (addCategoryCommand == null)
        {
            //TODO: throw exception
            return BadRequest();
        }

        var category = await _mediator.Send(addCategoryCommand);

        return Ok();
    }
}