using FleetManagement.Application.DTOs.Maintenance;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services
{
    public class MaintenancesService
    {
        private readonly HttpClient _httpClient;

        public MaintenancesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MaintenanceDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<MaintenanceDto>>("api/maintenance") ?? new List<MaintenanceDto>();
            }
            catch
            {
                return new List<MaintenanceDto>();
            }
        }

        public async Task<MaintenanceDto?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MaintenanceDto>($"api/maintenance/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(MaintenanceDto maintenance)
        {
            var response = await _httpClient.PostAsJsonAsync("api/maintenance", maintenance);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(MaintenanceDto maintenance)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/maintenance/{maintenance.Id}", maintenance);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/maintenance/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}