using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Mapster;

namespace FleetManagement.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<List<CompanyDto>> GetAllAsync()
    {
        var companies = await _companyRepository.GetAllAsync();
        return companies.Adapt<List<CompanyDto>>();
    }

    public async Task<CompanyDto?> GetByIdAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        return company?.Adapt<CompanyDto>();
    }

    public async Task<CompanyDto> CreateAsync(CompanyDto dto)
    {
        var company = dto.Adapt<Company>();
        company.Id = Guid.NewGuid();
        company.CreatedAt = DateTime.UtcNow;

        await _companyRepository.AddAsync(company);

        return company.Adapt<CompanyDto>();
    }

    public async Task UpdateAsync(CompanyDto dto)
    {
        if (!dto.Id.HasValue)
            throw new ArgumentException("Id es requerido para actualizar");

        var existing = await _companyRepository.GetByIdAsync(dto.Id.Value);
        if (existing == null)
            throw new Exception("Company no encontrado");

        existing.Name = dto.Name;
        existing.Nit = dto.Nit;
        existing.Address = dto.Address;

        await _companyRepository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _companyRepository.GetByIdAsync(id);
        if (existing == null)
            throw new Exception("Company no encontrado");

        await _companyRepository.DeleteAsync(id);
    }
}