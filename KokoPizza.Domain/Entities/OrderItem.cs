using KokoPizza.Core.Domain.Common;

namespace KokoPizza.Core.Domain.Entities;

public class OrderItem : AuditableEntity, IEntity
{
    public OrderItem(long orderId, long productId, int quantity, decimal productPrice)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        ProductPrice = productPrice;
    }

    public long Id { get; set; }

    public long OrderId { get; set; }

    public virtual Order Order { get; set; }

    public long ProductId { get; set; }

    public virtual Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal ProductPrice { get; set; }
}