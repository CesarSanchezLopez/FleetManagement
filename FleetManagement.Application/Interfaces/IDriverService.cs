using FleetManagement.Application.DTOs.Drivers;

namespace FleetManagement.Application.Interfaces;

public interface IDriverService
{
    Task<List<DriverDto>> GetAllAsync();
    Task<DriverDto?> GetByIdAsync(Guid id);
    Task<DriverDto> CreateAsync(DriverDto dto);
    Task UpdateAsync(DriverDto dto);
    Task DeleteAsync(Guid id);
}