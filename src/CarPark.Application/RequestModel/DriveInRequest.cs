namespace CarPark.Application.RequestModel;

public class DriveInRequest
{
    public Guid? UserId { get; set; }
    public Guid CarId { get; set; }
    public Guid ParkingSpotId { get; set; }
    public Guid? ReservationId { get; set; }
}