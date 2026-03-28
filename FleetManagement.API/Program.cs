using FleetManagement.Application.Interfaces;
using FleetManagement.Application.Services;
using FleetManagement.Persistence;
using FleetManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;

// Servicios
builder.Services.AddControllers();

// Mapster (mapeo DTO <-> Entity)
MapsterConfig.RegisterMappings();

// Registrar DbContext (ajusta el proveedor/connection string según tu proyecto)
var connectionString = configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<FleetDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// Repositorios / servicios de aplicación

// Companies
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

// Drivers
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

// Vehicles
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// (Opcional: Fuel, Maintenance, etc., si los tienes)
// builder.Services.AddScoped<IFuelService, FuelService>();
// builder.Services.AddScoped<IFuelRepository, FuelRepository>();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FleetManagement.API",
        Version = "v1",
        Description = "API para gestión de flotas"
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // En staging/production puedes habilitar Swagger opcionalmente o protegerlo.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();