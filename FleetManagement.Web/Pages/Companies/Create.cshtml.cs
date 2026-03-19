using FleetManagement.Domain.Entities;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class CreateModel : PageModel
{
    private readonly ApiService _apiService;

    [BindProperty]
    public Company Company { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public CreateModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        Company.Id = Guid.NewGuid();
        Company.CreatedAt = DateTime.UtcNow;

        var success = await _apiService.CreateCompanyAsync(Company);

        if (success)
            return RedirectToPage("Index");

        ErrorMessage = "No se pudo crear la empresa";
        return Page();
    }
}