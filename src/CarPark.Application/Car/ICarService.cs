using CarPark.Application.RequestModel;
using CarPark.Application.ResponseModel;

namespace CarPark.Application.Car;

public interface ICarService
{
    Task<CarRm> GetCarById(Guid carId);
    Task<CarRm> GetCarByPlateNo(string plateNo);
    Task<ApproachingCarResponse> ApproachingCar(ApproachingCarRequest carRequest);
    Task DriveIn(DriveInRequest driveInRequest);
}