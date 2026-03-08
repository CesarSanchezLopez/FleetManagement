using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;

namespace FleetManagement.Application.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<List<Driver>> GetAllAsync()
    {
        return await _driverRepository.GetAllAsync();
    }

    public async Task<Driver?> GetByIdAsync(Guid id)
    {
        return await _driverRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Driver driver)
    {
        driver.Id = Guid.NewGuid();
        driver.CreatedAt = DateTime.UtcNow;

        await _driverRepository.AddAsync(driver);
    }

    public async Task UpdateAsync(Driver driver)
    {
        await _driverRepository.UpdateAsync(driver);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _driverRepository.DeleteAsync(id);
    }
}