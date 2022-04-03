using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Events
{
    internal sealed class ClearBasketIntegrationEvent : INotification
    {
        public long UserId { get; }

        public ClearBasketIntegrationEvent(long userId)
        {
            UserId = userId;
        }
    }
}
