using KokoPizza.Core.Application.Features.Orders.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Queries.GetOrderDetail
{
    public sealed class GetOrderDetailQueryResponse
    {
        public OrderDto Order { get; }

        public GetOrderDetailQueryResponse(OrderDto order)
        {
            Order = order;
        }
    }
}
