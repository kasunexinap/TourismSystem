using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismSystem.Application.DTOs.Vehicle;
using TourismSystem.Application.Interfaces;

namespace TourismSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleRequestDto request)
        {
            var result = await _vehicleService.CreateVehicleAsync(request, "ADMIN");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _vehicleService.GetAllVehiclesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _vehicleService.GetVehicleByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateVehicleRequestDto request)
        {
            var result = await _vehicleService.UpdateVehicleAsync(request, "ADMIN");

            if (!result)
                return NotFound();

            return Ok("Vehicle updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id, "ADMIN");

            if (!result)
                return NotFound();

            return Ok("Vehicle deleted successfully");
        }
    }
}
