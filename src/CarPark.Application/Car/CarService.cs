using AutoMapper;
using CarPark.Application.Interface;
using CarPark.Application.RequestModel;
using CarPark.Application.ResponseModel;
using CarPark.Core.Entities;
using CarPark.Core.Enum;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Application.Car;

public class CarService : ICarService
{
    private readonly ICarParkDbContext _carParkDbContext;
    private readonly IMapper _mapper;
    
    public CarService(ICarParkDbContext carParkDbContext, IMapper mapper)
    {
        _carParkDbContext = carParkDbContext;
        _mapper = mapper;
    }

    public async Task<CarRm> GetCarById(Guid carId)
    {
        var car = await _carParkDbContext.Cars.FirstOrDefaultAsync(car => car.Id == carId);
        return _mapper.Map<CarRm>(car);
    }
    
    public async Task<CarRm> GetCarByPlateNo(string plateNo)
    {
        var car = await _carParkDbContext.Cars.FirstOrDefaultAsync(car => car.PlateNo == plateNo);
        return _mapper.Map<CarRm>(car);
    }

    public async Task DriveIn(DriveInRequest driveInRequest)
    {
        var parkingSpot = await _carParkDbContext.ParkingSpots.FindAsync(driveInRequest.ParkingSpotId);
        if (parkingSpot.InProcess)
        {
            parkingSpot.IsBusy = true;
            parkingSpot.InProcess = false;
            parkingSpot.InProcessExpireAt = null;
        }
        
        var parking = new Parking
        {
            CarId = driveInRequest.CarId,
            ParkingSpotId = driveInRequest.ParkingSpotId,
            ReservationId = driveInRequest.ReservationId,
            DriveInAt = DateTimeOffset.Now
        };
        _carParkDbContext.Parkings.Add(parking);

        await _carParkDbContext.SaveChangesAsync();
    }

    public async Task<ApproachingCarResponse> ApproachingCar(ApproachingCarRequest carRequest)
    {
        var car = await GetOrCreateCarIfNotExist(carRequest.PlateNo);
        var response = new ApproachingCarResponse
        {
            CarId = car.Id,
            UserId = car.UserId
        };
            
        var reservation = await GetReservation(car.Id);
        if (reservation != null)
        {
            response.ReservationId = reservation.Id;
            response.ParkingSpotId = reservation.ParkingSpotId;
            return response;
        }
        
        var parkingSpot = await GetNextAvailableParkingSpot();
        if (parkingSpot == null)
            throw new Exception();

        response.ParkingSpotId = parkingSpot.Id;
        return response;
    }

    private async Task<CarRm> GetOrCreateCarIfNotExist(string plateNo)
    {
        var car = await GetCarByPlateNo(plateNo);
        if (car != null) return car;
        _carParkDbContext.Cars.Add(new Core.Entities.Car()
        {
            PlateNo = plateNo
        });
        await _carParkDbContext.SaveChangesAsync();
        car = await GetCarByPlateNo(plateNo);

        return car;
    }

    private async Task<ParkingSpot?> GetNextAvailableParkingSpot()
    {
        var parkingSpot = await _carParkDbContext.ParkingSpots
            .FirstOrDefaultAsync(s => s.Available);
        if (parkingSpot == null) return null;
        parkingSpot.InProcess = true;
        parkingSpot.InProcessExpireAt = DateTimeOffset.Now.AddMinutes(5);
        await _carParkDbContext.SaveChangesAsync();
        return parkingSpot;
    }
    
    private async Task<Reservation?> GetReservation(Guid carId)
    {
        var reservation =
            await _carParkDbContext.Reservations.FirstOrDefaultAsync(r =>
                r.CarId == carId && r.Status == ReservationStatus.Waiting);
        return reservation;
    }
    
}