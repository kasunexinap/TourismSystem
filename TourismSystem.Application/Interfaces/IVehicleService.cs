using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.Vehicle;

namespace TourismSystem.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<CreateVehicleResponseDto> CreateVehicleAsync(CreateVehicleRequestDto request, string createdBy);

        Task<List<VehicleResponseDto>> GetAllVehiclesAsync();

        Task<VehicleResponseDto?> GetVehicleByIdAsync(int vehicleId);

        Task<bool> UpdateVehicleAsync(UpdateVehicleRequestDto request, string modifiedBy);

        Task<bool> DeleteVehicleAsync(int vehicleId, string modifiedBy);
    }
}
