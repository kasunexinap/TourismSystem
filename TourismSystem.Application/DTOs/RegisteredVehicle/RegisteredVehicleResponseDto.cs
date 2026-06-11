using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Application.DTOs.RegisteredVehicle
{
    public class RegisteredVehicleResponseDto
    {
        public int RegisteredVehicleId { get; set; }

        public int VehicleId { get; set; }

        public string VehicleName { get; set; } = string.Empty;

        public string LicenseNumber { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string OwnerContactNo { get; set; } = string.Empty;

        public int ManufactureYear { get; set; }

        public string Color { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        public RegisteredVehicleStatus Status { get; set; }

        public VehicleCondition Condition { get; set; }
    }
}
