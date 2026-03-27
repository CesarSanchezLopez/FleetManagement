using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class DeleteModel : PageModel
{
    private readonly CompaniesService _companiesService;

    public DeleteModel(CompaniesService companiesService)
    {
        _companiesService = companiesService;
    }

    // ✅ Solo usamos Guid (NO nullable)
    [BindProperty]
    public Guid CompanyId { get; set; }

    // Solo para mostrar información
    public CompanyDto? Company { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var company = await _companiesService.GetByIdAsync(id);
        if (company == null)
            return RedirectToPage("Index");

        Company = company;
        CompanyId = company.Id ?? Guid.Empty;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (CompanyId == Guid.Empty)
            return RedirectToPage("Index");

        await _companiesService.DeleteAsync(CompanyId);

        return RedirectToPage("Index");
    }
}