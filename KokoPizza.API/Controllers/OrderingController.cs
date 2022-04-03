using KokoPizza.API.Models;
using KokoPizza.Core.Application.Contracts;
using KokoPizza.Core.Application.Features.Orders.Commands.CompleteOrder;
using KokoPizza.Core.Application.Features.Orders.Commands.CreateOrder;
using KokoPizza.Core.Application.Features.Orders.Commands.DeclineOrder;
using KokoPizza.Core.Application.Features.Orders.Commands.PayOrder;
using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using KokoPizza.Core.Application.Features.Orders.Queries.GetOrderDetail;
using KokoPizza.Core.Application.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KokoPizza.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public sealed class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggedInUserService _loggedInUserService;

        public OrderingController(IMediator mediator, ILoggedInUserService loggedInUserService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _loggedInUserService = loggedInUserService ?? throw new ArgumentNullException(nameof(loggedInUserService));
        }

        #region Queries

        [HttpGet("id/{orderId}", Name = "GetOrderDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<OrderDto>> GetOrderDetail(long orderId)
        {
            var getOrderDetailResponse = await _mediator.Send(new GetOrderDetailQuery(orderId));
            return Ok(getOrderDetailResponse.Order);
        }

        [HttpGet(Name = "GetOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IReadOnlyCollection<OrderDto>>> GetOrders()
        {
            var getOrderDetailResponse = await _mediator.Send(new GetOrdersQuery(_loggedInUserService.UserId));
            return Ok(getOrderDetailResponse.Orders);
        }

        #endregion

        #region Commands

        [HttpPost(Name = "CreateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateOrder(
            [FromBody] CreateOrderModel createOrderModel)
        {
            await _mediator.Send(new CreateOrderCommand(
                _loggedInUserService.UserId,
                createOrderModel.PhoneNumber,
                createOrderModel.ShipAddress,
                createOrderModel.OrderItems
            ));
            return NoContent();
        }

        [HttpPut("payOrder/{orderId}", Name = "PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PayOrder(long orderId)
        {
            await _mediator.Send(new PayOrderCommand(orderId));
            return NoContent();
        }

        [HttpPut("completeOrder/{orderId}", Name = "CompleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CompleteOrder(long orderId)
        {
            await _mediator.Send(new CompleteOrderCommand(orderId));
            return NoContent();
        }

        [HttpPut("declineOrder/{orderId}", Name = "DeclineOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeclineOrder(long orderId)
        {
            await _mediator.Send(new DeclineOrderCommand(orderId));
            return NoContent();
        }

        #endregion
    }
}