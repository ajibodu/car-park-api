using CarPark.Core.Entities.Base;

namespace CarPark.Core.Entities;

public class Parking : BaseAuditEntity
{
    public int Id { get; set; }
    public Guid CarId { get; set; }
    public DateTimeOffset? DriveInAt { get; set; }
    public DateTimeOffset? DriveOutAt { get; set; }
    public Guid ParkingSpotId { get; set; }
    public Guid? ReservationId { get; set; }
}