using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.RegisteredVehicle;

namespace TourismSystem.Application.Interfaces
{
    public interface IRegisteredVehicleService
    {
        Task<CreateRegisteredVehicleResponseDto> CreateRegisteredVehicleAsync(
            CreateRegisteredVehicleRequestDto request,
            string createdBy);

        Task<List<RegisteredVehicleResponseDto>> GetAllRegisteredVehiclesAsync();

        Task<RegisteredVehicleResponseDto?> GetRegisteredVehicleByIdAsync(int registeredVehicleId);

        Task<bool> SetAvailabilityAsync(int registeredVehicleId, bool isAvailable, string modifiedBy);
    }
}
