using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Mapster;

namespace FleetManagement.Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<List<VehicleDto>> GetAllAsync()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();
        // Mapear con Mapster y asignar CompanyName
        return vehicles.Select(v => new VehicleDto
        {
            Id = v.Id,
            LicensePlate = v.LicensePlate,
            Brand = v.Brand,
            Model = v.Model,
            Year = v.Year,
            VIN = v.VIN,
            CompanyId = v.CompanyId,
            CompanyName = v.Company?.Name ?? string.Empty,
            CreatedAt = v.CreatedAt
        }).ToList();
    }

    public async Task<VehicleDto?> GetByIdAsync(Guid id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle == null) return null;

        return new VehicleDto
        {
            Id = vehicle.Id,
            LicensePlate = vehicle.LicensePlate,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            Year = vehicle.Year,
            VIN = vehicle.VIN,
            CompanyId = vehicle.CompanyId,
            CompanyName = vehicle.Company?.Name ?? string.Empty,
            CreatedAt = vehicle.CreatedAt
        };
    }

    public async Task<VehicleDto> CreateAsync(VehicleDto dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));

        var vehicle = dto.Adapt<Vehicle>();
        vehicle.Id = Guid.NewGuid();
        vehicle.CreatedAt = DateTime.UtcNow;

        await _vehicleRepository.AddAsync(vehicle);

        return vehicle.Adapt<VehicleDto>();
    }

    public async Task UpdateAsync(VehicleDto dto)
    {
        if (dto.Id == null || dto.Id == Guid.Empty)
            throw new ArgumentException("Id es requerido para actualizar");

        var existing = await _vehicleRepository.GetByIdAsync(dto.Id.Value);
        if (existing == null)
            throw new KeyNotFoundException("Vehicle no encontrado");

        // Actualizar campos
        existing.LicensePlate = dto.LicensePlate;
        existing.Brand = dto.Brand;
        existing.Model = dto.Model;
        existing.Year = dto.Year;
        existing.VIN = dto.VIN;
        existing.CompanyId = dto.CompanyId;

        await _vehicleRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _vehicleRepository.GetByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException("Vehicle no encontrado");

        await _vehicleRepository.DeleteAsync(id);
    }
}