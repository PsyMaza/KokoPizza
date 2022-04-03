using static KokoPizza.Core.Application.Features.Orders.Commands.CreateOrder.CreateOrderCommand;

namespace KokoPizza.API.Models
{
    // NOTE: По-хорошему мы не должны мешать слои использованием дтох из слоя приложения в представлении,
    // но главное, ведь, понимать это, верно? :)
    public sealed record CreateOrderModel
    {
        public IEnumerable<CreateOrderItemDto> OrderItems { get; init; }
        public string ShipAddress { get; init; }
        public string PhoneNumber { get; init; }
        public long UserId { get; init; }
    }
}
