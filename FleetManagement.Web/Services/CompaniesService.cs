using FleetManagement.Application.DTOs.Companies;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services
{
    public class CompaniesService
    {
        private readonly HttpClient _httpClient;

        public CompaniesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CompanyDto>>("api/company") ?? new List<CompanyDto>();
            }
            catch
            {
                return new List<CompanyDto>();
            }
        }

        public async Task<CompanyDto?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CompanyDto>($"api/company/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(CompanyDto company)
        {
            var response = await _httpClient.PostAsJsonAsync("api/company", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(CompanyDto company)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/company/{company.Id}", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/company/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}