using FleetManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace FleetManagement.Web.Pages.Companies;

public class EditModel : PageModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public Company Company { get; set; } = new();

    public EditModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task OnGetAsync(Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<Company>(
            $"https://localhost:7200/api/company/{id}");

        if (result != null)
            Company = result;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _httpClient.PutAsJsonAsync(
            $"https://localhost:7200/api/company/{Company.Id}",
            Company);

        return RedirectToPage("Index");
    }
}