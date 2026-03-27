using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies;

public class IndexModel : PageModel
{
    private readonly CompaniesService _companiesService;

    public IndexModel(CompaniesService companiesService)
    {
        _companiesService = companiesService;
    }

    public List<CompanyDto> Companies { get; set; } = new List<CompanyDto>();

    public async Task OnGetAsync()
    {
        Companies = await _companiesService.GetAllAsync();
    }
}