using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Commands.CompleteOrder
{
    /// <summary>
    /// Команда завершения заказа
    /// </summary>
    /// <remarks>
    /// Вызывается после выдачи заказа клиенту
    /// </remarks>
    public sealed class CompleteOrderCommand : IRequest
    {
        public long OrderId { get; }

        public CompleteOrderCommand(long orderId)
        {
            OrderId = orderId;
        }
    }
}
