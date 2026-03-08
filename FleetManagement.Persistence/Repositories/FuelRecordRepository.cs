using FleetManagement.Application.Interfaces;
using FleetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.Persistence.Repositories;

public class FuelRecordRepository : IFuelRecordRepository
{
    private readonly FleetDbContext _context;

    public FuelRecordRepository(FleetDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(FuelRecord record)
    {
        await _context.FuelRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task<FuelRecord?> GetByIdAsync(Guid id)
    {
        return await _context.FuelRecords.FindAsync(id);
    }

    public async Task<List<FuelRecord>> GetAllAsync()
    {
        return await _context.FuelRecords.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(FuelRecord record)
    {
        _context.FuelRecords.Update(record);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.FuelRecords.FindAsync(id);
        if (entity != null)
        {
            _context.FuelRecords.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}