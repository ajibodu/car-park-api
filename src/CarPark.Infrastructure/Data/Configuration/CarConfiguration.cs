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

        builder.HasData(new List<Car>
        {
            new()
            {
                Id = new Guid("111111b4-8f3c-4c93-8556-de4d805fe120"),
                PlateNo = "AGG-23-34",
                UserId = new Guid("222222b4-8f3c-4c93-8556-de4d805fe120")
            },
            new()
            {
                Id = new Guid("999999b4-8f3c-4c93-8556-de4d805fe120"),
                PlateNo = "APP-12-28"
            }
        });
    }
}