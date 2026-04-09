using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly FleetDbContext _context;

    public VehicleRepository(FleetDbContext context)
    {
        _context = context;
    }

    // Agregar un vehículo
    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }

    // Obtener un vehículo por Id
    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles
            .Include(v => v.Company) // opcional, si quieres incluir info de la empresa
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    // Obtener todos los vehículos
    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    // Actualizar un vehículo
    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }

    // Eliminar un vehículo por Id
    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}