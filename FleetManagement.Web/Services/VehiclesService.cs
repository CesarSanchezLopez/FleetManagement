using FleetManagement.Application.DTOs.Vehicles;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services
{
    public class VehiclesService
    {
        private readonly HttpClient _httpClient;

        public VehiclesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<VehicleDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<VehicleDto>>("api/vehicles") ?? new List<VehicleDto>();
            }
            catch
            {
                return new List<VehicleDto>();
            }
        }

        public async Task<VehicleDto?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<VehicleDto>($"api/vehicles/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(VehicleDto vehicle)
        {
            var response = await _httpClient.PostAsJsonAsync("api/vehicles", vehicle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(VehicleDto vehicle)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/vehicles/{vehicle.Id}", vehicle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/vehicles/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}