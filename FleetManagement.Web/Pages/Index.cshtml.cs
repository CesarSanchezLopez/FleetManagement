using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManagement.Web.Services;

namespace FleetManagement.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CompaniesService _companiesService;
        private readonly VehiclesService _vehiclesService;
        private readonly DriversService _driversService;

        public IndexModel(CompaniesService companiesService, VehiclesService vehiclesService, DriversService driversService)
        {
            _companiesService = companiesService;
            _vehiclesService = vehiclesService;
            _driversService = driversService;
        }

        public int TotalCompanies { get; set; }
        public int TotalVehicles { get; set; }
        public int TotalDrivers { get; set; }
        public int TotalMaintenance { get; set; } = 5; // ejemplo estático

        public async Task OnGetAsync()
        {
            TotalCompanies = (await _companiesService.GetAllAsync()).Count;
            TotalVehicles = (await _vehiclesService.GetAllAsync()).Count;
            TotalDrivers = (await _driversService.GetAllAsync()).Count;
        }
    }
}