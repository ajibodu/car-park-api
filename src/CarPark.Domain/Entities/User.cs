using CarPark.Core.Entities.Base;

namespace CarPark.Core.Entities;

public class User : BaseAuditEntity
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string UserType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? OtherName { get; set; }
}