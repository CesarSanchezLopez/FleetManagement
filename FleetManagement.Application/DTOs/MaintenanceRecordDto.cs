namespace FleetManagement.Application.DTOs.MaintenanceRecords;

public class MaintenanceRecordDto
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }
    public string VehicleLicensePlate { get; set; } = string.Empty; // útil para UI

    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public int Mileage { get; set; }
    public DateTime MaintenanceDate { get; set; }
}