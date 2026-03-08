namespace FleetManagement.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public string LicensePlate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string VIN { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    public ICollection<FuelRecord> FuelRecords { get; set; } = new List<FuelRecord>();
}