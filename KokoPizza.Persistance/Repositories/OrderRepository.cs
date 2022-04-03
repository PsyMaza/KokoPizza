using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokoPizza.Persistance.Repositories
{
    public sealed class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(KokoPizzaDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Order?> GetByIdAsync(long id)
        {
            return await _dbContext.Orders.Include(e => e.Items).ThenInclude(e => e.Product).SingleAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersByUserId(long userId)
        {
            return (await _dbContext.Orders
                .Where(order => order.UserId == userId)
                .Include(order => order.Items)
                .ThenInclude(orderItem => orderItem.Product).ToListAsync()).AsReadOnly();
        }
    }
}
