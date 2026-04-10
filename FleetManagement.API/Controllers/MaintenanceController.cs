using FleetManagement.Application.DTOs.Maintenance;
using FleetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceController : ControllerBase
{
    private readonly IMaintenanceService _maintenanceService;

    public MaintenanceController(IMaintenanceService maintenanceService)
    {
        _maintenanceService = maintenanceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var maintenances = await _maintenanceService.GetAllAsync();
        return Ok(maintenances);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var maintenance = await _maintenanceService.GetByIdAsync(id);
        if (maintenance == null) return NotFound();
        return Ok(maintenance);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaintenanceDto dto)
    {
        var created = await _maintenanceService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MaintenanceDto dto)
    {
        if (id != dto.Id) return BadRequest("El id de la URL no coincide con el DTO");

        await _maintenanceService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _maintenanceService.DeleteAsync(id);
        return NoContent();
    }
}