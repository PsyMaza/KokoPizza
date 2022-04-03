using KokoPizza.Core.Application.Features.Products.Commands.CreateProduct;
using KokoPizza.Core.Application.Features.Products.Commands.DeleteProduct;
using KokoPizza.Core.Application.Features.Products.Commands.UpdateProduct;
using KokoPizza.Core.Application.Features.Products.Queries.GetProductDetail;
using KokoPizza.Core.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KokoPizza.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ProductListDto>>> GetAll()
    {
        var data = await _mediator.Send(new GetProductListQuery());
        return Ok(data);
    }

    [HttpGet("category/{categoryId}", Name = "GetProductsByCategoryId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ProductListDto>>> GetByCategoryId(long categoryId)
    {
        var data = await _mediator.Send(new GetProductListByCategoryIdQuery(categoryId));
        return Ok(data);
    }

    [HttpGet("{page}, {size}", Name = "GetAllProductsWithPagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedProductDto>> GetAllWithPagination(int page, int size)
    {
        var data = await _mediator.Send(new GetPagedProductListQuery(page, size));
        return Ok(data);
    }

    [HttpGet("category/{categoryId} {page}, {size}", Name = "GetProductsByCategoryIdWithPagination")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedProductDto>> GetAllWithPagination(long categoryId, int page, int size)
    {
        var data = await _mediator.Send(new GetPagedProductListByCategoryIdQuery(categoryId, page, size));
        return Ok(data);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ProductDetailDto>> GetProductById(long id)
    {
        var getProductDetailQuery = new GetProductDetailQuery() { Id = id };
        return Ok(await _mediator.Send(getProductDetailQuery));
    }

    [HttpPost(Name = "AddProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(
        [FromBody] CreateProductCommand createProductCommand)
    {
        await _mediator.Send(createProductCommand);
        return NoContent();
    }

    [HttpPut(Name = "UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        await _mediator.Send(updateProductCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(long id)
    {
        var deleteProductCommand = new DeleteProductCommand() { Id = id };
        await _mediator.Send(deleteProductCommand);
        return NoContent();
    }
}