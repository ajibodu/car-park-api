using CarPark.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasData(new List<User>
        {
            new()
            {
                Id = new Guid("222222b4-8f3c-4c93-8556-de4d805fe120"),
                PhoneNumber = "23480812212121",
                UserType = "",
                FirstName = "John",
                LastName = "Doe",
                OtherName = "oiu"
            }
        });
    }
}
