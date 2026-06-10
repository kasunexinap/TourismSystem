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
        public string LicenseNumber { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public int ManufactureYear { get; set; }
        public string? Color { get; set; }
    }
}
