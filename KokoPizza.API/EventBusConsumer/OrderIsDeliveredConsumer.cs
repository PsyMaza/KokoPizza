using EventBus.Messages.Events;
using KokoPizza.Core.Application.Features.Orders.Commands.CompleteOrder;
using MassTransit;
using MediatR;

namespace KokoPizza.API.EventBusConsumer
{
    public class OrderIsDeliveredConsumer : IConsumer<OrderIsDeliveredEvent>
    {
        private readonly IMediator _mediator;

        public OrderIsDeliveredConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<OrderIsDeliveredEvent> context)
        {
            await _mediator.Send(new CompleteOrderCommand(context.Message.OrderId));
        }
    }
}
