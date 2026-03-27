using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Mapster;

namespace FleetManagement.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // Obtener todos los vehículos
        public async Task<List<VehicleDto>> GetAllAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return vehicles.Adapt<List<VehicleDto>>();
        }

        // Obtener un vehículo por Id
        public async Task<VehicleDto?> GetByIdAsync(Guid id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            return vehicle?.Adapt<VehicleDto>();
        }

        // Crear un vehículo
        public async Task<VehicleDto> CreateAsync(VehicleDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var vehicle = dto.Adapt<Vehicle>();
            vehicle.Id = Guid.NewGuid();
            vehicle.CreatedAt = DateTime.UtcNow;

            await _vehicleRepository.AddAsync(vehicle);

            return vehicle.Adapt<VehicleDto>();
        }

        // Actualizar un vehículo existente
        public async Task UpdateAsync(VehicleDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (!dto.Id.HasValue || dto.Id == Guid.Empty)
                throw new ArgumentException("Id es requerido para actualizar");

            var existing = await _vehicleRepository.GetByIdAsync(dto.Id.Value);
            if (existing == null)
                throw new KeyNotFoundException("Vehicle no encontrado");

            // Asignar manualmente los campos que se pueden actualizar
            existing.LicensePlate = dto.LicensePlate;
            existing.Brand = dto.Brand;
            existing.Model = dto.Model;
            existing.Year = dto.Year;
            existing.VIN = dto.VIN;
            existing.CompanyId = dto.CompanyId;

            await _vehicleRepository.UpdateAsync(existing);
        }

        // Eliminar un vehículo
        public async Task DeleteAsync(Guid id)
        {
            var existing = await _vehicleRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Vehicle no encontrado");

            await _vehicleRepository.DeleteAsync(id);
        }
    }
}