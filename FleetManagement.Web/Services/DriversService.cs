using FleetManagement.Application.DTOs.Drivers;
using System.Net.Http.Json;

namespace FleetManagement.Web.Services;

public class DriversService
{
    private readonly HttpClient _httpClient;

    public DriversService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obtener todos los conductores
    public async Task<List<DriverDto>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<DriverDto>>("api/drivers");
        return result ?? new List<DriverDto>();
    }

    // Obtener conductor por ID
    public async Task<DriverDto?> GetByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<DriverDto>($"api/drivers/{id}");
    }

    // Crear conductor
    public async Task<bool> CreateAsync(DriverDto driver)
    {
        var response = await _httpClient.PostAsJsonAsync("api/drivers", driver);
        return response.IsSuccessStatusCode;
    }

    // Actualizar conductor
    public async Task<bool> UpdateAsync(DriverDto driver)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/drivers/{driver.Id}", driver);
        return response.IsSuccessStatusCode;
    }

    // Eliminar conductor
    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/drivers/{id}");
        return response.IsSuccessStatusCode;
    }
}