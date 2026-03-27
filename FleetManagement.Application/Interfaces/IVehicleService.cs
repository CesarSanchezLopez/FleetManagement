using FleetManagement.Application.DTOs.Vehicles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleDto>> GetAllAsync();
        Task<VehicleDto?> GetByIdAsync(Guid id);
        Task<VehicleDto> CreateAsync(VehicleDto dto);
        Task UpdateAsync(VehicleDto dto);
        Task DeleteAsync(Guid id);
    }
}