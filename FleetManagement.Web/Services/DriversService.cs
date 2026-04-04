using FleetManagement.Application.DTOs.Drivers;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services
{
    public class DriversService
    {
        private readonly HttpClient _httpClient;

        public DriversService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DriverDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<DriverDto>>("api/drivers") ?? new List<DriverDto>();
            }
            catch
            {
                return new List<DriverDto>();
            }
        }

        public async Task<DriverDto?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<DriverDto>($"api/drivers/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(DriverDto driver)
        {
            var response = await _httpClient.PostAsJsonAsync("api/drivers", driver);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(DriverDto driver)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/drivers/{driver.Id}", driver);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/drivers/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}