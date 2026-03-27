using FleetManagement.Application.DTOs.Drivers;
using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetManagement.Web.Pages.Drivers;

public class CreateModel : PageModel
{
    private readonly DriversService _driversService;
    private readonly CompaniesService _companiesService;

    public CreateModel(DriversService driversService, CompaniesService companiesService)
    {
        _driversService = driversService;
        _companiesService = companiesService;
    }

    [BindProperty]
    public DriverDto Driver { get; set; } = new();

    public SelectList CompaniesSelectList { get; set; } = null!;

    public async Task OnGetAsync()
    {
        var companies = await _companiesService.GetAllAsync();
        CompaniesSelectList = new SelectList(companies, "Id", "Name");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var companies = await _companiesService.GetAllAsync();
            CompaniesSelectList = new SelectList(companies, "Id", "Name");
            return Page();
        }

        await _driversService.CreateAsync(Driver);
        return RedirectToPage("Index");
    }
}