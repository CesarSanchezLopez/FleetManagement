using FleetManagement.Application.DTOs.Vehicles;
using FleetManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FleetManagement.Web.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly VehiclesService _vehiclesService;

        public DeleteModel(VehiclesService vehiclesService)
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
            if (Vehicle.Id == null || Vehicle.Id == Guid.Empty)
                return RedirectToPage("Index");

            await _vehiclesService.DeleteAsync(Vehicle.Id.Value);
            return RedirectToPage("Index");
        }
    }
}