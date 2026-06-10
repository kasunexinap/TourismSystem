using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Application.DTOs.Vehicle
{
    public class CreateVehicleRequestDto
    {
        public string Name { get; set; }

        public decimal RatePerKm { get; set; }
    }
}
