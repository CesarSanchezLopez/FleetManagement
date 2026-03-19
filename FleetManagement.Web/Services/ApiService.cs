using FleetManagement.Domain.Entities;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Company>> GetCompaniesAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Company>>("api/company");
        return result ?? new List<Company>();
    }
    public async Task<bool> CreateCompanyAsync(Company company)
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
}