using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrderDetail
{
    public sealed class GetOrderDetailQuery : IRequest<GetOrderDetailQueryResponse>
    {
        public long OrderId { get; }

        public GetOrderDetailQuery(long orderId)
        {
            OrderId = orderId;
        }
    }
}
