//using FleetManagement.Application.DTOs.Maintenance;
//using FleetManagement.Application.DTOs.Maintenances;
//using FleetManagement.Application.Helpers;
//using FleetManagement.Application.Interfaces;
//using FleetManagement.Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace FleetManagement.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class MaintenanceController : ControllerBase
//{
//    private readonly IMaintenanceService _maintenanceService;

//    public MaintenanceController(IMaintenanceService maintenanceService)
//    {
//        _maintenanceService = maintenanceService;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        var maintenances = await _maintenanceService.GetAllAsync();
//        return Ok(MapperHelper.MapList<Maintenance, MaintenanceDto>(maintenances));
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(Guid id)
//    {
//        var maintenance = await _maintenanceService.GetByIdAsync(id);
//        if (maintenance == null) return NotFound();

//        return Ok(MapperHelper.Map<Maintenance, MaintenanceDto>(maintenance));
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromBody] MaintenanceDto dto)
//    {
//        var maintenance = MapperHelper.Map<MaintenanceDto, Maintenance>(dto);
//        maintenance.CreatedAt = DateTime.UtcNow;
//        await _maintenanceService.CreateAsync(maintenance);
//        return Ok();
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(Guid id, [FromBody] MaintenanceDto dto)
//    {
//        if (id != dto.Id) return BadRequest("El id de la URL no coincide con el DTO");

//        var maintenance = MapperHelper.Map<MaintenanceDto, Maintenance>(dto);
//        await _maintenanceService.UpdateAsync(maintenance);
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(Guid id)
//    {
//        await _maintenanceService.DeleteAsync(id);
//        return NoContent();
//    }
//}