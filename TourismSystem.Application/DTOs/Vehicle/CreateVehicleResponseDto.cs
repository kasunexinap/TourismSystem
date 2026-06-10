using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Application.DTOs.Vehicle
{
    public class CreateVehicleResponseDto
    {
        public int VehicleId { get; set; }

        public string Name { get; set; }

        public decimal RatePerKm { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
