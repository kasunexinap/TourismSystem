using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TourismSystem.Application.DTOs.RegisteredVehicle;
using TourismSystem.Application.Interfaces;
using TourismSystem.Domain.Entities;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Application.Services;

public class RegisteredVehicleService : IRegisteredVehicleService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<RegisteredVehicleService> _logger;

    public RegisteredVehicleService(
        IApplicationDbContext context,
        ILogger<RegisteredVehicleService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateRegisteredVehicleResponseDto> CreateRegisteredVehicleAsync(
        CreateRegisteredVehicleRequestDto request,
        string createdBy)
    {
        var vehicleExists = await _context.Vehicles
            .AnyAsync(x => x.Id == request.VehicleId && x.IsActive);

        if (!vehicleExists)
            throw new ArgumentException("Vehicle type not found.");

        var registeredVehicle = new RegisteredVehicle
        {
            VehicleId = request.VehicleId,
            LicenseNumber = request.LicenseNumber,
            OwnerName = request.OwnerName,
            OwnerContactNo = request.OwnerContactNo,
            ManufactureYear = request.ManufactureYear,
            Color = request.Color,
            IsAvailable = true,
            Status = RegisteredVehicleStatus.Available,
            Condition = VehicleCondition.Good,
            IsActive = true,
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow
        };

        _context.RegisteredVehicles.Add(registeredVehicle);
        await _context.SaveChangesAsync();

        return new CreateRegisteredVehicleResponseDto
        {
            RegisteredVehicleId = registeredVehicle.Id,
            VehicleId = registeredVehicle.VehicleId,
            LicenseNumber = registeredVehicle.LicenseNumber,
            OwnerName = registeredVehicle.OwnerName,
            ManufactureYear = registeredVehicle.ManufactureYear,
            IsAvailable = registeredVehicle.IsAvailable,
            Status = registeredVehicle.Status,
            Condition = registeredVehicle.Condition,
            CreatedDate = registeredVehicle.CreatedDate
        };
    }

    public async Task<List<RegisteredVehicleResponseDto>> GetAllRegisteredVehiclesAsync()
    {
        return await _context.RegisteredVehicles
            .Where(x => x.IsActive)
            .Select(x => new RegisteredVehicleResponseDto
            {
                RegisteredVehicleId = x.Id,
                VehicleId = x.VehicleId,
                VehicleName = x.Vehicle.Name,
                LicenseNumber = x.LicenseNumber,
                OwnerName = x.OwnerName,
                OwnerContactNo = x.OwnerContactNo,
                ManufactureYear = x.ManufactureYear,
                Color = x.Color,
                IsAvailable = x.IsAvailable,
                Status = x.Status,
                Condition = x.Condition
            })
            .ToListAsync();
    }

    public async Task<RegisteredVehicleResponseDto?> GetRegisteredVehicleByIdAsync(int registeredVehicleId)
    {
        return await _context.RegisteredVehicles
            .Where(x => x.Id == registeredVehicleId && x.IsActive)
            .Select(x => new RegisteredVehicleResponseDto
            {
                RegisteredVehicleId = x.Id,
                VehicleId = x.VehicleId,
                VehicleName = x.Vehicle.Name,
                LicenseNumber = x.LicenseNumber,
                OwnerName = x.OwnerName,
                OwnerContactNo = x.OwnerContactNo,
                ManufactureYear = x.ManufactureYear,
                Color = x.Color,
                IsAvailable = x.IsAvailable,
                Status = x.Status,
                Condition = x.Condition
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> SetAvailabilityAsync(
        int registeredVehicleId,
        bool isAvailable,
        string modifiedBy)
    {
        var registeredVehicle = await _context.RegisteredVehicles
            .FirstOrDefaultAsync(x => x.Id == registeredVehicleId && x.IsActive);

        if (registeredVehicle == null)
            return false;

        registeredVehicle.IsAvailable = isAvailable;
        registeredVehicle.ModifiedBy = modifiedBy;
        registeredVehicle.ModifiedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}