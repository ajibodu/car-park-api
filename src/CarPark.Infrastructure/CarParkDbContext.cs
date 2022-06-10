using System.Reflection;
using CarPark.Core.Entities;
using CarPark.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarPark.Infrastructure;

public class CarParkDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    public CarParkDbContext(DbContextOptions<CarParkDbContext> dbContextOptions):base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Use SnakeCase for fields and tables.
        //https://github.com/efcore/EFCore.NamingConventions
        optionsBuilder.UseSnakeCaseNamingConvention()
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));

        base.OnConfiguring(optionsBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var mutatedAuditObjects = this.ChangeTracker.Entries()
            .Where(e => e.Entity is BaseAuditEntity && (e.State == EntityState.Added || e.State == EntityState.Modified))
            .Select(e => (BaseAuditEntity)e.Entity);

        foreach (var auditedObject in mutatedAuditObjects)
        {
            auditedObject.UpdateDateUtc = DateTimeOffset.UtcNow;
            if (auditedObject.CreateDateUtc <= DateTimeOffset.MinValue)
            {
                auditedObject.CreateDateUtc = DateTimeOffset.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}