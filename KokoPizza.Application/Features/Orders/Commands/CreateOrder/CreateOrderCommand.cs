using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokoPizza.Core.Application.Features.Orders.Commands.CreateOrder
{
    /// <summary>
    /// Создание заказа
    /// </summary>
    public sealed class CreateOrderCommand : IRequest
    {
        public IEnumerable<CreateOrderItemDto> OrderItems { get; }
        public string ShipAddress { get; }
        public string PhoneNumber { get; }
        public long UserId { get; }

        public CreateOrderCommand(long userId, string phoneNumber, string shipAddress, IEnumerable<CreateOrderItemDto> orderItems)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
            ShipAddress = shipAddress;
            OrderItems = orderItems;
        }

        public sealed record CreateOrderItemDto
        {
            public long ProductId { get; init; }
            public int Quantity { get; init; }
            public decimal ProductPrice { get; init; }
        }
    }
}
