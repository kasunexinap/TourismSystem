using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.RegisteredVehicle;
using TourismSystem.Application.Interfaces;

namespace TourismSystem.Application.Services
{
    public class RegisteredVehicleService : IRegisteredVehicleService
    {
        public RegisteredVehicleService()
        {
        }

        public Task<CreateRegisteredVehicleResponseDto> CreateRegisteredVehicleAsync(CreateRegisteredVehicleRequestDto request, string createdBy)
        {
            throw new NotImplementedException();
        }

        public Task<List<RegisteredVehicleResponseDto>> GetAllRegisteredVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RegisteredVehicleResponseDto?> GetRegisteredVehicleByIdAsync(int registeredVehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAvailabilityAsync(int registeredVehicleId, bool isAvailable, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        // Implement methods from IRegisteredVehicleService here
    }
}
