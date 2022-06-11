using CarPark.Application.Interface;

namespace CarPark.Application.Car;

public class CarService : ICarService
{
    private readonly ICarParkDbContext _carParkDbContext;
    
    public CarService(ICarParkDbContext carParkDbContext)
    {
        _carParkDbContext = carParkDbContext;
    }
}