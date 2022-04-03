using KokoPizza.Core.Application.Features.Carts.Commands.AddCartItem;
using KokoPizza.Core.Application.Features.Carts.Commands.AddCartItemQuantity;
using KokoPizza.Core.Application.Features.Carts.Commands.CreateCart;
using KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItem;
using KokoPizza.Core.Application.Features.Carts.Commands.RemoveCartItemQuantity;
using KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KokoPizza.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetUserCart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserCartDto>> GetUserCart()
    {
        var userCart = await _mediator.Send(new GetUserCartQuery());
        return Ok(userCart);
    }

    [HttpPost(Name = "CreateUserCart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CreateCart(CreateCartCommand createCommand)
    {
        var userCart = await _mediator.Send(createCommand);
        return Ok(userCart);
    }

    [HttpPost("{productId}, {quantity}", Name = "AddCartItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<long>> AddCartItem(long productId, int quantity)
    {
        var cartItemId = await _mediator.Send(new AddCartItemCommand { ProductId = productId, Quantity = quantity });
        return Ok(cartItemId);
    }

    [HttpPut("addQuantity/{cartItemId}", Name = "AddQuantity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> AddQuantity(long cartItemId)
    {
        var quantity = await _mediator.Send(new AddCartItemQuantityCommand { CartItemId = cartItemId });
        return Ok(quantity);
    }

    [HttpPut("removeQuantity/{cartItemId}", Name = "RemoveQuantity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<int>> RemoveQuantity(long cartItemId)
    {
        var quantity = await _mediator.Send(new RemoveCartItemQuantityCommand { CartItemId = cartItemId });
        return Ok(quantity);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> RemoveCartItem(long cartItemId)
    {
        await _mediator.Send(new RemoveCartItemCommand() { CartItemId = cartItemId });
        return NoContent();
    }
}