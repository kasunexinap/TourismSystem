using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.Trip;
using TourismSystem.Application.Interfaces;

namespace TourismSystem.Application.Services
{
    public class TripService : ITripService
    {
        public TripService()
        {
        }

        public Task<bool> AssignRegisteredVehicleAsync(int tripId, int registeredVehicleId, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelTripAsync(int tripId, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task<CreateTripResponseDto> CreateTripAsync(CreateTripRequestDto request, string createdBy)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripResponseDto>> GetAllTripsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TripResponseDto?> GetTripByIdAsync(int tripId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTripStatusAsync(int tripId, int status, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        // Implement methods from ITripService here
    }
}
