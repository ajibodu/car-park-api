namespace CarPark.Application.ResponseModel;

public class ApproachingCarResponse
{
    public Guid CarId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ReservationId { get; set; }
    public Guid? ParkingSpotId { get; set; }
}