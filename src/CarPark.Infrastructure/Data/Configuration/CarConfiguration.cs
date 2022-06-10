using CarPark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Infrastructure.Data.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(x => x.PlateNo).IsRequired();
        builder.HasIndex(i => i.PlateNo);

        builder.HasOne(p => p.User)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.UserId);
    }
}