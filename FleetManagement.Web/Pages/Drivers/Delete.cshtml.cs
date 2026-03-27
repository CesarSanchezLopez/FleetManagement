using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Drivers;

public class DeleteModel : PageModel
{
    private readonly DriversService _driversService;

    public DeleteModel(DriversService driversService)
    {
        _driversService = driversService;
    }

    [BindProperty]
    public Guid DriverId { get; set; }

    public DriverDto? Driver { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var driver = await _driversService.GetByIdAsync(id);
        if (driver == null)
            return RedirectToPage("Index");

        Driver = driver;
        DriverId = driver.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (DriverId == Guid.Empty)
            return RedirectToPage("Index");

        await _driversService.DeleteAsync(DriverId);
        return RedirectToPage("Index");
    }
}