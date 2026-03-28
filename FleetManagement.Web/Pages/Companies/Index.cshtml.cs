using FleetManagement.Application.DTOs.Companies;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly CompaniesService _companiesService;

        public IndexModel(CompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        // Lista de empresas
        public List<CompanyDto> Companies { get; set; } = new List<CompanyDto>();

        // Para binding de modales
        [BindProperty]
        public CompanyDto Input { get; set; } = new CompanyDto();

        // Toast
        [TempData]
        public string? ToastMessage { get; set; }
        [TempData]
        public string? ToastType { get; set; }

        // GET
        public async Task OnGetAsync()
        {
            Companies = await _companiesService.GetAllAsync();
        }

        // Crear
        public async Task<IActionResult> OnPostCreateAsync()
        {
            await _companiesService.CreateAsync(Input);
            ToastMessage = $"Empresa '{Input.Name}' creada con éxito.";
            ToastType = "success";
            return RedirectToPage();
        }

        // Editar
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (Input.Id == null)
            {
                ModelState.AddModelError("", "No se recibió un Id válido");
                return Page();
            }

            await _companiesService.UpdateAsync(Input);

            ToastMessage = $"Empresa '{Input.Name}' actualizada con éxito.";
            ToastType = "warning";

            return RedirectToPage();
        }

        // Eliminar
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (Input.Id == null)
            {
                ModelState.AddModelError("", "No se recibió un Id válido");
                return Page();
            }

            await _companiesService.DeleteAsync(Input.Id.Value);

            ToastMessage = $"Empresa eliminada correctamente.";
            ToastType = "danger";

            return RedirectToPage();
        }
    }
}