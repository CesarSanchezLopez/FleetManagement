using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class CreateModel : PageModel
{
    private readonly CompaniesService _companiesService;

    public CreateModel(CompaniesService companiesService)
        => _companiesService = companiesService;

    [BindProperty]
    public CompanyDto Company { get; set; } = new CompanyDto();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _companiesService.CreateAsync(Company);
        return RedirectToPage("Index");
    }
}