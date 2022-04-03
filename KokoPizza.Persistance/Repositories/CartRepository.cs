using KokoPizza.Core.Application.Contracts;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Application.Exceptions;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace KokoPizza.Persistance.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    private readonly ILoggedInUserService _loggedInUserService;

    public CartRepository(KokoPizzaDbContext dbContext, ILoggedInUserService loggedInUserService) : base(dbContext)
    {
        _loggedInUserService = loggedInUserService;
    }

    public async Task<long> AddItem(long productId, int quantity = 1)
    {
        var userId = _loggedInUserService.UserId;

        var cart = await GetCartByUserId(userId);

        var cartItem = await GetCartItem(cart!.Id, productId);

        cartItem.Quantity += quantity;

        cart.Items.Add(cartItem);

        await _dbContext.SaveChangesAsync();

        return cartItem.Id;
    }

    private async Task<CartItem> GetCartItem(long cartId, long productId)
    {
        var cartItem = await _dbContext.CartItems
            .Include(e => e.Product)
            .SingleOrDefaultAsync(item => item.CartId == cartId && item.ProductId == productId) ?? new CartItem
        {
            ProductId = productId,
            Quantity = 0
        };

        return cartItem;
    }

    public async Task<int> AddQuantity(long cartItemId)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(cartItemId);

        if (cartItem is null)
            throw new NotFoundException(nameof(CartItem), cartItemId);

        cartItem.Quantity++;
        await _dbContext.SaveChangesAsync();

        return cartItem.Quantity;
    }

    public async Task<int> RemoveQuantity(long cartItemId)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(cartItemId);

        if (cartItem is null)
            throw new NotFoundException(nameof(CartItem), cartItemId);

        cartItem.Quantity--;

        if (cartItem.Quantity < 1)
            await RemoveItem(cartItemId);

        await _dbContext.SaveChangesAsync();

        return cartItem.Quantity;
    }

    public async Task RemoveItem(long cartItemId)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(cartItemId);

        if (cartItem is null)
            throw new NotFoundException(nameof(CartItem), cartItemId);

        _dbContext.CartItems.Remove(cartItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> SetQuantity(long cartItemId, int quantity)
    {
        var cartItem = await _dbContext.CartItems.FindAsync(cartItemId);

        if (cartItem is null)
            throw new NotFoundException(nameof(CartItem), cartItemId);

        cartItem.Quantity = quantity;
        await _dbContext.SaveChangesAsync();

        return cartItem.Quantity;
    }

    public async Task<Cart?> GetUserCart()
    {
        return await GetCartByUserId(_loggedInUserService.UserId);
    }

    public async Task<Cart?> GetCartByUserId(long userId)
    {
        var cart = await _dbContext.Carts
            .Include(c => c.Items)
            .ThenInclude(e => e.Product)
            .SingleOrDefaultAsync(c => c.UserId.Equals(userId));

        if (cart is null)
        {
            cart = await AddAsync(new Cart
            {
                UserId = userId
            });
        }

        return cart;
    }
}