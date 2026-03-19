using FleetManagement.Domain.Entities;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;

    public List<Company> Companies { get; set; } = new();

    public IndexModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task OnGetAsync()
    {
        Companies = await _apiService.GetCompaniesAsync();
    }
}