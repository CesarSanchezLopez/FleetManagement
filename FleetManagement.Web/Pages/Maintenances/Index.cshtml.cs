using FleetManagement.Application.DTOs.Maintenance;
using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Maintenances
{
    public class IndexModel : PageModel
    {
        private readonly MaintenancesService _maintenancesService;
        private readonly VehiclesService _vehiclesService;

        public IndexModel(MaintenancesService maintenancesService, VehiclesService vehiclesService)
        {
            _maintenancesService = maintenancesService;
            _vehiclesService = vehiclesService;
        }

        // Lista de mantenimientos
        public List<MaintenanceDto> Maintenances { get; set; } = new List<MaintenanceDto>();

        // Lista de vehículos para el desplegable
        public List<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();

        // Para binding de modales
        [BindProperty]
        public MaintenanceDto Input { get; set; } = new MaintenanceDto();

        // Toast
        [TempData]
        public string? ToastMessage { get; set; }
        [TempData]
        public string? ToastType { get; set; }

        // GET
        public async Task OnGetAsync()
        {
            Maintenances = await _maintenancesService.GetAllAsync();
            Vehicles = await _vehiclesService.GetAllAsync(); // Obtener vehículos para el desplegable
        }

        // Crear
        public async Task<IActionResult> OnPostCreateAsync()
        {
            await _maintenancesService.CreateAsync(Input);
            ToastMessage = $"Mantenimiento creado con éxito.";
            ToastType = "success";
            return RedirectToPage();
        }
    }
}