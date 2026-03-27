using FleetManagement.Application.DTOs.Companies;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services;

public class CompaniesService
{
    private readonly HttpClient _httpClient;

    public CompaniesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtener todas las empresas
    public async Task<List<CompanyDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<CompanyDto>>("api/company");
        return result ?? new List<CompanyDto>();
    }

    // Obtener empresa por ID
    public async Task<CompanyDto?> GetByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<CompanyDto>($"api/company/{id}");
    }

    // Crear empresa
    public async Task<bool> CreateAsync(CompanyDto company)
    {
        var response = await _httpClient.PostAsJsonAsync("api/company", company);
        return response.IsSuccessStatusCode;
    }

    // Actualizar empresa
    public async Task<bool> UpdateAsync(CompanyDto company)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/company/{company.Id}", company);
        return response.IsSuccessStatusCode;
    }

    // Eliminar empresa
    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/company/{id}");
        return response.IsSuccessStatusCode;
    }
}