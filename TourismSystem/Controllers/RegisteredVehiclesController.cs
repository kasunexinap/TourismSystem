using Microsoft.AspNetCore.Mvc;
using TourismSystem.Application.DTOs.RegisteredVehicle;
using TourismSystem.Application.Interfaces;

namespace TourismSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisteredVehiclesController : ControllerBase
{
    private readonly IRegisteredVehicleService _registeredVehicleService;

    public RegisteredVehiclesController(IRegisteredVehicleService registeredVehicleService)
    {
        _registeredVehicleService = registeredVehicleService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRegisteredVehicleRequestDto request)
    {
        var result = await _registeredVehicleService
            .CreateRegisteredVehicleAsync(request, "ADMIN");

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _registeredVehicleService
            .GetAllRegisteredVehiclesAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _registeredVehicleService
            .GetRegisteredVehicleByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}/availability")]
    public async Task<IActionResult> SetAvailability(int id, [FromQuery] bool isAvailable)
    {
        var result = await _registeredVehicleService
            .SetAvailabilityAsync(id, isAvailable, "ADMIN");

        if (!result)
            return NotFound();

        return Ok("Availability updated successfully");
    }
}