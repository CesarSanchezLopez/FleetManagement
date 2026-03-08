namespace FleetManagement.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public Guid CompanyId { get; protected set; }

    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected AuditableEntity(Guid companyId)
    {
        CompanyId = companyId;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}