using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Application.DTOs.Vehicle;
using TourismSystem.Application.Interfaces;
using TourismSystem.Domain.Entities;

namespace TourismSystem.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<VehicleService> _logger;
        public VehicleService(IApplicationDbContext context, ILogger<VehicleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CreateVehicleResponseDto> CreateVehicleAsync(
        CreateVehicleRequestDto request,
        string createdBy)
        {
            _logger.LogInformation(
             "Creating vehicle. Name={VehicleName}",
             request.Name);
            try
            {


                var vehicle = new Vehicle
                {
                    Name = request.Name,
                    RatePerKm = request.RatePerKm,
                    IsActive = true,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                _logger.LogInformation(
               "Vehicle created successfully. VehicleId={VehicleId}",
               vehicle.Id);

                return new CreateVehicleResponseDto
                {
                    VehicleId = vehicle.Id,
                    Name = vehicle.Name,
                    RatePerKm = vehicle.RatePerKm,
                    CreatedDate = vehicle.CreatedDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(
               ex,
               "Error occurred while creating vehicle. Name={VehicleName}",
               request.Name);

                throw;
            }
        }

        public async Task<List<VehicleResponseDto>> GetAllVehiclesAsync()
        {
            _logger.LogInformation("Getting all active vehicles");
            return await _context.Vehicles
                .Where(x => x.IsActive)
                .Select(x => new VehicleResponseDto
                {
                    VehicleId = x.Id,
                    Name = x.Name,
                    RatePerKm = x.RatePerKm
                })
                .ToListAsync();
        }

        public async Task<VehicleResponseDto?> GetVehicleByIdAsync(int vehicleId)
        {
            _logger.LogInformation(
           "Getting vehicle. VehicleId={VehicleId}",
           vehicleId);
            return await _context.Vehicles
                .Where(x => x.Id == vehicleId && x.IsActive)
                .Select(x => new VehicleResponseDto
                {
                    VehicleId = x.Id,
                    Name = x.Name,
                    RatePerKm = x.RatePerKm
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateVehicleAsync(
            UpdateVehicleRequestDto request,
            string modifiedBy)
        {
            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(x => x.Id == request.VehicleId && x.IsActive);

            if (vehicle == null)
                return false;

            vehicle.Name = request.Name;
            vehicle.RatePerKm = request.RatePerKm;
            vehicle.ModifiedBy = modifiedBy;
            vehicle.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleAsync(
            int vehicleId,
            string modifiedBy)
        {
            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(x => x.Id == vehicleId && x.IsActive);

            if (vehicle == null)
                return false;

            vehicle.IsActive = false;
            vehicle.ModifiedBy = modifiedBy;
            vehicle.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Implement methods from IVehicleService here
    }
}
