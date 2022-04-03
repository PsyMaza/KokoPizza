using KokoPizza.Core.Domain.Entities;

namespace KokoPizza.Core.Application.Contracts.Persistance;

public interface ICartRepository : IAsyncRepository<Cart>
{
    Task<Cart?> GetUserCart();
    Task<Cart?> GetCartByUserId(long userId);

    Task<long> AddItem(long productId, int quantity = 1);

    Task RemoveItem(long productId);

    Task<int> AddQuantity(long cartItemId);

    Task<int> RemoveQuantity(long cartItemId);

    Task<int> SetQuantity(long cartItemId, int quantity);
}