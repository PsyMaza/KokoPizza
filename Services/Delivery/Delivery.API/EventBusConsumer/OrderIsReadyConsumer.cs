using Delivery.Application.Features.Commands.DeliveryOrder;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;

namespace Delivery.API.EventBusConsumer
{
    public class OrderIsReadyConsumer : IConsumer<OrderIsReadyEvent>
    {
        private readonly IMediator _mediator;

        public OrderIsReadyConsumer(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Consume(ConsumeContext<OrderIsReadyEvent> context)
        {
            await _mediator.Send(new DeliveryOrderCommand(context.Message.OrderId,
                context.Message.PhoneNumber, context.Message.ShipAddress));
        }
    }

}
