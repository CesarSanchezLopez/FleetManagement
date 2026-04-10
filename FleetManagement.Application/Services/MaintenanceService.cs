using FleetManagement.Application.DTOs.Maintenance;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Mapster;

namespace FleetManagement.Application.Services;

public class MaintenanceService : IMaintenanceService
{
    private readonly IMaintenanceRepository _maintenanceRepository;

    public MaintenanceService(IMaintenanceRepository maintenanceRepository)
    {
        _maintenanceRepository = maintenanceRepository;
    }

    public async Task<IEnumerable<MaintenanceDto>> GetAllAsync()
    {
        var maintenances = await _maintenanceRepository.GetAllAsync();
        return maintenances.Select(m => new MaintenanceDto
        {
            Id = m.Id,
            VehicleId = m.VehicleId,
            VehicleLicensePlate = m.Vehicle.LicensePlate, // Asegúrate de que `Vehicle` esté incluido
            Type = m.Type,
            Description = m.Description,
            Cost = m.Cost,
            Date = m.Date,
            NextDueDate = m.NextDueDate
        }).ToList();
    }

    public async Task<MaintenanceDto?> GetByIdAsync(Guid id)
    {
        var maintenance = await _maintenanceRepository.GetByIdAsync(id);
        return maintenance?.Adapt<MaintenanceDto>();
    }

    public async Task<MaintenanceDto> CreateAsync(MaintenanceDto dto)
    {
        var maintenance = dto.Adapt<Maintenance>();
        maintenance.Id = Guid.NewGuid();
        maintenance.Date = DateTime.UtcNow;

        await _maintenanceRepository.AddAsync(maintenance);

        return maintenance.Adapt<MaintenanceDto>();
    }

    public async Task UpdateAsync(MaintenanceDto dto)
    {
        var existing = await _maintenanceRepository.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new Exception("Maintenance no encontrado");

        existing.VehicleId = dto.VehicleId;
        existing.Type = dto.Type;
        existing.Description = dto.Description;
        existing.Cost = dto.Cost;
        existing.Date = dto.Date;
        existing.NextDueDate = dto.NextDueDate;

        await _maintenanceRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _maintenanceRepository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Maintenance no encontrado");

        await _maintenanceRepository.DeleteAsync(id);
    }
}