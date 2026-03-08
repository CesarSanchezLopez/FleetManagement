using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Persistence.Repositories;

public class MaintenanceRepository : IMaintenanceRepository
{
    private readonly FleetDbContext _context;

    public MaintenanceRepository(FleetDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Maintenance maintenance)
    {
        await _context.Maintenances.AddAsync(maintenance);
        await _context.SaveChangesAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(Guid id)
    {
        return await _context.Maintenances.FindAsync(id);
    }

    public async Task<List<Maintenance>> GetAllAsync()
    {
        return await _context.Maintenances.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Maintenance maintenance)
    {
        _context.Maintenances.Update(maintenance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Maintenances.FindAsync(id);
        if (entity != null)
        {
            _context.Maintenances.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}