namespace CarPark.Core.Entities.Base;

public class BaseAuditEntity
{
    public DateTimeOffset CreateDateUtc { get; set; }
    public DateTimeOffset? UpdateDateUtc { get; set; }
    public DateTimeOffset? DeleteDateUtc { get; set; }
}