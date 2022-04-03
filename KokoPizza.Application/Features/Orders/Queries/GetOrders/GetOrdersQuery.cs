using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrders
{
    public sealed class GetOrdersQuery : IRequest<GetOrdersQueryResponse>
    {
        public long UserId { get; }

        public GetOrdersQuery(long userId)
        {
            UserId = userId;
        }
    }
}
