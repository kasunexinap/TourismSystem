using TourismSystem.Application.DTOs.Trip;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Application.Interfaces;

public interface ITripService
{
    Task<CreateTripResponseDto> CreateTripAsync(
        CreateTripRequestDto request,
        string createdBy);

    Task<List<TripResponseDto>> GetAllTripsAsync();

    Task<TripResponseDto?> GetTripByIdAsync(int tripId);

    Task<bool> AssignRegisteredVehicleAsync(
        int tripId,
        int registeredVehicleId,
        string modifiedBy);

    Task<bool> UpdateTripStatusAsync(
        int tripId,
        TripStatus status,
        string modifiedBy);

    Task<bool> CancelTripAsync(
        int tripId,
        string modifiedBy);
}