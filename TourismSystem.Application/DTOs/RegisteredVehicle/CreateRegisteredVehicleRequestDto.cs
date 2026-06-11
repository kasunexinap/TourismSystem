using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Application.DTOs.RegisteredVehicle
{
    public class CreateRegisteredVehicleRequestDto
    {
        public int VehicleId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string OwnerContactNo { get; set; } = string.Empty;

        public int ManufactureYear { get; set; }

        public string Color { get; set; } = string.Empty;
    }
}
