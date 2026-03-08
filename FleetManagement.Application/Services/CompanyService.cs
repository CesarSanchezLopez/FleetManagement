using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;

namespace FleetManagement.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<List<Company>> GetAllAsync()
    {
        return await _companyRepository.GetAllAsync();
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _companyRepository.GetByIdAsync(id);
    }

   public async Task CreateAsync(Company company)
{
    company.Id = Guid.NewGuid();
    company.CreatedAt = DateTime.UtcNow;

    await _companyRepository.AddAsync(company);
}

    public async Task UpdateAsync(Company company)
    {
        await _companyRepository.UpdateAsync(company);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _companyRepository.DeleteAsync(id);
    }

    public Task CreateAsync(CompanyDto dto)
    {
        throw new NotImplementedException();
    }
}