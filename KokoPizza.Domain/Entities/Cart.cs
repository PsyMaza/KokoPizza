using KokoPizza.Core.Domain.Common;

namespace KokoPizza.Core.Domain.Entities;

public class Cart : AuditableEntity, IEntity
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public virtual List<CartItem> Items { get; set; }

    public Cart()
    {
        Items = new List<CartItem>();
    }
}