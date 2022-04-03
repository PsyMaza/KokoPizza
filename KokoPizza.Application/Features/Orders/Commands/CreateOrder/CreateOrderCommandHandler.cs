using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Features.Orders.Events;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : AsyncRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IOrderRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.ShipAddress, request.PhoneNumber, request.UserId, OrderStatus.PendingPayment);
            foreach (var orderItem in request.OrderItems)
            {
                order.AddOrderItem(orderItem.ProductId, orderItem.Quantity, orderItem.ProductPrice);
            }
            await _repository.AddAsync(order);

            await _mediator.Publish(new ClearBasketIntegrationEvent(request.UserId), cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
