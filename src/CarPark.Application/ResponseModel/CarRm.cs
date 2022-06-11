namespace CarPark.Application.ResponseModel;

public class CarRm
{
    public Guid Id { get; set; }
    public string PlateNo { get; set; }
    public Guid UserId { get; set; }

    public virtual bool IsClaimed => UserId != default;
}