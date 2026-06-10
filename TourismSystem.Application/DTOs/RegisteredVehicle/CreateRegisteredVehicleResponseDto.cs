using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Application.DTOs.RegisteredVehicle
{
    public class CreateRegisteredVehicleResponseDto
    {
        public int RegisteredVehicleId { get; set; }
        public int VehicleId { get; set; }
        public string LicenseNumber { get; set; }
        public string OwnerName { get; set; }
        public int ManufactureYear { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
