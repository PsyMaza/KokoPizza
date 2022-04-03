using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Contracts.Persistance;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IReadOnlyList<Order>> GetOrdersByUserId(long userId);
}