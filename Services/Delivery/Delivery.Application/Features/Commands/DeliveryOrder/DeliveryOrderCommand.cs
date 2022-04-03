using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.DeliveryOrder
{
    public sealed class DeliveryOrderCommand : IRequest
    {
        public long OrderId { get; }
        public string PhoneNumber { get; }
        public string ShipAddress { get; }

        public DeliveryOrderCommand(long orderId, string phoneNumber, string shipAddress)
        {
            OrderId = orderId;
            PhoneNumber = phoneNumber;
            ShipAddress = shipAddress;
        }
    }
}
