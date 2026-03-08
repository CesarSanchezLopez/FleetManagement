using FleetManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FleetManagement.Application.Interfaces;

public interface IMaintenanceRepository
{
    Task AddAsync(Maintenance maintenance);
    Task<Maintenance?> GetByIdAsync(Guid id);
    Task<List<Maintenance>> GetAllAsync();
    Task UpdateAsync(Maintenance maintenance);
    Task DeleteAsync(Guid id);
}