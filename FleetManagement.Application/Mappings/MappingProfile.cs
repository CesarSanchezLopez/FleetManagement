using AutoMapper;
using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.DTOs.FuelRecords;
using FleetManagement.Application.DTOs.Maintenance;
using FleetManagement.Application.DTOs.MaintenanceRecords;
using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Domain.Entities;

namespace FleetManagement.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //// Companies
        //CreateMap<Company, CompanyDto>().ReverseMap();

        //// Drivers
        //CreateMap<Driver, DriverDto>().ReverseMap();

        //// Vehicles
        //CreateMap<Vehicle, VehicleDto>().ReverseMap();

        //// Fuel Records
        //CreateMap<FuelRecord, FuelRecordDto>().ReverseMap();

        //// Maintenance
        //CreateMap<Maintenance, MaintenanceDto>().ReverseMap();

        //// Maintenance Records
        //CreateMap<MaintenanceRecord, MaintenanceRecordDto>().ReverseMap();
    }
}