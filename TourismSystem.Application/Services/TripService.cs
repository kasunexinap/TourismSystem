using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TourismSystem.Application.DTOs.Trip;
using TourismSystem.Application.Interfaces;
using TourismSystem.Domain.Entities;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Application.Services;

public class TripService : ITripService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<TripService> _logger;

    public TripService(
        IApplicationDbContext context,
        ILogger<TripService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateTripResponseDto> CreateTripAsync(
        CreateTripRequestDto request,
        string createdBy)
    {
        _logger.LogInformation(
            "Creating trip for VehicleId={VehicleId}",
            request.VehicleId);

        if (request.DistanceKm > 1000)
        {
            throw new ArgumentException(
                "Distance cannot exceed 1000 km.");
        }

        var vehicle = await _context.Vehicles
            .FirstOrDefaultAsync(x =>
                x.Id == request.VehicleId &&
                x.IsActive);

        if (vehicle == null)
        {
            throw new ArgumentException(
                "Vehicle not found.");
        }

        var trip = new Trip
        {
            VehicleId = request.VehicleId,
            DistanceKm = request.DistanceKm,
            RatePerKm = vehicle.RatePerKm,
            TotalCost = request.DistanceKm * vehicle.RatePerKm,
            Status = TripStatus.Created,
            TripDate = DateTime.UtcNow,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        _context.Trips.Add(trip);

        await _context.SaveChangesAsync();

        return new CreateTripResponseDto
        {
            TripId = trip.Id,
            VehicleId = trip.VehicleId,
            DistanceKm = trip.DistanceKm,
            RatePerKm = trip.RatePerKm,
            TotalCost = trip.TotalCost,
            Status = trip.Status,
            TripDate = trip.TripDate
        };
    }

    public async Task<List<TripResponseDto>> GetAllTripsAsync()
    {
        return await _context.Trips
            .Where(x => x.IsActive)
            .Select(x => new TripResponseDto
            {
                TripId = x.Id,
                VehicleId = x.VehicleId,
                VehicleName = x.Vehicle.Name,
                RegisteredVehicleId = x.RegisteredVehicleId,
                DistanceKm = x.DistanceKm,
                RatePerKm = x.RatePerKm,
                TotalCost = x.TotalCost,
                Status = x.Status,
                TripDate = x.TripDate
            })
            .ToListAsync();
    }

    public async Task<TripResponseDto?> GetTripByIdAsync(
        int tripId)
    {
        return await _context.Trips
            .Where(x =>
                x.Id == tripId &&
                x.IsActive)
            .Select(x => new TripResponseDto
            {
                TripId = x.Id,
                VehicleId = x.VehicleId,
                VehicleName = x.Vehicle.Name,
                RegisteredVehicleId = x.RegisteredVehicleId,
                DistanceKm = x.DistanceKm,
                RatePerKm = x.RatePerKm,
                TotalCost = x.TotalCost,
                Status = x.Status,
                TripDate = x.TripDate
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> AssignRegisteredVehicleAsync(
        int tripId,
        int registeredVehicleId,
        string modifiedBy)
    {
        var trip = await _context.Trips
            .FirstOrDefaultAsync(x =>
                x.Id == tripId &&
                x.IsActive);

        if (trip == null)
            return false;

        var registeredVehicle =
            await _context.RegisteredVehicles
                .FirstOrDefaultAsync(x =>
                    x.Id == registeredVehicleId &&
                    x.IsActive &&
                    x.IsAvailable);

        if (registeredVehicle == null)
            return false;

        trip.RegisteredVehicleId =
            registeredVehicleId;

        trip.Status = TripStatus.Assigned;

        registeredVehicle.IsAvailable = false;

        trip.ModifiedBy = modifiedBy;
        trip.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateTripStatusAsync(
        int tripId,
        TripStatus status,
        string modifiedBy)
    {
        var trip = await _context.Trips
            .FirstOrDefaultAsync(x =>
                x.Id == tripId &&
                x.IsActive);

        if (trip == null)
            return false;

        trip.Status = status;
        trip.ModifiedBy = modifiedBy;
        trip.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CancelTripAsync(
        int tripId,
        string modifiedBy)
    {
        var trip = await _context.Trips
            .FirstOrDefaultAsync(x =>
                x.Id == tripId &&
                x.IsActive);

        if (trip == null)
            return false;

        trip.Status = TripStatus.Cancelled;
        trip.ModifiedBy = modifiedBy;
        trip.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}