using CarPark.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Application.Interface;

public interface ICarParkDbContext
{
    public DbSet<Core.Entities.Car> Cars { get; }
    public DbSet<User> Users { get; }
    public DbSet<Parking> Parkings { get; }
    public DbSet<ParkingSpot> ParkingSpots { get; }
    public DbSet<Reservation> Reservations { get; }
}