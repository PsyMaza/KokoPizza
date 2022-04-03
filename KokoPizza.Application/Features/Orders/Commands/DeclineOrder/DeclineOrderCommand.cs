using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Commands.DeclineOrder
{
    // TODO: В дальнейшем при отмене заказа необходимо учитывать статусы (на некоторых статусах отмена невозможна)
    // Так же необходимо учесть необходимость возврата средств клиенту, если он оплатил заказ.

    /// <summary>
    /// Отмена заказа
    /// </summary>
    /// <remarks>
    /// Команда может быть вызвана на любом этапе заказа.
    /// </remarks>
    public sealed class DeclineOrderCommand : IRequest
    {
        public long OrderId { get; }

        public DeclineOrderCommand(long orderId)
        {
            OrderId = orderId;
        }
    }
}
