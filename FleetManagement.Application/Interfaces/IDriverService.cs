using FleetManagement.Domain.Entities;

namespace FleetManagement.Application.Interfaces;

public interface IDriverService
{
    Task<List<Driver>> GetAllAsync();
    Task<Driver?> GetByIdAsync(Guid id);
    Task CreateAsync(Driver driver);
    Task UpdateAsync(Driver driver);
    Task DeleteAsync(Guid id);
}