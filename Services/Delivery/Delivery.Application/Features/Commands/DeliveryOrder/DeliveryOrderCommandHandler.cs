using EventBus.Messages.Events;
using MassTransit;
using MediatR;

namespace Delivery.Application.Features.Commands.DeliveryOrder
{
    public sealed class DeliveryOrderCommandHandler : AsyncRequestHandler<DeliveryOrderCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public DeliveryOrderCommandHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        protected override async Task Handle(DeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(3000);
            await _publishEndpoint.Publish(new OrderIsDeliveredEvent(request.OrderId));
        }
    }
}
