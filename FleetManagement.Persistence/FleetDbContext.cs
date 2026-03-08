using Microsoft.EntityFrameworkCore;
using FleetManagement.Domain.Entities;

namespace FleetManagement.Persistence;

public class FleetDbContext : DbContext
{
    public FleetDbContext(DbContextOptions<FleetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Maintenance> Maintenances => Set<Maintenance>();
    public DbSet<FuelRecord> FuelRecords => Set<FuelRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Company
        modelBuilder.Entity<Company>()
            .HasIndex(c => c.Nit)
            .IsUnique();

        // Vehicle
        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => new { v.CompanyId, v.LicensePlate })
            .IsUnique();

        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Company)
            .WithMany(c => c.Vehicles)
            .HasForeignKey(v => v.CompanyId);

        // Driver
        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Company)
            .WithMany(c => c.Drivers)
            .HasForeignKey(d => d.CompanyId);

        // Maintenance
        modelBuilder.Entity<Maintenance>()
            .HasOne(m => m.Vehicle)
            .WithMany(v => v.Maintenances)
            .HasForeignKey(m => m.VehicleId);

        // FuelRecord
        modelBuilder.Entity<FuelRecord>()
            .HasOne(f => f.Vehicle)
            .WithMany(v => v.FuelRecords)
            .HasForeignKey(f => f.VehicleId);
    }
}