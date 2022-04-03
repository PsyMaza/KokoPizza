using KokoPizza.Core.Domain.Common;

namespace KokoPizza.Core.Domain.Entities;

public class Category : AuditableEntity, IEntity
{
    public long Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
}