namespace FleetManagement.Application.DTOs.Maintenance;

public class MaintenanceDto
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }
    public string VehicleLicensePlate { get; set; } = string.Empty; // útil para mostrar en UI

    public string Type { get; set; } = string.Empty; // Preventive / Corrective
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
    public DateTime? NextDueDate { get; set; }
}