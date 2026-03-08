using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Guid id);
        Task CreateAsync(CompanyDto dto);
    }
}