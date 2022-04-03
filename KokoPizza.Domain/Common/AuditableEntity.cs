using System;

namespace KokoPizza.Core.Domain.Common;

public abstract class AuditableEntity
{
    public long CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public long LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; } 
}