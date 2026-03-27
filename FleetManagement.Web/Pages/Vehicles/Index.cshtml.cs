using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly VehiclesService _vehiclesService;

        public IndexModel(VehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        // Lista de vehículos que se mostrará en la UI
        public List<VehicleDto> Vehicles { get; set; } = new();

        // Cargar todos los vehículos al abrir la página
        public async Task OnGetAsync()
        {
            Vehicles = await _vehiclesService.GetAllAsync();
        }
    }
}