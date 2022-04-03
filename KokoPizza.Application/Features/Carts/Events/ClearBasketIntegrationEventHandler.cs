using KokoPizza.Core.Application.Features.Carts.Commands.CleanCart;
using KokoPizza.Core.Application.Features.Orders.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Carts.Events
{
    internal sealed class ClearBasketIntegrationEventHandler : INotificationHandler<ClearBasketIntegrationEvent>
    {
        private readonly IMediator _mediator;

        public ClearBasketIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(ClearBasketIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CleanCartCommand(notification.UserId));
        }
    }
}
