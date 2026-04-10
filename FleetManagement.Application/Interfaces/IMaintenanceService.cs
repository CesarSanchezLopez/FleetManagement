using FleetManagement.Application.DTOs.Maintenance;

namespace FleetManagement.Application.Interfaces;

public interface IMaintenanceService
{
    Task<IEnumerable<MaintenanceDto>> GetAllAsync();
    Task<MaintenanceDto?> GetByIdAsync(Guid id);
    Task<MaintenanceDto> CreateAsync(MaintenanceDto dto);
    Task UpdateAsync(MaintenanceDto dto);
    Task DeleteAsync(Guid id);
}