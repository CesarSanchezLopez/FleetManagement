using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using FleetManagement.Application.DTOs.Companies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly VehiclesService _vehiclesService;
        private readonly CompaniesService _companiesService;

        public IndexModel(VehiclesService vehiclesService, CompaniesService companiesService)
        {
            _vehiclesService = vehiclesService;
            _companiesService = companiesService;
        }

        public List<VehicleDto> Vehicles { get; set; } = new();
        public List<CompanyDto> Companies { get; set; } = new();

        [BindProperty]
        public VehicleDto Input { get; set; } = new();

        [TempData]
        public string? ToastMessage { get; set; }
        [TempData]
        public string? ToastType { get; set; }

        // GET: lista vehículos y empresas
        public async Task OnGetAsync()
        {
            Vehicles = await _vehiclesService.GetAllAsync();
            Companies = await _companiesService.GetAllAsync();
        }

        // POST: crear vehículo
        public async Task<IActionResult> OnPostCreateAsync()
        {
            await _vehiclesService.CreateAsync(Input);
            ToastMessage = $"Vehículo '{Input.LicensePlate}' creado.";
            ToastType = "success";
            return RedirectToPage();
        }

        // POST: editar vehículo
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!Input.Id.HasValue)
            {
                ModelState.AddModelError("", "Id requerido para editar");
                return Page();
            }

            await _vehiclesService.UpdateAsync(Input);
            ToastMessage = $"Vehículo '{Input.LicensePlate}' actualizado.";
            ToastType = "warning";
            return RedirectToPage();
        }

        // POST: eliminar vehículo
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (!Input.Id.HasValue)
            {
                ModelState.AddModelError("", "Id requerido para eliminar");
                return Page();
            }

            await _vehiclesService.DeleteAsync(Input.Id.Value);
            ToastMessage = $"Vehículo eliminado.";
            ToastType = "danger";
            return RedirectToPage();
        }
    }
}