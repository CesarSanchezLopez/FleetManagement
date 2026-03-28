using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Drivers;

public class IndexModel : PageModel
{
    private readonly DriversService _driversService;
    private readonly CompaniesService _companiesService;

    public IndexModel(DriversService driversService, CompaniesService companiesService)
    {
        _driversService = driversService;
        _companiesService = companiesService;
    }

    public List<DriverDto> Drivers { get; set; } = new();
    public List<CompanyDto> Companies { get; set; } = new();

    [BindProperty]
    public DriverDto Input { get; set; } = new();

    [TempData] public string? ToastMessage { get; set; }
    [TempData] public string? ToastType { get; set; }

    public async Task OnGetAsync()
    {
        Drivers = await _driversService.GetAllAsync();
        Companies = await _companiesService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {
        if (Input.CompanyId == null)
        {
            ModelState.AddModelError("", "Seleccione una empresa");
            await OnGetAsync();
            return Page();
        }

        await _driversService.CreateAsync(Input);
        ToastMessage = "Conductor creado correctamente";
        ToastType = "success";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEditAsync()
    {
        await _driversService.UpdateAsync(Input);
        ToastMessage = "Conductor actualizado";
        ToastType = "warning";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        await _driversService.DeleteAsync(Input.Id);
        ToastMessage = "Conductor eliminado";
        ToastType = "danger";
        return RedirectToPage();
    }
}