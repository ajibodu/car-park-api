using CarPark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Infrastructure.Data.Configuration;

public class ParkingConfiguration : IEntityTypeConfiguration<Parking>
{
    public void Configure(EntityTypeBuilder<Parking> builder)
    {
        builder.HasKey(k => k.Id);
        builder.HasIndex(i => i.CarId);
    }
}