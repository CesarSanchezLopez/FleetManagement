using FleetManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FleetManagement.Application.Interfaces;

public interface IFuelRecordRepository
{
    Task AddAsync(FuelRecord record);
    Task<FuelRecord?> GetByIdAsync(Guid id);
    Task<List<FuelRecord>> GetAllAsync();
    Task UpdateAsync(FuelRecord record);
    Task DeleteAsync(Guid id);
}