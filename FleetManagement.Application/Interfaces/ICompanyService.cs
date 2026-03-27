using FleetManagement.Application.DTOs.Companies;

public interface ICompanyService
{
    Task<List<CompanyDto>> GetAllAsync();
    Task<CompanyDto?> GetByIdAsync(Guid id);
    Task<CompanyDto> CreateAsync(CompanyDto dto);
    Task UpdateAsync(CompanyDto dto); // ya no necesitas pasar Id aparte
    Task DeleteAsync(Guid id);
}