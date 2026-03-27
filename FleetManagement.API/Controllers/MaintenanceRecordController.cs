//using FleetManagement.Application.DTOs.MaintenanceRecords;
//using FleetManagement.Application.Helpers;
//using FleetManagement.Application.Interfaces;
//using FleetManagement.Domain.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace FleetManagement.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class MaintenanceRecordController : ControllerBase
//{
//    private readonly IMaintenanceRecordService _maintenanceRecordService;

//    public MaintenanceRecordController(IMaintenanceRecordService maintenanceRecordService)
//    {
//        _maintenanceRecordService = maintenanceRecordService;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        var records = await _maintenanceRecordService.GetAllAsync();
//        return Ok(MapperHelper.MapList<MaintenanceRecord, MaintenanceRecordDto>(records));
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(Guid id)
//    {
//        var record = await _maintenanceRecordService.GetByIdAsync(id);
//        if (record == null) return NotFound();

//        return Ok(MapperHelper.Map<MaintenanceRecord, MaintenanceRecordDto>(record));
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromBody] MaintenanceRecordDto dto)
//    {
//        var record = MapperHelper.Map<MaintenanceRecordDto, MaintenanceRecord>(dto);
//        record.CreatedAt = DateTime.UtcNow;
//        await _maintenanceRecordService.CreateAsync(record);
//        return Ok();
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(Guid id, [FromBody] MaintenanceRecordDto dto)
//    {
//        if (id != dto.Id) return BadRequest("El id de la URL no coincide con el DTO");

//        var record = MapperHelper.Map<MaintenanceRecordDto, MaintenanceRecord>(dto);
//        await _maintenanceRecordService.UpdateAsync(record);
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(Guid id)
//    {
//        await _maintenanceRecordService.DeleteAsync(id);
//        return NoContent();
//    }
//}