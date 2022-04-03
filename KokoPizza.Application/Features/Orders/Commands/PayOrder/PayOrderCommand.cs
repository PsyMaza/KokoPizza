using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Commands.PayOrder
{
    /// <summary>
    /// Оплата заказа
    /// </summary>
    /// <remarks>
    /// Обычная заглушка для перехода на следующий этап :)
    /// </remarks>
    public sealed class PayOrderCommand : IRequest
    {
        public long OrderId { get; }

        public PayOrderCommand(long orderId)
        {
            OrderId = orderId;
        }
    }
}
