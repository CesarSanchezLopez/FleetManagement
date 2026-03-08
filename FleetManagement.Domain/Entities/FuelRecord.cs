namespace FleetManagement.Domain.Entities;

public class FuelRecord
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public decimal Liters { get; set; }
    public decimal Cost { get; set; }
    public int Odometer { get; set; }
    public DateTime Date { get; set; }
}