using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.Vehicle;
using TourismSystem.Application.Interfaces;

namespace TourismSystem.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public VehicleService()
        {
        }

        public Task<CreateVehicleResponseDto> CreateVehicleAsync(CreateVehicleRequestDto request, string createdBy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVehicleAsync(int vehicleId, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleResponseDto>> GetAllVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleResponseDto?> GetVehicleByIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateVehicleAsync(UpdateVehicleRequestDto request, string modifiedBy)
        {
            throw new NotImplementedException();
        }

        // Implement methods from IVehicleService here
    }
}
