using FleetManagement.Application.DTOs.Companies;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET
    public async Task<List<CompanyDto>> GetCompaniesAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<CompanyDto>>("api/company");
        return result ?? new List<CompanyDto>();
    }

    // POST
    public async Task<bool> CreateCompanyAsync(CompanyDto company)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/company", company);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> UpdateCompanyAsync(CompanyDto company)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/company/{company.Id}", company);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> DeleteCompanyAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/company/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}