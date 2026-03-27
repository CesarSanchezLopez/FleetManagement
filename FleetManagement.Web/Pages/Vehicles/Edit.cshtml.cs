using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly VehiclesService _vehiclesService;

        public EditModel(VehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [BindProperty]
        public VehicleDto Vehicle { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var vehicle = await _vehiclesService.GetByIdAsync(id);
            if (vehicle == null)
                return RedirectToPage("Index");

            Vehicle = vehicle;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var success = await _vehiclesService.UpdateAsync(Vehicle);
            if (!success)
            {
                ModelState.AddModelError("", "No se pudo actualizar el vehículo.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}