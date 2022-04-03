using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrders
{
    public sealed class GetOrdersQueryResponse
    {
        public IReadOnlyCollection<OrderDto> Orders { get; }

        public GetOrdersQueryResponse(IReadOnlyCollection<OrderDto> orders)
        {
            Orders = orders;
        }
    }
}
