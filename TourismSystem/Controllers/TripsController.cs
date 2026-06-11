using Microsoft.AspNetCore.Mvc;
using TourismSystem.Application.DTOs.Trip;
using TourismSystem.Application.Interfaces;
using TourismSystem.Domain.Enums;

namespace TourismSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;
    private readonly ILogger<TripsController> _logger;

    public TripsController(
        ITripService tripService,
        ILogger<TripsController> logger)
    {
        _tripService = tripService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTripRequestDto request)
    {
        _logger.LogInformation("Create trip request received");

        var result = await _tripService.CreateTripAsync(request, "ADMIN");

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _tripService.GetAllTripsAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _tripService.GetTripByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{tripId}/assign-vehicle/{registeredVehicleId}")]
    public async Task<IActionResult> AssignRegisteredVehicle(
        int tripId,
        int registeredVehicleId)
    {
        var result = await _tripService.AssignRegisteredVehicleAsync(
            tripId,
            registeredVehicleId,
            "ADMIN");

        if (!result)
            return BadRequest("Unable to assign registered vehicle");

        return Ok("Registered vehicle assigned successfully");
    }

    [HttpPut("{tripId}/status")]
    public async Task<IActionResult> UpdateStatus(
        int tripId,
        [FromQuery] TripStatus status)
    {
        var result = await _tripService.UpdateTripStatusAsync(
            tripId,
            status,
            "ADMIN");

        if (!result)
            return NotFound();

        return Ok("Trip status updated successfully");
    }

    [HttpPut("{tripId}/cancel")]
    public async Task<IActionResult> Cancel(int tripId)
    {
        var result = await _tripService.CancelTripAsync(
            tripId,
            "ADMIN");

        if (!result)
            return NotFound();

        return Ok("Trip cancelled successfully");
    }
}