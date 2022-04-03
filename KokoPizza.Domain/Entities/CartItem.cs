using KokoPizza.Core.Domain.Common;

namespace KokoPizza.Core.Domain.Entities;

public class CartItem : AuditableEntity, IEntity
{
    public long Id { get; set; }

    public long CartId { get; set; }

    public Cart Cart { get; set; }

    public int Quantity { get; set; }

    public long ProductId { get; set; }

    public virtual Product Product { get; set; }
}