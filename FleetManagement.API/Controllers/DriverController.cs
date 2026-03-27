using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriversController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    // GET: api/drivers
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var drivers = await _driverService.GetAllAsync();
        return Ok(drivers);
    }

    // GET: api/drivers/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var driver = await _driverService.GetByIdAsync(id);
        if (driver == null) return NotFound();
        return Ok(driver);
    }

    // POST: api/drivers
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DriverDto dto)
    {
        var created = await _driverService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/drivers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DriverDto dto)
    {
        dto.Id = id; // aseguramos que el Id venga del endpoint
        await _driverService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/drivers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _driverService.DeleteAsync(id);
        return NoContent();
    }
}