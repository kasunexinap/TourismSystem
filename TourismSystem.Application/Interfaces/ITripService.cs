using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.Trip;

namespace TourismSystem.Application.Interfaces
{
    public interface ITripService
    {
        Task<CreateTripResponseDto> CreateTripAsync(CreateTripRequestDto request, string createdBy);

        Task<List<TripResponseDto>> GetAllTripsAsync();

        Task<TripResponseDto?> GetTripByIdAsync(int tripId);

        Task<bool> AssignRegisteredVehicleAsync(int tripId, int registeredVehicleId, string modifiedBy);

        Task<bool> UpdateTripStatusAsync(int tripId, int status, string modifiedBy);

        Task<bool> CancelTripAsync(int tripId, string modifiedBy);
    }
}
