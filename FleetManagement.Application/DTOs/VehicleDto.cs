namespace FleetManagement.Application.DTOs.Vehicles;

public class VehicleDto
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; } = string.Empty; // opcional, para mostrar en UI

    public string LicensePlate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string VIN { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}