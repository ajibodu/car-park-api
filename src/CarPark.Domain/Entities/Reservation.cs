using CarPark.Core.Entities.Base;
using CarPark.Core.Enum;

namespace CarPark.Core.Entities;

public class Reservation : BaseAuditEntity
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid? ParkingSpotId { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public ReservationStatus Status { get; set; }
    
}