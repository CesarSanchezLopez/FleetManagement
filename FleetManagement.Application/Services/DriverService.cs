using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Mapster;

namespace FleetManagement.Application.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository _driverRepository;

    public DriverService(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<List<DriverDto>> GetAllAsync()
    {
        var drivers = await _driverRepository.GetAllAsync();
        return drivers.Adapt<List<DriverDto>>();
    }

    public async Task<DriverDto?> GetByIdAsync(Guid id)
    {
        var driver = await _driverRepository.GetByIdAsync(id);
        return driver?.Adapt<DriverDto>();
    }

    public async Task<DriverDto> CreateAsync(DriverDto dto)
    {
        var driver = dto.Adapt<Driver>();

        driver.Id = Guid.NewGuid();
        driver.CreatedAt = DateTime.UtcNow;

        await _driverRepository.AddAsync(driver);

        return driver.Adapt<DriverDto>();
    }

    public async Task UpdateAsync(DriverDto dto)
    {
        if (dto.Id == Guid.Empty)
            throw new ArgumentException("Id es requerido para actualizar");

        var existing = await _driverRepository.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new Exception("Driver no encontrado");

        // actualizar campos
        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.LicenseNumber = dto.LicenseNumber;
        existing.LicenseExpiration = dto.LicenseExpiration;

        if (dto.CompanyId.HasValue)
            existing.CompanyId = dto.CompanyId.Value;

        await _driverRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _driverRepository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Driver no encontrado");

        await _driverRepository.DeleteAsync(id);
    }
}