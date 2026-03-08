using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Persistence.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly FleetDbContext _context;

    public DriverRepository(FleetDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Driver driver)
    {
        await _context.Drivers.AddAsync(driver);
        await _context.SaveChangesAsync();
    }

    public async Task<Driver?> GetByIdAsync(Guid id)
    {
        return await _context.Drivers.FindAsync(id);
    }

    public async Task<List<Driver>> GetAllAsync()
    {
        return await _context.Drivers.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Driver driver)
    {
        _context.Drivers.Update(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Drivers.FindAsync(id);
        if (entity != null)
        {
            _context.Drivers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}