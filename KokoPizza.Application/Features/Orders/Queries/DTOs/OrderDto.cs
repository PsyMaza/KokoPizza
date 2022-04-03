using KokoPizza.Core.Application.Features.Carts.Queries.GetUserCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Core.Application.Features.Orders.Queries.DTOs
{
    public sealed record OrderDto
    {
        public long Id { get; init; }
        public string StatusName { get; init; }
        public ICollection<GetOrderItemDto> OrderItems { get; init; }
        public string ShipAddress { get; init; }
        public string PhoneNumber { get; init; }
    }

    public sealed record GetOrderItemDto
    {
        public int Id { get; init; }
        public int Quantity { get; init; }
        public decimal ProductPrice { get; init; }
        public ProductDto Product { get; init; }
    }
}
