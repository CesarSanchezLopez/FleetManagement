using FleetManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FleetManagement.Application.Interfaces;

public interface IDriverRepository
{
    Task AddAsync(Driver driver);
    Task<Driver?> GetByIdAsync(Guid id);
    Task<List<Driver>> GetAllAsync();
    Task UpdateAsync(Driver driver);
    Task DeleteAsync(Guid id);
}