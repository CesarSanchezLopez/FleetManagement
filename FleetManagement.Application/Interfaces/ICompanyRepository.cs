using FleetManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FleetManagement.Application.Interfaces;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<Company?> GetByIdAsync(Guid id);
    Task<List<Company>> GetAllAsync();
    Task UpdateAsync(Company company);
    Task DeleteAsync(Guid id);
}