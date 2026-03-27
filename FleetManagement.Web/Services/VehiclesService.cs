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

        // Obtener todos los vehículos
        public async Task<List<VehicleDto>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<VehicleDto>>("api/vehicles");
            return result ?? new List<VehicleDto>();
        }

        // Obtener vehículo por ID
        public async Task<VehicleDto?> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<VehicleDto>($"api/vehicles/{id}");
        }

        // Crear vehículo
        public async Task<bool> CreateAsync(VehicleDto vehicle)
        {
            var response = await _httpClient.PostAsJsonAsync("api/vehicles", vehicle);
            return response.IsSuccessStatusCode;
        }

        // Actualizar vehículo
        public async Task<bool> UpdateAsync(VehicleDto vehicle)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/vehicles/{vehicle.Id}", vehicle);
            return response.IsSuccessStatusCode;
        }

        // Eliminar vehículo
        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/vehicles/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}