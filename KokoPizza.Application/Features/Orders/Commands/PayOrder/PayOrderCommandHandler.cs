using EventBus.Messages.Events;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Enums;
using MassTransit;
using MediatR;

namespace KokoPizza.Core.Application.Features.Orders.Commands.PayOrder
{
    public sealed class PayOrderCommandHandler : AsyncRequestHandler<PayOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public PayOrderCommandHandler(IOrderRepository repository, IPublishEndpoint publishEndpoint)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        protected override async Task Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);

            if (order is null)
            {
                throw new NullReferenceException($"{nameof(order)} is null with OrderId: {request.OrderId}");
            }

            order.SetStatus(OrderStatus.Delivering);

            var orderIsReadyEvent = new OrderIsReadyEvent(order.Id, order.PhoneNumber, order.ShipAddress);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            await _publishEndpoint.Publish(orderIsReadyEvent);
        }
    }
}
