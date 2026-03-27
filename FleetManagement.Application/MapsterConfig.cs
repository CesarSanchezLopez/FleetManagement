using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.DTOs.FuelRecords;
using FleetManagement.Application.DTOs.Maintenance;
using FleetManagement.Application.DTOs.MaintenanceRecords;
using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Domain.Entities;
using Mapster;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        // Company
        TypeAdapterConfig<Company, CompanyDto>.NewConfig().PreserveReference(true);

        // Driver
        TypeAdapterConfig<Driver, DriverDto>.NewConfig().PreserveReference(true);

        // Vehicle
        TypeAdapterConfig<Vehicle, VehicleDto>.NewConfig().PreserveReference(true);

        // FuelRecord
        TypeAdapterConfig<FuelRecord, FuelRecordDto>.NewConfig().PreserveReference(true);

        // Maintenance
        TypeAdapterConfig<Maintenance, MaintenanceDto>.NewConfig().PreserveReference(true);

        // MaintenanceRecord
        TypeAdapterConfig<MaintenanceRecord, MaintenanceRecordDto>.NewConfig().PreserveReference(true);

        // Si quieres, también puedes agregar mappings inversos:
        TypeAdapterConfig<CompanyDto, Company>.NewConfig();
        TypeAdapterConfig<DriverDto, Driver>.NewConfig();
    }
}