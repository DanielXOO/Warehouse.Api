using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Common.Exceptions;
using Warehouse.Domain.Category.Commands;
using Warehouse.Domain.Category.Queries;

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
    public async Task<IActionResult> AddCategory(AddCategoryCommand addCategoryCommand)
    {
        if (addCategoryCommand == null)
        {
            throw new BadRequestException($"{nameof(AddCategoryCommand)} can not be null");
        }

        var category = await _mediator.Send(addCategoryCommand);

        return CreatedAtAction(nameof(GetCategoryById), new { category.Id }, category);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetCategoryById(long id)
    {
        var categoryQuery = new GetCategoryByIdQuery(id);

        var category = await _mediator.Send(categoryQuery);
        
        return Ok(category);
    }
}