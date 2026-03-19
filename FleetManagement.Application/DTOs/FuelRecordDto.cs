namespace FleetManagement.Application.DTOs.FuelRecords;

public class FuelRecordDto
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }
    public string VehicleLicensePlate { get; set; } = string.Empty; // útil para mostrar en UI

    public decimal Liters { get; set; }
    public decimal Cost { get; set; }
    public int Odometer { get; set; }
    public DateTime Date { get; set; }
}