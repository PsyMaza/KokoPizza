using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Commands.CompleteOrder
{
    public sealed class CompleteOrderCommandHandler : AsyncRequestHandler<CompleteOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public CompleteOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);

            if (order is null)
            {
                throw new NullReferenceException($"{nameof(order)} is null with OrderId: {request.OrderId}");
            }

            order.SetStatus(OrderStatus.Completed);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
