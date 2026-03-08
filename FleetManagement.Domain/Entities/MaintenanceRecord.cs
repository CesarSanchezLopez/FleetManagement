using FleetManagement.Domain.Common;

namespace FleetManagement.Domain.Entities;

public class MaintenanceRecord : AuditableEntity
{
    public Guid VehicleId { get; private set; }
    public string Description { get; private set; }
    public decimal Cost { get; private set; }
    public int Mileage { get; private set; }
    public DateTime MaintenanceDate { get; private set; }

    private MaintenanceRecord() : base(Guid.Empty) { }

    public MaintenanceRecord(
        Guid companyId,
        Guid vehicleId,
        string description,
        decimal cost,
        int mileage)
        : base(companyId)
    {
        if (cost < 0)
            throw new ArgumentException("Cost cannot be negative");

        VehicleId = vehicleId;
        Description = description;
        Cost = cost;
        Mileage = mileage;
        MaintenanceDate = DateTime.UtcNow;
    }
}