using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class EditModel : PageModel
{
    private readonly CompaniesService _companiesService;
    public EditModel(CompaniesService companiesService)
        => _companiesService = companiesService;

    [BindProperty]
    public CompanyDto Company { get; set; } = new CompanyDto();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var company = await _companiesService.GetByIdAsync(id);

        if (company == null)
            return RedirectToPage("Index");

        Company = company;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var success = await _companiesService.UpdateAsync(Company);

        if (!success)
        {
            ModelState.AddModelError(string.Empty, "Error al actualizar");
            return Page();
        }

        return RedirectToPage("Index");
    }
}