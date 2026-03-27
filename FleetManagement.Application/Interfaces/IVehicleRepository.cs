using FleetManagement.Domain.Entities;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle);
    Task UpdateAsync(Vehicle vehicle);  // ← este es obligatorio
    Task DeleteAsync(Guid id);
    Task<Vehicle?> GetByIdAsync(Guid id);
    Task<List<Vehicle>> GetAllAsync();
}
