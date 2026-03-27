using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Drivers;

public class IndexModel : PageModel
{
    private readonly DriversService _driversService;

    public IndexModel(DriversService driversService)
    {
        _driversService = driversService;
    }  

    public List<DriverDto> Drivers { get; set; } = new();

    public async Task OnGetAsync()
    {
        Drivers = await _driversService.GetAllAsync();
    }
}