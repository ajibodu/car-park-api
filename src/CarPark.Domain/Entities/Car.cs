using CarPark.Core.Entities.Base;

namespace CarPark.Core.Entities;

public class Car : BaseAuditEntity
{
    public Guid Id { get; set; }
    public string PlateNo { get; set; }
    public Guid UserId { get; set; }
    
}