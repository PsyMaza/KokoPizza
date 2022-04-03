using KokoPizza.Core.Domain.Common;

namespace KokoPizza.Core.Domain.Entities;

public class Product : AuditableEntity, IEntity, IDeletable
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureUri { get; set; }

    public long CategoryId { get; set; }

    public virtual Category Category { get; set; }
    
    public bool IsDeleted { get; set; }
}