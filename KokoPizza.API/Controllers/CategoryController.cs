using KokoPizza.Core.Application.Features.Categories.Commands.CreateCategory;
using KokoPizza.Core.Application.Features.Categories.Commands.DeleteCategory;
using KokoPizza.Core.Application.Features.Categories.Commands.UpdateCategory;
using KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryDetail;
using KokoPizza.Core.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KokoPizza.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CategoryListDto>>> GetAll()
    {
        var data = await _mediator.Send(new GetCategoryListQuery());
        return Ok(data);
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CategoryDetailDto>> GetCategoryById(long id)
    {
        var getCategoryDetailQuery = new GetCategoryDetailQuery(id);
        return Ok(await _mediator.Send(getCategoryDetailQuery));
    }

    [HttpPost(Name = "AddCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(
        [FromBody] CreateCategoryCommand createCategoryCommand)
    {
        await _mediator.Send(createCategoryCommand);
        return NoContent();
    }

    [HttpPut(Name = "UpdateCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        await _mediator.Send(updateCategoryCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCategory")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(long id)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(id);
        await _mediator.Send(deleteCategoryCommand);
        return NoContent();
    }
}