namespace FleetManagement.Application.DTOs.Drivers;

public class CreateDriverDto
{
    public Guid CompanyId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string LicenseNumber { get; set; } = string.Empty;

    public DateTime LicenseExpiration { get; set; }
}