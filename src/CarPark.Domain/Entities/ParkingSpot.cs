using CarPark.Core.Entities.Base;

namespace CarPark.Core.Entities;

public class ParkingSpot : BaseAuditEntity
{
    public Guid Id { get; set; }
    public string SpotName { get; set; }
    public bool IsBusy { get; set; }
    public Guid? ReservationId { get; set; }
    public bool InProcess { get; set; }
    public DateTimeOffset? InProcessExpireAt { get; set; }

    public bool Available =>  (IsBusy == false && InProcess == false && ReservationId == default);

}