namespace FleetManagement.Domain.Entities;

public class Maintenance
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public string Type { get; set; } = string.Empty; // Preventive / Corrective
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
    public DateTime? NextDueDate { get; set; }
}