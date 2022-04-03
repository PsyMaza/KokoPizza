using KokoPizza.Core.Application.Contracts;
using KokoPizza.Core.Application.Contracts.Persistance;
using KokoPizza.Core.Domain.Common;
using KokoPizza.Core.Domain.Entities;
using KokoPizza.Infrastructure.Persistance.Extensions;
using KokoPizza.Persistance.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace KokoPizza.Persistance.Context
{
    public class KokoPizzaDbContext : DbContext, IUnitOfWork, ITransactionFunctionality
    {
        private readonly ILoggedInUserService _loggedInUserService = null!;
        private IDbContextTransaction _currentTransaction;

        public KokoPizzaDbContext(DbContextOptions<KokoPizzaDbContext> options) : base(options)
        {
        }

        public KokoPizzaDbContext(DbContextOptions<KokoPizzaDbContext> options,
            ILoggedInUserService loggedInUserService) :
            base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ��������� �������� �� ��
            //modelBuilder.UseSerialColumns();

            modelBuilder.UseHiLo();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KokoPizzaDbContext).Assembly);
            
            modelBuilder.AddCartConfiguration();
            
            modelBuilder.ApplyGlobalFilters<IDeletable>(entity => !entity.IsDeleted);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries<AuditableEntity>().ToList().ForEach(LoggedEntityModified);

            // �������� �������� �������

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void LoggedEntityModified(EntityEntry<AuditableEntity> entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
    }
}