namespace FleetManagement.Application.DTOs.Drivers;

public class DriverDto
{
    public Guid Id { get; set; }

    public Guid? CompanyId { get; set; } // obligatorio
    public string CompanyName { get; set; } = string.Empty; // solo para mostrar en la UI

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime LicenseExpiration { get; set; }
}