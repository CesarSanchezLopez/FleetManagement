using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetManagement.Web.Pages.Drivers;

public class EditModel : PageModel
{
    private readonly DriversService _driversService;
    private readonly CompaniesService _companiesService;

    public EditModel(DriversService driversService, CompaniesService companiesService)
    {
        _driversService = driversService;
        _companiesService = companiesService;
    }

    [BindProperty]
    public DriverDto Driver { get; set; } = new();

    public SelectList CompaniesSelectList { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var driver = await _driversService.GetByIdAsync(id);
        if (driver == null)
            return RedirectToPage("Index");

        Driver = driver;

        var companies = await _companiesService.GetAllAsync();
        CompaniesSelectList = new SelectList(companies, "Id", "Name");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var companies = await _companiesService.GetAllAsync();
            CompaniesSelectList = new SelectList(companies, "Id", "Name");
            return Page();
        }

        await _driversService.UpdateAsync(Driver);
        return RedirectToPage("Index");
    }
}