using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly VehiclesService _vehiclesService;

        public CreateModel(VehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [BindProperty]
        public VehicleDto Vehicle { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var success = await _vehiclesService.CreateAsync(Vehicle);
            if (!success)
            {
                ModelState.AddModelError("", "No se pudo crear el vehículo.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
